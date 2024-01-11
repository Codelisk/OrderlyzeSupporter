using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseServicesModule.Services.Vms
{
    public record VmServices(IRegionManager RegionManager, VmContainer VmContainer);
}
