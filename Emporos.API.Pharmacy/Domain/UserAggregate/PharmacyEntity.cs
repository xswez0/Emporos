using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Emporos.API.Pharmacy.Domain.UserAggregate
{
    public class PharmacyEntity : BaseEntity
    {
        public long Id { get; set; }
        public HospitalEntity Hospital { get; set; }
    }
}
