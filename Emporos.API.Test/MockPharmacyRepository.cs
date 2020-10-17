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
    public class MockPharmacyRepository : DbFactoryBase, IPharmacyRepository
    {
        private Dictionary<long, PharmacyTable> existingPharmacies;
        private DataSetTest dataSetTest;

        private readonly ILogger _logger;
        public MockPharmacyRepository(IConfiguration config, ILogger logger) : base(config)
        {
            _logger = logger;
            dataSetTest = new DataSetTest();
            existingPharmacies = new Dictionary<long, PharmacyTable>();
            existingPharmacies.Add(1, dataSetTest.FakePharmacyTable1());
        }

        public Task<long> CreateAsync(PharmacyTable entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(object id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ExistAsync(object id)
        {
            return await Task.FromResult(existingPharmacies.ContainsKey(Convert.ToInt64(id)));
        }

        public Task<IEnumerable<PharmacyTable>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<PharmacyTable> GetByIdAsync(object id)
        {
            return await Task.FromResult(existingPharmacies.GetValueOrDefault(Convert.ToInt64(id)));
        }

        public Task<bool> UpdateAsync(PharmacyTable entity)
        {
            throw new NotImplementedException();
        }
    }
}
