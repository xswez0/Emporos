using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Emporos.API.Pharmacy.Domain.UserAggregate
{
    public class ItemEntity
    {
        public long Id { get; set; }
        public long ItemNumber { get; set; }
        public ItemVendorEntity Vendor { get; set; }
        public string UPC { get; set; }
        public string ItemDescription { get; set; }
        public int MinimumOrderQuantity { get; set; }
        public string PurchaseUnitOfMeasure { get; set; }
        public decimal ItemCost { get; set; }
    }
}
