using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Emporos.API.Pharmacy.Infraestructure.DataModel
{
    public class PharmacyTable
    {
        public long Id { get; set; }
        public long IdHospital { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
