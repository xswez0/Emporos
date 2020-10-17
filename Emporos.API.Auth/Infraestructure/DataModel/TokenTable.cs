using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace Emporos.API.Auth.Infraestructure.DataModel
{
    public class TokenTable
    {
        public long Id { get; set; }
        public string Guid { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ExpiresOn { get; set; }
        public string AccessToken { get; set; }
        public long IdUser { get; set; }
    }
}
