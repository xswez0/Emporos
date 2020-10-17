using Emporos.API.Auth.Domain.Contracts;
using Emporos.API.Auth.Domain.Internal;
using Emporos.API.Auth.Infraestructure.DataModel;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Emporos.API.Auth.Infraestructure
{
    public class RoleRepository : DbFactoryBase, IRoleRepository
    {
        private readonly ILogger<RoleRepository> _logger;
        public RoleRepository(IConfiguration config, ILogger<RoleRepository> logger) : base(config)
        {
            _logger = logger;
        }
        public Task<long> CreateAsync(RoleTable entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(object id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistAsync(object id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<RoleTable>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<RoleTable> GetByIdAsync(object id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<RoleTable>> GetByLoginAsync(string Login)
        {
            string sql = "SELECT r.Id, r.Role,r.Description " +
                "FROM[User] u " +
                "INNER JOIN[UserRole] ur on ur.IdUser = u.Id " +
                "INNER JOIN[Role] r on r.Id = ur.IdRole " +
                "WHERE u.Login = @pLogin";
            
            return await DbQueryAsync<RoleTable>(sql, new { pLogin = Login });
        }

        public Task<bool> UpdateAsync(RoleTable entity)
        {
            throw new NotImplementedException();
        }
    }
}
