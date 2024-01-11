
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Supporter.Foundation.Dtos.Base
{
    public abstract class BaseBaseIdDto
    {
        [GetId]
        public abstract Guid GetId();
    }
}
