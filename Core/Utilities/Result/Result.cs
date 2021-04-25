using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Result
{
    public class Result : IResult
    {
        public Result()
        {

        }
        public Result(bool success)
        {
            Succes = success;
        }
        public Result(bool success,string message):this(success)
        {
            Message = message;
            
        }

        public bool Succes { get; }

        public string Message { get; }
    }
}
