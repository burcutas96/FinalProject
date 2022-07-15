using System.Security.Claims;

namespace Core.Extensions
{
    //Bir kişinin claimlerine erişmek için kullanılan .Net'de olan bir classtır.
    public static class ClaimsPrincipalExtensions
    {
        public static List<string>? Claims(this ClaimsPrincipal claimsPrincipal, string claimType) //Tek bir rolü gez
        {
            var result = claimsPrincipal?.FindAll(claimType)?.Select(x => x.Value).ToList();
            return result;
        }

        public static List<string>? ClaimRoles(this ClaimsPrincipal claimsPrincipal) //Bütün rolleri gez
        {
            return claimsPrincipal?.Claims(ClaimTypes.Role);
        }
    }
}
