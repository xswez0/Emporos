using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Emporos.API.Pharmacy.Controllers.ModelView
{
    public class UpdatePharmacyInventoryRequest
    {
        public long IdPharmacy { get; set; }
        public long IdItem { get; set; }
        public int QuantityOnHand { get; set; }
        public decimal UnitPrice { get; set; }
        public int ReorderQuantity { get; set; }
        public string SellingUnitOfMeasure { get; set; }

        public class UpdatePharmacyInventoryRequestValidator : AbstractValidator<UpdatePharmacyInventoryRequest>
        {
            public UpdatePharmacyInventoryRequestValidator()
            {
                RuleFor(o => o.IdPharmacy)
                    .NotEmpty().WithMessage("{PropertyName} can't be empty.");
                RuleFor(o => o.IdItem)
                    .NotEmpty().WithMessage("{PropertyName} can't be empty.");
                RuleFor(o => o.QuantityOnHand)
                    .NotEmpty().WithMessage("{PropertyName} can't be empty.");
                    //GreaterThan(0).WithMessage("{PropertyName} must be possitive.");
                RuleFor(o => o.UnitPrice)
                    .NotEmpty().WithMessage("{PropertyName} can't be empty.")
                    .GreaterThan(0.00M).WithMessage("{PropertyName} must be possitive.");
                RuleFor(o => o.ReorderQuantity)
                    .NotEmpty().WithMessage("{PropertyName} can't be empty.")
                    .GreaterThan(0).WithMessage("{PropertyName} must be possitive.");
                RuleFor(o => o.SellingUnitOfMeasure)
                    .NotEmpty().WithMessage("{PropertyName} can't be empty.");
            }
        }
    }
}
