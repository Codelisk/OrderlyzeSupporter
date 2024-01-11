using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supporter.Foundation.Dtos.Base
{
    public interface ICreatedAt
    {
        /// <summary>
        /// When dto was created
        /// </summary>
        DateTime CreatedAt { get; set; }
    }
}
