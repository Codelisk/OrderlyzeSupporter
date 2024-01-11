using Backend.Api.Apis.Base;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Api.Apis
{
    public partial interface IAuthApi : IBaseApi
    {
        [Post("/login")]
        Task<AuthResult> Login([Body] AuthPayload request);
        [Post("/register")]
        Task<AuthResult> Register([Body] AuthPayload request);
        [Post("/refresh")]
        Task<AuthResult> Refresh([Body] string refreshToken);
    }

}
