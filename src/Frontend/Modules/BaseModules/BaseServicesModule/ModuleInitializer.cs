using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseServicesModule.Services.Navigation;
using BaseServicesModule.Services.Vms;
using Microsoft.Extensions.DependencyInjection;

namespace BaseServicesModule
{
    public static class ModuleInitializer
    {
        public static void AddBaseServices(IServiceCollection services) 
        {          
            services.AddScoped<INavService, NavService>();
            services.AddScoped<VmContainer>();
        }
    }
}
