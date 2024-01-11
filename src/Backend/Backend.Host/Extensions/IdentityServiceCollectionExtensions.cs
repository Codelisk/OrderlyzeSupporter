using Backend.Database;
using Microsoft.AspNetCore.Identity;
using Supporter.Foundation.Dtos.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Host.Extensions
{
    public static class IdentityServiceCollectionExtensions
    {
        public static void AddIdentity(this IServiceCollection services)
        {
            services.AddIdentityCore<UserDto>()
                .AddEntityFrameworkStores<BackendContext>()
                .AddApiEndpoints();

            services.AddAuthentication()
                .AddBearerToken(IdentityConstants.BearerScheme);
            services.AddAuthorizationBuilder();
        }

        public static void AddIdentity(this WebApplication app)
        {
            app.MapIdentityApi<UserDto>();
        }
    }
}
