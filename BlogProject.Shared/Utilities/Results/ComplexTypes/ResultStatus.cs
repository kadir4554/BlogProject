using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Shared.Utilities.Results.ComplexTypes
{
    public enum ResultStatus
    {
        Success=0,//ResultStatus.Success
        Error =1, //ResultStatus.Error
        Warning =2,//ResultStatus.Warning
        Info=3,//ResultStatus.Info
    }
}
