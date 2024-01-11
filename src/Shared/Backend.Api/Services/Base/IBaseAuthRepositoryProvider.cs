using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Api.Services.Base
{
    internal interface IBaseAuthRepositoryProvider : IBaseRepositoryProvider
    {
        IAuthenticationService GetAuthenticationService();
    }
}
