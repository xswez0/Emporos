using FluentValidation;
using FluentValidation.Validators;

namespace Emporos.API.Pharmacy.Common.Validators
{
    public static class CustomValidators
    {
        public static IRuleBuilderOptions<T, string> MatchUPCTwelveDigitNumber<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder.SetValidator(new RegularExpressionValidator(@"^(?:\d{12})$"));
        }
    }
}
