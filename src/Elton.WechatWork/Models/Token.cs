using Elton.WechatWork.JsonConverters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Elton.WechatWork.Models
{
    public class Token
    {
        [JsonConstructor]
        private Token() { }

        public Token(string accessToken, int expiresIn, DateTime? timestamp = null)
        {
            this.AccessToken = accessToken;
            this.ExpiresIn = expiresIn;

            this.Timestamp = timestamp ?? DateTime.Now;
        }

        [JsonProperty("access_token")]
        public string AccessToken { get; private set; }

        [JsonProperty("expires_in")]
        public int ExpiresIn { get; private set; }

        [JsonProperty("timestamp"), JsonConverter(typeof(DateFormatConverter), "yyyy-MM-ddTHH:mm:ss.fff")]
        public DateTime Timestamp { get; private set; }
    }
}
