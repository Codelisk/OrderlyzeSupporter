using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supporter.Foundation.Dtos.User
{
    public class UserDto : IdentityUser<Guid>
    {
    }
}
