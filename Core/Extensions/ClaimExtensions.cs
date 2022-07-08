using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Core.Extensions
{
    //.Net'in kendisinde önceden var olan bir nesneye, extensions sayesinde yeni bir metot ekleyebiliriz.
    public static class ClaimExtensions
    {

        //İlk parametre ile hangi sınıfın extend edileceğini söylemiş olduk.
        public static void AddEmail(this ICollection<Claim> claims, string email)
        {
            //JwtRegisteredClaimNames.Email kısmına ikinci parametredeki email'i göndermiş olduk.
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, email));
        }

        public static void AddName(this ICollection<Claim> claims, string name)
        {
            claims.Add(new Claim(ClaimTypes.Name, name));
        }

        public static void AddNameIdentifier(this ICollection<Claim> claims, string nameIdentifier)
        {
            claims.Add(new Claim(ClaimTypes.NameIdentifier, nameIdentifier));
        }

        public static void AddRoles(this ICollection<Claim> claims, string[] roles)
        {
            roles.ToList().ForEach(role => claims.Add(new Claim(ClaimTypes.Role, role)));
        }
    }
}
