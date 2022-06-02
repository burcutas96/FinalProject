﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    //Temel voidler için kullanılacak
    public interface IResult
    {
        //success ve message'ın değerlerini constructor'da vericez.
        bool Success { get; }  
        string Message { get; } 
    }
}
