using FluentValidation;
using Nop.Plugin.Pages.OneStepApplyVendor.Models;
using Nop.Services.Localization;
using Nop.Web.Framework.Validators;

namespace Nop.Plugin.Pages.OneStepApplyVendor.Validators
{
    public partial class OneStepApplyVendorValidator : BaseNopValidator<OneStepApplyVendorModel>
    {
        public OneStepApplyVendorValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.Company).NotEmpty().WithMessage(localizationService.GetResource("OneStepApplyVendor.ApplyAccount.Company.Required"));
            RuleFor(x => x.CountryId).NotEqual(0).WithMessage(localizationService.GetResource("OneStepApplyVendor.ApplyAccount.Country.Required"));

            RuleFor(x => x.Mail).NotEmpty().WithMessage(localizationService.GetResource("OneStepApplyVendor.ApplyAccount.Mail.Required"));
            RuleFor(x => x.Mail).EmailAddress().WithMessage(localizationService.GetResource("Common.WrongEmail"));
        }
    }
}
