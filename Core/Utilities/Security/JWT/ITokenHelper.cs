using Core.Entities.Concrete;

namespace Core.Utilities.Security.JWT
{
    //Token'ın bir interface'ini oluşturmamızın sebebi: Mesela test yaparken test
    //amaçlı bir token oluşturabiliriz ya da bu token'ı başka bir araçla üretmek isteyebiliriz.
    public interface ITokenHelper
    {   
        //Kullanıcının rollerini de token'a eklenmesini istiyoruz.
        AccessToken CreateToken(User user, List<OperationClaim> operationClaims);
    }
}
