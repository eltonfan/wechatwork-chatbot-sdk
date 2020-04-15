using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Elton.WechatWork.Models
{
    internal class SendResponse
    {
        [JsonConstructor]
        private SendResponse() { }

        public SendResponse(int errorCode, string errorMessage)
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
