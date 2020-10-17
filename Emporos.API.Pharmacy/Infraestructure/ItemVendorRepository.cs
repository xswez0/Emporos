using Emporos.API.Pharmacy.Domain.Contracts;
using Emporos.API.Pharmacy.Infraestructure.DataModel;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Emporos.API.Pharmacy.Infraestructure
{
    public class ItemVendorRepository : DbFactoryBase, IItemVendorRepository
    {
        private readonly ILogger<ItemVendorRepository> _logger;
        public ItemVendorRepository(IConfiguration config, ILogger<ItemVendorRepository> logger) : base(config)
        {
            _logger = logger;
        }

        public Task<long> CreateAsync(ItemVendorTable entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(object id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ExistAsync(object id)
        {
            string sql = @"SELECT CAST(COUNT(1) AS BIT) FROM ItemVendor WHERE Id = @pId";
            return await DbQuerySingleAsync<bool>(sql, new { pId = id });
        }

        public Task<IEnumerable<ItemVendorTable>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<ItemVendorTable> GetByIdAsync(object id)
        {
            string sql = @"SELECT Id, Name, Address FROM ItemVendor WHERE Id = @pId";

            return await DbQuerySingleAsync<ItemVendorTable>(sql, new { pId = id });
        }

        public Task<bool> UpdateAsync(ItemVendorTable entity)
        {
            throw new NotImplementedException();
        }
    }
}
