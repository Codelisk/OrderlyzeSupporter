using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Api.Models.Auth
{
    public class AuthResult
    {
        public required string tokenType { get; set; }
        public required string accessToken { get; set; }
        public required int expiresIn { get; set; }
        public required string refreshToken { get; set; }
    }
}
