using BlogProject.Shared.Utilities.Results.Abstract;
using BlogProject.Shared.Utilities.Results.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Shared.Utilities.Results.Concrete
{
    public class DataResult<T> : Result,IDataResult<T>
    {
        public DataResult(ResultStatus resultStatus, T data):base(resultStatus)
        {
            Data = data;
        }
        public DataResult(ResultStatus resultStatus,string message, T data):base(resultStatus,message)
        {
            Data = data;
        }
        public DataResult(ResultStatus resultStatus, string message, T data,Exception exception):base(resultStatus,message,exception)
        {           
            Data = data;           
        }
        public T Data { get; }
    }
}
