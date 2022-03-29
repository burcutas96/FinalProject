using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        //message parametresini doldurmazsak sadece 18. satırdaki constructor çalışacak. Ama doldurursak ilk önce iki parametreli olan
        //constructor'a gidecek onu çalıştıracak daha sonra result'ın tek parametreli constructor'ına bu success'i yollayıp 18. contructor'ı çalıştıracak.
        public Result(bool success, string message) : this(success)
        {
            Message = message;
        }

        public Result(bool success)
        {
            Success = success;
        }

        public bool Success { get; }

        public string Message { get; }
    }
}
