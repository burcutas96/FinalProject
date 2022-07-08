using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
