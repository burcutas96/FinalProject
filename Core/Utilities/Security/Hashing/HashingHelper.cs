using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.Hashing
{
    public class HashingHelper
    {
        public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                //Key: Kullandığımız algoritmanın o an oluşturduğu key değeridir. Dolayısıyla
                //her kullanıcı için başka bir key oluşturur.
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password)); //Hash değerini oluşturduk.
            }
        }


        //Kullanıcının girdiği password'u yine yukarıdaki algoritmayı kullanarak hashleseydik karşımıza
        //yine aynı dizin çıkar mıydı çıkmaz mıydı onu kontrol ettiğimiz metot. Yani password hashi doğrulayacağız.
        //byte[] passwordHash: veri tabanında kaydedilen hash'imiz. Bunu gelen passwordün hashi ile karşılaştıracağız. 
        public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                //Kullanıcının sisteme yeniden girdiği şifrenin hash'ini salt'layıp oluşturduk.
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
