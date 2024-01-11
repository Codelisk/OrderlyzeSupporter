using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Supporter.Foundation.Dtos.Base
{
    public class BaseUserDto : BaseDefaultIdDto
    {
        [JsonPropertyName("userId")]
        public Guid UserId { get; set; }

        public bool IsUser(object userId)
        {
            return (Guid)userId == UserId;
        }
    }
}
