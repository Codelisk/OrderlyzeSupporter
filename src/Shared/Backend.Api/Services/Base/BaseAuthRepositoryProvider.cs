using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Api.Services.Base
{
    internal class BaseAuthRepositoryProvider : BaseRepositoryProvider, IBaseAuthRepositoryProvider
    {
        private readonly IAuthenticationService _authenticationService;

        public BaseAuthRepositoryProvider(IApiBuilder apiBuilder, ITokenProvider tokenProvider, IAuthenticationService authenticationService, ILogger<IBaseRepositoryProvider> logger) : base(apiBuilder, tokenProvider, logger)
        {
        }
        public IAuthenticationService GetAuthenticationService()
        {
            return _authenticationService;
        }
    }
}
