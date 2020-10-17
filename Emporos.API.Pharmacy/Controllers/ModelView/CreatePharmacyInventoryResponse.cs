using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Emporos.API.Pharmacy.Controllers.ModelView
{
    public class CreatePharmacyInventoryResponse
    {
        public long QuantityOnHand { get; set; }
        public decimal UnitPrice { get; set; }
        public long ReorderQuantity { get; set; }
        public string SellingUnitOfMeasure { get; set; }
        public string UPC { get; set; }
        public string VendorName { get; set; }
        public string PharmacyName { get; set; }
        public string HospitalName { get; set; }
    }
}
