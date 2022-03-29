using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public interface IDataResult<T> : IResult
    {
        //IDataResult bir interface olduğu için IResult'ı implement etmeyiz.Arka planda şöyle bir görüntü oluşur:
        //bool Success { get; }  
        //string Message { get; }
         
        T Data { get; }
    }
}
