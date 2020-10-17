using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Emporos.API.Pharmacy.Domain.UserAggregate
{
    public class PharmacyInventoryEntity
    {
        public long Id { get; set; }
        public PharmacyEntity Pharmacy { get; set; }
        public ItemEntity Item { get; set; }
        public int QuantityOnHand { get; set; }
        public decimal UnitPrice { get; set; }
        public int ReorderQuantity { get; set; }
        public string SellingUnitOfMeasure { get; set; }
    }
}
