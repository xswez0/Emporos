using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Emporos.API.Auth.Infraestructure.DataModel
{
    public class RoleTable
    {
        public long Id { get; set; }
        public string Role { get; set; }
        public string Description { get; set; }
    }
}
