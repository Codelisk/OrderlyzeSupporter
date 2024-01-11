using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Api.Services.Auth
{
    public interface ITokenProvider
    {
        string GetCurrentAccessToken();
        string GetCurrentRefreshToken();
        void UpdateCurrentToken(string newToken, string newRefreshToken);
    }
}
