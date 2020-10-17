using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Emporos.API.Auth.Infraestructure.DataModel
{
    public class UserRoleTable
    {
        public UserTable User { get; set; }
        public RoleTable Role { get; set; }
    }
}
