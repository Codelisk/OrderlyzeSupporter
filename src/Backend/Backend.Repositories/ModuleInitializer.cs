using Backend.Repositories.Services.Providers;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Repositories
{
    public static partial class ModuleInitializer
    {
        public static void AddRepositoryServices(this IServiceCollection services)
        {
            services.AddScoped<DefaultRepositoryProvider>();
        }
    }
}
