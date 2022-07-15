using Autofac;
using Autofac.Extensions.DependencyInjection;
using Business.Dependency_Resolvers.Autofac;
using Core.DependencyResolvers;
using Core.Extensions;
using Core.Utilities.IoC;
using Core.Utilities.Security.Encryption;
using Core.Utilities.Security.JWT;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

//Burada Microsoft'un service'ini kullanaca��m�z� belirttik.
var builder = WebApplication.CreateBuilder(args);

//.Net Core'un IoC yap�s�n� kullanmak yerine ba�ka bir IoC container kullanmak istersem bu kodlamay� yapmak zorunday�m.
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .ConfigureContainer<ContainerBuilder>(builder=>
    {
        builder.RegisterModule(new AutofacBusinessModule());
    });

// Add services to the container.

builder.Services.AddControllers();

//builder.Services.AddSingleton<IProductService, ProductManager>();
//builder.Services.AddSingleton<IProductDal, EfProductDal>();


var tokenOptions = builder.Configuration.GetSection("TokenOptions").Get<TokenOptions>();

//WebApi'ye Authentication olarak JwtBearer token'� kullanaca��m�z� s�yl�yoruz.
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidIssuer = tokenOptions.Issuer,
            ValidAudience = tokenOptions.Audience,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
        };
    });


//Sadece CoreModule'� de�il ba�ka mod�lleride projeye enjekte edebilmek i�in AddDependencyResolvers() metodunu kullan�yorum.
builder.Services.AddDependencyResolvers(new ICoreModule[]
{
    new CoreModule()
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//A�a��da uygulaman�n http://localhost:3000 'dan gelen her t�rl� iste�e cevap vermesini sa�l�yoruz.
app.UseCors(builder => builder.WithOrigins("http://localhost:3000").AllowAnyHeader());

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
