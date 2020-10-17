using Emporos.API.Pharmacy.Common.Validators;
using FluentValidation;

namespace Emporos.API.Pharmacy.Controllers.ModelView
{
    public class CreateItemRequest
    {
        public long ItemNumber { get; set; }
        public long IdVendor { get; set; }
        public string UPC { get; set; }
        public string ItemDescription { get; set; }
        public int MinimumOrderQuantity { get; set; }
        public string PurchaseUnitOfMeasure { get; set; }
        public decimal ItemCost { get; set; }

        public class CreateItemRequestValidator : AbstractValidator<CreateItemRequest>
        {
            public CreateItemRequestValidator()
            {
                RuleFor(o => o.ItemNumber)
                    .NotEmpty().WithMessage("{PropertyName} can't be empty.")
                    .GreaterThan(0).WithMessage("{PropertyName} must be greater than zero.");
                RuleFor(o => o.IdVendor)
                    .NotEmpty().WithMessage("{PropertyName} can't be empty.");
                RuleFor(o => o.UPC)
                    .NotEmpty().WithMessage("{PropertyName} can't be empty.");
                    //.MatchUPCTwelveDigitNumber().WithMessage("{PropertyName} must have twelve digits number.");
                RuleFor(o => o.ItemDescription)
                    .NotEmpty().WithMessage("{PropertyName} can't be empty.");
                RuleFor(o => o.MinimumOrderQuantity)
                    .NotEmpty().WithMessage("{PropertyName} can't be empty.")
                    .GreaterThan(0).WithMessage("{PropertyName} must be possitive.");
                RuleFor(o => o.PurchaseUnitOfMeasure)
                    .NotEmpty().WithMessage("{PropertyName} can't be empty.");
                RuleFor(o => o.ItemCost)
                    .NotEmpty().WithMessage("{PropertyName} can't be empty.")
                    .GreaterThan(0.00M).WithMessage("{PropertyName} must be possitive.");
            }
        }
    }
}
