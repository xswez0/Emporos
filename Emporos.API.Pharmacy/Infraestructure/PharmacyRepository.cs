using Emporos.API.Pharmacy.Domain.Contracts;
using Emporos.API.Pharmacy.Infraestructure.DataModel;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Emporos.API.Pharmacy.Infraestructure
{
    public class PharmacyRepository : DbFactoryBase, IPharmacyRepository
    {
        private readonly ILogger<PharmacyRepository> _logger;
        public PharmacyRepository(IConfiguration config, ILogger<PharmacyRepository> logger) : base(config)
        {
            _logger = logger;
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
            string sql = @"SELECT CAST(COUNT(1) AS BIT) FROM Pharmacy WHERE Id = @pId";
            return await DbQuerySingleAsync<bool>(sql, new { pId = id });
        }

        public Task<IEnumerable<PharmacyTable>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<PharmacyTable> GetByIdAsync(object id)
        {
            string sql = @"SELECT Id, IdHospital, Name, Address FROM Pharmacy WHERE Id = @pId";

            return await DbQuerySingleAsync<PharmacyTable>(sql, new { pId = id });
        }

        public Task<bool> UpdateAsync(PharmacyTable entity)
        {
            throw new NotImplementedException();
        }
    }
}
