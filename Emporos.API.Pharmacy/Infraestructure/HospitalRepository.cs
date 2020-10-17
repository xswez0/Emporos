using Emporos.API.Pharmacy.Domain.Contracts;
using Emporos.API.Pharmacy.Infraestructure.DataModel;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Emporos.API.Pharmacy.Infraestructure
{
    public class HospitalRepository : DbFactoryBase, IHospitalRepository
    {
        private readonly ILogger<HospitalRepository> _logger;
        public HospitalRepository(IConfiguration config, ILogger<HospitalRepository> logger) : base(config)
        {
            _logger = logger;
        }
        public Task<long> CreateAsync(HospitalTable entity)
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

        public Task<IEnumerable<HospitalTable>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<HospitalTable> GetByIdAsync(object id)
        {
            string sql = @"SELECT Id, Name, Address FROM Hospital WHERE Id = @pId";

            return await DbQuerySingleAsync<HospitalTable>(sql, new { pId = id });
        }

        public Task<bool> UpdateAsync(HospitalTable entity)
        {
            throw new NotImplementedException();
        }
    }
}
