using Emporos.API.Pharmacy.Domain.Contracts;
using Emporos.API.Pharmacy.Infraestructure;
using Emporos.API.Pharmacy.Infraestructure.DataModel;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Emporos.API.Test
{
    public class MockItemRepository : DbFactoryBase, IItemRepository
    {
        private Dictionary<long, ItemTable> existingItems;
        private DataSetTest dataSetTest;

        private readonly ILogger _logger;
        public MockItemRepository(IConfiguration config, ILogger logger) : base(config)
        {
            _logger = logger;
            dataSetTest = new DataSetTest();
            existingItems = new Dictionary<long, ItemTable>();
            existingItems.Add(1, dataSetTest.FakeItemTable1());
        }
        public Task<long> CreateAsync(ItemTable entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(object id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ExistAsync(object id)
        {
            return await Task.FromResult(existingItems.ContainsKey(Convert.ToInt64(id)));
        }

        public Task<IEnumerable<ItemTable>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<ItemTable> GetByIdAsync(object id)
        {
            return await Task.FromResult(existingItems.GetValueOrDefault(Convert.ToInt64(id)));
        }

        public Task<bool> UpdateAsync(ItemTable entity)
        {
            throw new NotImplementedException();
        }
    }
}
