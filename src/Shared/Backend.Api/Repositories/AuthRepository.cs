using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Api.Repositories
{
    internal class AuthRepository : BaseRepository<IAuthApi>, IAuthRepository
    {
        public AuthRepository(IBaseRepositoryProvider baseRepositoryProvider) : base(baseRepositoryProvider)
        {
        }
        public async Task<AuthResult> RegisterAndLoginAsync(AuthPayload request)
        {
            await RegisterAsync(request);
            return await LoginAsync(request);
        }
        public Task RegisterAsync(AuthPayload request) => TryRequest(() => _repositoryApi.Register(request));
        public Task<AuthResult> LoginAsync(AuthPayload request) => TryRequest(() => _repositoryApi.Login(request));
        public Task<AuthResult> RefreshAsync(string refreshToken) => TryRequest(() => _repositoryApi.Refresh(refreshToken));
    }
}