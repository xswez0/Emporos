using Emporos.API.Pharmacy.Domain.Contracts;
using Emporos.API.Pharmacy.Infraestructure.DataModel;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Emporos.API.Pharmacy.Infraestructure
{
    public class PharmacyInventoryRepository : DbFactoryBase, IPharmacyInventoryRepository
    {
        private readonly ILogger<PharmacyInventoryRepository> _logger;
        public PharmacyInventoryRepository(IConfiguration config, ILogger<PharmacyInventoryRepository> logger) : base(config)
        {
            _logger = logger;
        }
        public async Task<long> CreateAsync(PharmacyInventoryTable entity)
        {
            string sqlQuery = @"INSERT INTO PharmacyInventory (IdPharmacy, IdItem, QuantityOnHand, UnitPrice, ReorderQuantity, SellingUnitOfMeasure) " +
                "VALUES (@IdPharmacy, @IdItem, @QuantityOnHand, @UnitPrice, @ReorderQuantity, @SellingUnitOfMeasure) " +
                "SELECT CAST(SCOPE_IDENTITY() as bigint)";

            return await DbQuerySingleAsync<long>(sqlQuery, entity);
        }

        public async Task<bool> DeleteAsync(object id)
        {
            string sql = $@"IF EXISTS (SELECT 1 FROM PharmacyInventory WHERE Id = @pId) " +
                "DELETE PharmacyInventory WHERE Id = @pId";

            return await DbExecuteAsync<bool>(sql, new { pId = id });
        }

        public Task<bool> ExistAsync(object id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PharmacyInventoryTable>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<PharmacyInventoryTable> GetByIdAsync(object id)
        {
            string sql = @"SELECT Id, IdPharmacy, IdItem, QuantityOnHand, UnitPrice, ReorderQuantity, SellingUnitOfMeasure FROM PharmacyInventory WHERE Id = @pId";
            
            return await DbQuerySingleAsync<PharmacyInventoryTable>(sql, new { pId = id });
        }

        public async Task<bool> UpdateAsync(PharmacyInventoryTable entity)
        {
            string sql = $@"IF EXISTS (SELECT 1 FROM PharmacyInventory WHERE ID = @Id) " +
                "UPDATE PharmacyInventory SET IdPharmacy = @IdPharmacy, IdItem = @IdItem, QuantityOnHand = @QuantityOnHand, UnitPrice = @UnitPrice, ReorderQuantity = @ReorderQuantity, " +
                "SellingUnitOfMeasure = @SellingUnitOfMeasure " +
                "WHERE ID = @Id";

            return await DbExecuteAsync<bool>(sql, entity);
        }
    }
}
