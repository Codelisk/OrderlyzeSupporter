using Backend.Api.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Api
{
    internal class ModuleInitializerBase
    {
        public virtual void AddApis(IServiceCollection services) { }
    }
    public static class ModuleInitializerExtension
    {
        public static void AddApi<TAuthService>(this IServiceCollection services) where TAuthService : class, IAuthenticationService
        {
            new ModuleInitializer().AddApi<TAuthService>(services);
        }
    }
    internal partial class ModuleInitializer : ModuleInitializerBase
    {
        public virtual void AddApi<TAuthService>(IServiceCollection services) where TAuthService : class, IAuthenticationService
        {
            AddApis(services);
            SetupAuthentication<TAuthService>(services);

            services.AddSingleton<IApiBuilder, ApiBuilder>();
            services.AddSingleton<IBaseRepositoryProvider, BaseRepositoryProvider>();
        }

        private void SetupAuthentication<TAuthService>(IServiceCollection services) where TAuthService : class, IAuthenticationService
        {
            services.AddSingleton<ITokenProvider, TokenProvider>();
            services.AddSingleton<IAuthRepository, AuthRepository>();
            services.AddSingleton<IAuthenticationService, TAuthService>();
        }
    }
}
