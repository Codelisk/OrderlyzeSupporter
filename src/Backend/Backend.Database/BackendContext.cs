using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Supporter.Foundation.Dtos.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Database
{
    [Codelisk.GeneratorAttributes.WebAttributes.Database.BaseContext]
    public partial class BackendContext : IdentityDbContext<UserDto, IdentityRole<Guid>, Guid>
    {
        public BackendContext(DbContextOptions options) : base(options)
        {
        }
    }
}
