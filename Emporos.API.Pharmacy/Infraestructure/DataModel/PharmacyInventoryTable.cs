using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Emporos.API.Pharmacy.Infraestructure.DataModel
{
    public class PharmacyInventoryTable
    {
        public long Id { get; set; }
        public long IdPharmacy { get; set; }
        public long IdItem { get; set; }
        public int QuantityOnHand { get; set; }
        public decimal UnitPrice { get; set; }
        public int ReorderQuantity { get; set; }
        public string SellingUnitOfMeasure { get; set; }
    }
}
