using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Result
{
    public class DataResult<T> : Result,IDataResult<T>
    {

        public T Data { get; }

        public DataResult()
        {

        }
        public DataResult(T data,bool succes,string message):base(succes,message)
        {
            Data = data;
        }
        public DataResult(T data, bool succes) : base(succes)
        {
            Data = data;
        }


    }
}
