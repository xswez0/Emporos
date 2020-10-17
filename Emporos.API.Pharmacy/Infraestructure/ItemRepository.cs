using Emporos.API.Pharmacy.Domain.Contracts;
using Emporos.API.Pharmacy.Infraestructure.DataModel;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Emporos.API.Pharmacy.Infraestructure
{
    public class ItemRepository : DbFactoryBase, IItemRepository
    {
        private readonly ILogger<ItemRepository> _logger;
        public ItemRepository(IConfiguration config, ILogger<ItemRepository> logger) : base(config)
        {
            _logger = logger;
        }

        public async Task<long> CreateAsync(ItemTable entity)
        {
            string sqlQuery = @"INSERT INTO Item (ItemNumber, IdVendor, UPC, ItemDescription, MinimumOrderQuantity, PurchaseUnitOfMeasure, ItemCost) " +
                "VALUES (@ItemNumber, @IdVendor, @UPC, @ItemDescription, @MinimumOrderQuantity, @PurchaseUnitOfMeasure, @ItemCost) " +
                "SELECT CAST(SCOPE_IDENTITY() as bigint)";

            return await DbQuerySingleAsync<long>(sqlQuery, entity);
        }

        public Task<bool> DeleteAsync(object id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ExistAsync(object id)
        {
            string sql = @"SELECT CAST(COUNT(1) AS BIT) FROM Item WHERE Id = @pId";
            return await DbQuerySingleAsync<bool>(sql, new { pId = id });
        }

        public Task<IEnumerable<ItemTable>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<ItemTable> GetByIdAsync(object id)
        {
            string sql = @"SELECT Id, ItemNumber, IdVendor, UPC, ItemDescription, MinimumOrderQuantity, PurchaseUnitOfMeasure, ItemCost FROM Item WHERE Id = @pId";

            return await DbQuerySingleAsync<ItemTable>(sql, new { pId = id });
        }

        public async Task<bool> UpdateAsync(ItemTable entity)
        {
            string sql = $@"IF EXISTS (SELECT 1 FROM Item WHERE ID = @Id) "+
                "UPDATE Item SET ItemNumber = @ItemNumber, IdVendor = @IdVendor, UPC = @UPC, ItemDescription = @ItemDescription, MinimumOrderQuantity = @MinimumOrderQuantity, "+
                "PurchaseUnitOfMeasure = @PurchaseUnitOfMeasure, ItemCost = @ItemCost " +
                "WHERE ID = @Id";

            return await DbExecuteAsync<bool>(sql, entity);
        }
    }
}
