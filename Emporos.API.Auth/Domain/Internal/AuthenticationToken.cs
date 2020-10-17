using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Emporos.API.Auth.Domain.Internal
{
    public class AuthenticationToken
    {
        public DateTime ExpiresOn { get; set; }
        public string AccessToken { get; set; }
    }
}
