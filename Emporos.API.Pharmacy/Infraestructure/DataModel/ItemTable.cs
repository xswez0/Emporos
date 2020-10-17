using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Emporos.API.Pharmacy.Infraestructure.DataModel
{
    public class ItemTable
    {
        public long Id { get; set; }
        public long ItemNumber { get; set; }
        public long IdVendor { get; set; }
        public string UPC { get; set; }
        public string ItemDescription { get; set; }
        public int MinimumOrderQuantity { get; set; }
        public string PurchaseUnitOfMeasure { get; set; }
        public decimal ItemCost { get; set; }
    }
}
