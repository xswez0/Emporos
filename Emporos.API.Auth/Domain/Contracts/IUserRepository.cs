using Emporos.API.Auth.Domain.Internal;
using Emporos.API.Auth.Infraestructure.DataModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Emporos.API.Auth.Domain.Contracts
{
    public interface IUserRepository : IRepository<UserTable>
    {
        public Task<UserTable> GetByLoginAsync(string Login);
    }
}
