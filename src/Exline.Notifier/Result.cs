using System;
using System.Collections.Generic;
using System.Text;
using Exline.Framework.Data.Models;

namespace Exline.Notifier
{
    public class Result : Result<Object>
    {
        public Result() : base()
        {
        }

        public Result(Framework.Data.Models.Result result) : base(result)
        {
        }

        public Result(Framework.Data.Models.Result<object> result) : base(result)
        {
        }
    }

    public class Result<T> : Framework.Data.Models.Result<T>
    {
        public string HelpLink { get; set; }

        public Result() : base()
        {

        }
        public Result(Result result)
        {
            Set(result.IsOk, result.Message, default(T), result.Code);
        }
        public Result(Framework.Data.Models.Result result) : this()
        {
            Set(result.IsOk, result.Message, (T)result.Data, result.Code);
        }
        public Result(Framework.Data.Models.Result<T> result) : this()
        {
            Set(result.IsOk, result.Message, result.Data, result.Code);
        }

        public void OK()
        {
            Set(true, string.Empty, (int)Framework.Net.Http.ResponseStatus.OK, string.Empty, default(T));
        }
        public void OK(T data)
        {
            Set(true, string.Empty, (int)Framework.Net.Http.ResponseStatus.OK, string.Empty, data);
        }
        public void Error()
        {
            Set(false, string.Empty, (int)Framework.Net.Http.ResponseStatus.INTERNAL_SERVER_ERROR, string.Empty, default(T));
        }
        public void Set(bool isOk, string message, int code, string helpLink = null, T data = default(T))
        {
            IsOk = isOk;
            Message = message;
            Code = code;
            HelpLink = helpLink;
            Data = data;
        }
        public void SetError(string message, int code, string helpLink = null)
        {
            Set(false, message, code, helpLink);
        }
        public void SetError(Exception ex)
        {
            Set(false, ex.Message, (int)Framework.Net.Http.ResponseStatus.INTERNAL_SERVER_ERROR, ex.HelpLink);
        }
        public void SetSucces(string message, int code)
        {
            Set(true, message, code);
        }

    }
}
