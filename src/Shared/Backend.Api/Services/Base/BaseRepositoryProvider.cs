using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Api.Services.Base
{
    public class BaseRepositoryProvider : IBaseRepositoryProvider
    {
        private readonly ITokenProvider _authTokenProvider;
        private readonly IApiBuilder _apiBuilder;
        private readonly ILogger<IBaseRepositoryProvider> _logger;

        public BaseRepositoryProvider(
            IApiBuilder apiBuilder,
            ITokenProvider tokenProvider,
            ILogger<IBaseRepositoryProvider> logger)
        {
            _authTokenProvider = tokenProvider;
            _apiBuilder = apiBuilder;
            _logger = logger;
        }
        public ITokenProvider GetTokenProvider()
        {
            return _authTokenProvider;
        }
        public IApiBuilder GetApiBuilder()
        {
            return _apiBuilder;
        }
        public ILogger GetLogger()
        {
            return _logger;
        }
    }
}
