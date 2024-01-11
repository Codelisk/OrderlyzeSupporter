using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supporter.Foundation.Dtos.Base
{
    public class BaseDtoWithName : BaseDefaultIdDto
    {
        public required string Name { get; set; }
    }
}
