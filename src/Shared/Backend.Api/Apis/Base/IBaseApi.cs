using Codelisk.GeneratorAttributes.ApiAttributes;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Api.Apis.Base
{
    [BaseApi]
    [Headers("Authorization:Bearer", "Access-Control-Allow-Origin: *",
        "Accept: application/json",
        "ngrok-skip-browser-warning: 69420",
        "Accept-Language: en-us,en;q=0.5", "Accept-Encoding: gzip,deflate"
        )]

    public interface IBaseApi
    {
    }
}
