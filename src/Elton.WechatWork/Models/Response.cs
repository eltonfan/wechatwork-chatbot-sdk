using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Elton.WechatWork.Models
{
    internal abstract class Response
    {
        [JsonConstructor]
        protected Response() { }

        public Response(int errorCode, string errorMessage)
        {
            this.ErrorCode = errorCode;
            this.ErrorMessage = errorMessage;
        }

        [JsonProperty("errcode")]
        public int ErrorCode { get; private set; }
        [JsonProperty("errmsg")]
        public string ErrorMessage { get; private set; }

        [JsonIgnore]
        public bool IsSuccess => ErrorCode == 0;
    }
}
