using Nop.Plugin.Pages.OneStepApplyVendor.Models;
using Nop.Web.Models.Vendors;
using System.Linq;

namespace Nop.Plugin.Pages.OneStepApplyVendor.Mappers
{
    /// <summary>
    /// Maps ApplyVendorModel to OneStepApplyVendorModel and vise versa
    /// </summary>
    static class ApplyVendorModelMapper
    {
        #region utils

        /// <summary>
        /// Generic mapper for common fields
        /// </summary>
        private static T2 CopyApplyVendorModel<T1, T2>(this T1 model) where T1 : ApplyVendorModel where T2 : ApplyVendorModel, new()
        {
            return new T2
            {
                Name = model.Name,
                Email = model.Email,
                Description = model.Description,
                DisplayCaptcha = model.DisplayCaptcha,
                DisableFormInput = model.DisableFormInput,
                Result = model.Result,
                CustomProperties = model.CustomProperties.ToDictionary(i => i.Key, i => i.Value)
            };
        }

        #endregion

        /// <summary>
        /// Maps ApplyVendorModel to OneStepApplyVendorModel
        /// </summary>
        public static OneStepApplyVendorModel ToOneStepApplyVendorModel(this ApplyVendorModel model)
        {
            return model.CopyApplyVendorModel<ApplyVendorModel, OneStepApplyVendorModel>();
        }

        /// <summary>
        /// Maps OneStepApplyVendorModel to ApplyVendorModel
        /// </summary>
        public static ApplyVendorModel ToApplyVendorModel(this OneStepApplyVendorModel model)
        {
            return model.CopyApplyVendorModel<OneStepApplyVendorModel, ApplyVendorModel>();
        }
    }
}
