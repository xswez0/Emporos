using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Emporos.API.Auth.Infraestructure.DataModel
{
    public class UserTable
    {
        public long Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public List<RoleTable> UserRoles { get; set; }
        public UserTable()
        {
            UserRoles = new List<RoleTable>();
        }
    }
}
