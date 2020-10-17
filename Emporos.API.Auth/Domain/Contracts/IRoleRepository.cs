using Emporos.API.Auth.Infraestructure.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Emporos.API.Auth.Domain.Contracts
{
    public interface IRoleRepository : IRepository<RoleTable>
    {
        public Task<IEnumerable<RoleTable>> GetByLoginAsync(string Login);
    }
}
