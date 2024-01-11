using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Api.Services.Base
{
    public interface IBaseRepositoryProvider
    {
        IApiBuilder GetApiBuilder();
        ILogger GetLogger();
        ITokenProvider GetTokenProvider();
    }
}
