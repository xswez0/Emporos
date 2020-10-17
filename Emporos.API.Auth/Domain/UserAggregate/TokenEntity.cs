using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Emporos.API.Auth.Domain.UserAggregate
{
    public class TokenEntity
    {
        public long Id { get; set; }
        public string Guid { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ExpiresOn { get; set; }
        public string AccessToken { get; set; }
        public UserEntity User { get; set; }
    }
}
