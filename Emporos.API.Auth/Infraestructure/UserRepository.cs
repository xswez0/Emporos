using Emporos.API.Auth.Domain.Contracts;
using Emporos.API.Auth.Infraestructure.DataModel;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Emporos.API.Auth.Infraestructure
{
    public class UserRepository : DbFactoryBase, IUserRepository
    {
        private readonly ILogger<UserRepository> _logger;
        public UserRepository(IConfiguration config, ILogger<UserRepository> logger) : base(config)
        {
            _logger = logger;
        }

        public Task<long> CreateAsync(UserTable entity)
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

        public Task<IEnumerable<UserTable>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<UserTable> GetByIdAsync(object id)
        {
            throw new NotImplementedException();
        }

        public async Task<UserTable> GetByLoginAsync(string Login)
        {
            string sql = "SELECT Id, Login, Password, Active FROM [User] WHERE Login = @pLogin";
            return await DbQuerySingleAsync<UserTable>(sql, new { pLogin = Login });
        }

        public Task<bool> UpdateAsync(UserTable entity)
        {
            throw new NotImplementedException();
        }
    }
}
