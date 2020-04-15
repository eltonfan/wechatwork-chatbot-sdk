using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Elton.WechatWork.Models.Webhooks
{
    internal class WebhookResponse : Response
    {
        [JsonConstructor]
        protected WebhookResponse() { }

        public WebhookResponse(int errorCode, string errorMessage)
            : base(errorCode, errorMessage)
        {
        }
    }
}
