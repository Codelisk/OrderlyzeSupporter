using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Api.Services.Auth
{
    public class TokenProvider : ITokenProvider
    {
        private string AccessToken;
        private string RefreshToken;
        public TokenProvider()
        {

        }
        public string GetCurrentAccessToken()
        {
            return AccessToken;
        }
        public string GetCurrentRefreshToken()
        {
            return RefreshToken;
        }

        public void UpdateCurrentToken(string newToken, string newRefreshToken)
        {
            AccessToken = newToken;
            RefreshToken = newRefreshToken;
        }
    }
}
