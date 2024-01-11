using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Api.Services.Base
{
    public interface IApiBuilder
    {
        TApi BuildRestService<TApi>(Func<HttpRequestMessage, CancellationToken, Task<string>>? AuthorizationHeaderValueGetter = null);
        string GetRestUrl();
    }
}
