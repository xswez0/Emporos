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
    public class MockHospitalRepository : DbFactoryBase, IHospitalRepository
    {
        private Dictionary<long, HospitalTable> existingHospital;
        private DataSetTest dataSetTest;
        private readonly ILogger _logger;
        public MockHospitalRepository(IConfiguration config, ILogger logger) : base(config)
        {
            _logger = logger;
            dataSetTest = new DataSetTest();
            existingHospital = new Dictionary<long, HospitalTable>();
            existingHospital.Add(1, dataSetTest.FakeHospitalTable1());
        }
        public Task<long> CreateAsync(HospitalTable entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(object id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ExistAsync(object id)
        {
            return await Task.FromResult(existingHospital.ContainsKey(Convert.ToInt64(id)));
        }

        public Task<IEnumerable<HospitalTable>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<HospitalTable> GetByIdAsync(object id)
        {
            return await Task.FromResult(existingHospital.GetValueOrDefault(Convert.ToInt64(id)));
        }

        public Task<bool> UpdateAsync(HospitalTable entity)
        {
            throw new NotImplementedException();
        }
    }
}
