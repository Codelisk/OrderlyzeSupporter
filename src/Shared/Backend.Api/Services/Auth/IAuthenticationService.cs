using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Api.Services.Auth
{
    public interface IAuthenticationService
    {
        Task<bool> AuthenticateAndCacheTokenAsync(AuthPayload auth);
        Task<bool> RefreshAndCacheTokenAsync();
        Task<bool> RegisterAsync(string email, string password);
    }
}
