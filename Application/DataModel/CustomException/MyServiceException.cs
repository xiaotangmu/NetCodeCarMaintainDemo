using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.Common;

namespace ViewModel.CustomException
{
    /// <summary>
    /// 业务错误
    /// </summary>
    public class MyServiceException: Exception
    {
        public MsgCode Code { get; set; }
        public MyServiceException(string message): base(message)
        {
            Code = MsgCode.Data_Failure;
        }
        public MyServiceException(MsgCode Code, string message) : base(message)
        {
            this.Code = Code;
        }
    }
}
