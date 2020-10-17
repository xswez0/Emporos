using Emporos.API.Pharmacy.Domain.Contracts;
using Emporos.API.Pharmacy.Infraestructure;
using Emporos.API.Pharmacy.Infraestructure.DataModel;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Emporos.API.Test
{
    public class MockPharmacyInventoryRepository : DbFactoryBase, IPharmacyInventoryRepository
    {
        private Dictionary<long, PharmacyInventoryTable> existingPharmacyInventory;
        private DataSetTest dataSetTest;
        private readonly ILogger _logger;
        public MockPharmacyInventoryRepository(IConfiguration config, ILogger logger) : base(config)
        {
            _logger = logger;
            dataSetTest = new DataSetTest();
            existingPharmacyInventory = new Dictionary<long, PharmacyInventoryTable>();
            existingPharmacyInventory.Add(1, dataSetTest.FakePharmacyInventoryTable1());
        }

        public async Task<long> CreateAsync(PharmacyInventoryTable entity)
        {
            return await Task.FromResult(1);
        }

        public Task<bool> DeleteAsync(object id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ExistAsync(object id)
        {
            return await Task.FromResult(existingPharmacyInventory.ContainsKey(Convert.ToInt64(id)));
        }

        public Task<IEnumerable<PharmacyInventoryTable>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<PharmacyInventoryTable> GetByIdAsync(object id)
        {
            return await Task.FromResult(existingPharmacyInventory.GetValueOrDefault(Convert.ToInt64(id)));
        }

        public async Task<bool> UpdateAsync(PharmacyInventoryTable entity)
        {
            return await Task.FromResult(true);
        }
    }
}
