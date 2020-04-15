using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Elton.WechatWork.Models
{
    internal class GetTokenResponse : Response
    {
        [JsonConstructor]
        private GetTokenResponse() { }

        public GetTokenResponse(int errorCode, string errorMessage, string accessToken, int? expiresIn)
            : base(errorCode, errorMessage)
        {
            this.AccessToken = accessToken;
            this.ExpiresIn = expiresIn;
        }

        [JsonProperty("access_token")]
        public string AccessToken { get; private set; }

        [JsonProperty("expires_in")]
        public int? ExpiresIn { get; private set; }

        public static GetTokenResponse OK(string accessToken, int expiresIn)
        {
            return new GetTokenResponse(0, "ok", accessToken, expiresIn);
        }

        public static GetTokenResponse Error(int errorCode, string errorMessage)
        {
            return new GetTokenResponse(errorCode, errorMessage, null, null);
        }
    }
}
