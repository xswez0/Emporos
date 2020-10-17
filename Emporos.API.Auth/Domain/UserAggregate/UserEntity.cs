using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Emporos.API.Auth.Domain.UserAggregate
{
    public class UserEntity
    {
        public long Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public List<RoleEntity> UserRoles { get; set; }
        public UserEntity()
        {
            UserRoles = new List<RoleEntity>();
        }
    }
}
