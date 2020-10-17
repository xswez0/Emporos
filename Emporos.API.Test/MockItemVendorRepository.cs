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
    public class MockItemVendorRepository : DbFactoryBase, IItemVendorRepository
    {
        private Dictionary<long, ItemVendorTable> existingVendors;
        private DataSetTest dataSetTest;
        private readonly ILogger _logger;
        public MockItemVendorRepository(IConfiguration config, ILogger logger) : base(config)
        {
            _logger = logger;
            dataSetTest = new DataSetTest();
            existingVendors = new Dictionary<long, ItemVendorTable>();
            existingVendors.Add(1, dataSetTest.FakeItemVendorTable1());
            existingVendors.Add(2, dataSetTest.FakeItemVendorTable2());
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
            return await Task.FromResult(existingVendors.ContainsKey(Convert.ToInt64(id)));
        }

        public Task<IEnumerable<ItemVendorTable>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<ItemVendorTable> GetByIdAsync(object id)
        {
            return await Task.FromResult(existingVendors.GetValueOrDefault(Convert.ToInt64(id)));
        }

        public Task<bool> UpdateAsync(ItemVendorTable entity)
        {
            throw new NotImplementedException();
        }
    }
}
