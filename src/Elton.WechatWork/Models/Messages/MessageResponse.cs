using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Elton.WechatWork.Models.Messages
{
    internal class MessageResponse : Response
    {
        [JsonConstructor]
        private MessageResponse() { }

        public MessageResponse(int errorCode, string errorMessage, string invaliduser, string invalidparty, string invalidtag)
            : base(errorCode, errorMessage)
        {
            this.invaliduser = invaliduser;
            this.invalidparty = invalidparty;
            this.invalidtag = invalidtag;
        }

        [JsonProperty("invaliduser")]
        public string invaliduser { get; private set; }


        [JsonProperty("invalidparty")]
        public string invalidparty { get; private set; }


        [JsonProperty("invalidtag")]
        public string invalidtag { get; private set; }

        public static MessageResponse OK(string invaliduser, string invalidparty, string invalidtag)
        {
            return new MessageResponse(0, "ok", invaliduser, invalidparty, invalidtag);
        }

        public static MessageResponse Error(int errorCode, string errorMessage)
        {
            return new MessageResponse(errorCode, errorMessage, null, null, null);
        }
    }
}
