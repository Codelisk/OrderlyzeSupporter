using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Supporter.Foundation.Dtos.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories.Services.Providers
{
    public record DefaultRepositoryProvider(BackendContext PrintingContext, UserManager<UserDto> UserManager, IHttpContextAccessor HttpContextAccessor);
}
