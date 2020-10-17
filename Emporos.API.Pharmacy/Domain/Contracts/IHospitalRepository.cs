using Emporos.API.Pharmacy.Infraestructure.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Emporos.API.Pharmacy.Domain.Contracts
{
    public interface IHospitalRepository : IRepository<HospitalTable>
    {
    }
}
