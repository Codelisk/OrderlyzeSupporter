using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supporter.Foundation.Dtos
{
    public class BaseConversationPart : BaseUserDto
    {
        public string Question { get; set; }
        public string Answer { get; set; }
    }
}
