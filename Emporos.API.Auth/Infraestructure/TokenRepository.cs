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
    public class TokenRepository : DbFactoryBase, ITokenRepository
    {
        private readonly ILogger<TokenRepository> _logger;
        public TokenRepository(IConfiguration config, ILogger<TokenRepository> logger) : base(config)
        {
            _logger = logger;
        }

        public async Task<long> CreateAsync(TokenTable entity)
        {
            string sql = @"INSERT INTO Token (Guid, CreatedOn, ExpiresOn, AccessToken, IdUser) "+
                "VALUES (@Guid, @CreatedOn, @ExpiresOn, @AccessToken, @IdUser) " +
                "SELECT CAST(SCOPE_IDENTITY() as bigint)";

            return await DbQuerySingleAsync<long>(sql, entity);
        }

        public Task<bool> DeleteAsync(object id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistAsync(object id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TokenTable>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<TokenTable> GetByIdAsync(object id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(TokenTable entity)
        {
            throw new NotImplementedException();
        }
    }
}
