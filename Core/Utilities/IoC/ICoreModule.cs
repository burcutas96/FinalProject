using Microsoft.Extensions.DependencyInjection;

namespace Core.Utilities.IoC
{
    //Bütün projelerimizde kullanabileceğimiz injectionları içerir.
    public interface ICoreModule
    {
        //Genel bağımlılıkları yükleyecek
        void Load(IServiceCollection serviceCollection);
    }
}
