using Microsoft.IdentityModel.Tokens;

namespace Core.Utilities.Security.Encryption
{
    //Asp.Net'e hangi anahtarı ve algoritmayı kullanacağımızı söylediğimiz yer.
    public class SigningCredentialsHelper
    {
        public static SigningCredentials CreateSigningCredentials(SecurityKey securityKey)
        {
            return new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);
        }
    }
}
