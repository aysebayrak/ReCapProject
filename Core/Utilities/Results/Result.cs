using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {

        public Result(bool success,string message):this (success)//bu çalıstıgında allatakinide çalıstır 
        {
            Message = message;
  
        }
        public Result(bool success)//eğer mesaj vermek istemez isem
        { 
            Success = success;
        }
        //ikisinin aynı nada çalısmasına gerek yok

        public bool Success { get; }

        public string Message { get; }
    }
}
