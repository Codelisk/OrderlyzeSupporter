using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Supporter.Foundation.Dtos.Base
{
    [PrimaryKey(nameof(id))]
    public class BaseDefaultIdDto : BaseBaseIdDto
    {
        [Id]
        [Key]
        [JsonPropertyName("id")]
        public Guid id { get; set; }

        public override Guid GetId()
        {
            return id;
        }
    }
}
