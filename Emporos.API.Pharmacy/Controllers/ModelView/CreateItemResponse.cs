﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Emporos.API.Pharmacy.Controllers.ModelView
{
    public class CreateItemResponse
    {
        public long ItemNumber { get; set; }
        public string UPC { get; set; }
        public string ItemDescription { get; set; }
        public int MinimumOrderQuantity { get; set; }
        public string PurchaseUnitOfMeasure { get; set; }
        public decimal ItemCost { get; set; }
        public string VendorName { get; set; }
    }
}
