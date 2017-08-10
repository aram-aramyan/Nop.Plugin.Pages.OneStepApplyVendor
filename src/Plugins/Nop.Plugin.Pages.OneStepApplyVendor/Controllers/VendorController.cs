using System.Web.Mvc;
using Nop.Core;
using Nop.Core.Domain.Localization;
using Nop.Core.Domain.Vendors;
using Nop.Services.Customers;
using Nop.Services.Localization;
using Nop.Services.Media;
using Nop.Services.Messages;
using Nop.Services.Seo;
using Nop.Services.Vendors;
using Nop.Web.Factories;
using Nop.Web.Framework.Security.Captcha;
using Nop.Web.Framework.Security;
using Nop.Web.Models.Vendors;
using System.Web;
using System;
using Nop.Plugin.Pages.OneStepApplyVendor.Models;
using Nop.Plugin.Pages.OneStepApplyVendor.Mappers;
using Nop.Core.Domain.Customers;
using Nop.Services.Directory;
using Nop.Services.Catalog;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Nop.Plugin.Pages.OneStepApplyVendor.Utils;
using Nop.Web.Framework;

namespace Nop.Plugin.Pages.OneStepApplyVendor.Controllers
{
    public class VendorController : Nop.Web.Controllers.VendorController
    {
        #region Fields

        private readonly IVendorModelFactory _vendorModelFactory;
        private readonly IWorkContext _workContext;
        private readonly ILocalizationService _localizationService;
        private readonly ICustomerService _customerService;
        private readonly IWorkflowMessageService _workflowMessageService;
        private readonly IVendorService _vendorService;
        private readonly IUrlRecordService _urlRecordService;
        private readonly IPictureService _pictureService;

        private readonly LocalizationSettings _localizationSettings;
        private readonly VendorSettings _vendorSettings;
        private readonly CaptchaSettings _captchaSettings;

        private readonly ICountryService _countryService;
        private readonly ICategoryService _categoryService;
        private readonly ICatalogModelFactory _catalogModelFactory;

        #endregion

        #region Constructors

        public VendorController(IVendorModelFactory vendorModelFactory, IWorkContext workContext, ILocalizationService localizationService,
            ICustomerService customerService, IWorkflowMessageService workflowMessageService, IVendorService vendorService,
            IUrlRecordService urlRecordService, IPictureService pictureService,
            LocalizationSettings localizationSettings, VendorSettings vendorSettings, CaptchaSettings captchaSettings,
            ICountryService countryService, ICategoryService categoryService, ICatalogModelFactory catalogModelFactory)
            : base(vendorModelFactory, workContext, localizationService, customerService, workflowMessageService, vendorService,
                  urlRecordService, pictureService,
                  localizationSettings, vendorSettings, captchaSettings)
        {
            _vendorModelFactory = vendorModelFactory;
            _workContext = workContext;
            _localizationService = localizationService;
            _customerService = customerService;
            _workflowMessageService = workflowMessageService;
            _vendorService = vendorService;
            _urlRecordService = urlRecordService;
            _pictureService = pictureService;

            _localizationSettings = localizationSettings;
            _vendorSettings = vendorSettings;
            _captchaSettings = captchaSettings;

            _countryService = countryService;
            _categoryService = categoryService;
            _catalogModelFactory = catalogModelFactory;
        }

        #endregion

        [NopHttpsRequirement(SslRequirement.Yes)]
        public override ActionResult ApplyVendor()
        {
            if (!_vendorSettings.AllowCustomersToApplyForVendorAccount)
                return RedirectToRoute("HomePage");

            var model = new OneStepApplyVendorModel().ToApplyVendorModel();
            model = _vendorModelFactory.PrepareApplyVendorModel(model, true, false);
            return ViewApplyVendor(model);
        }

        [HttpPost, ActionName("ApplyVendor")]
        [PublicAntiForgery]
        [CaptchaValidator]
        public ActionResult OneStepApplyVendorSubmit(OneStepApplyVendorModel model, bool captchaValid, HttpPostedFileBase uploadedFile)
        {
            if (!_vendorSettings.AllowCustomersToApplyForVendorAccount)
                return RedirectToRoute("HomePage");

            //validate CAPTCHA
            if (_captchaSettings.Enabled && _captchaSettings.ShowOnApplyVendorPage && !captchaValid)
            {
                ModelState.AddModelError("", _captchaSettings.GetWrongCaptchaMessage(_localizationService));
            }

            if (!_workContext.CurrentCustomer.IsRegistered())
            {
                //TODO: validate and create Customer
            }

            var applyVendorModel = model.ToApplyVendorModel();


            if (ModelState.IsValid)
            {
                var sbDescription = new StringBuilder();

                sbDescription.AppendFormat("{0}: {1} \n<br>", GetFieldDisplayName(nameof(OneStepApplyVendorModel.Company)), model.Company);
                sbDescription.AppendFormat("{0}: {1} \n<br>", GetFieldDisplayName(nameof(OneStepApplyVendorModel.CountryId)), GetCountryName(model.CountryId));
                sbDescription.AppendFormat("{0}: {1} \n<br>", GetFieldDisplayName(nameof(OneStepApplyVendorModel.Phone)), model.Phone);
                sbDescription.AppendFormat("{0}: {1} \n<br>", GetFieldDisplayName(nameof(OneStepApplyVendorModel.Mail)), model.Mail);
                sbDescription.AppendFormat("{0}: {1} \n<br>", GetFieldDisplayName(nameof(OneStepApplyVendorModel.FirstName)), model.FirstName);
                sbDescription.AppendFormat("{0}: {1} \n<br>", GetFieldDisplayName(nameof(OneStepApplyVendorModel.LastName)), model.LastName);
                sbDescription.AppendFormat("{0}: {1} \n<br>", GetFieldDisplayName(nameof(OneStepApplyVendorModel.WebSite)), model.WebSite);
                sbDescription.AppendFormat("{0}: {1} \n<br>", GetFieldDisplayName(nameof(OneStepApplyVendorModel.Categories)), GetCategoriesNames(model.Categories));
                sbDescription.AppendFormat("{0}: {1} \n<br>", GetFieldDisplayName(nameof(OneStepApplyVendorModel.Brands)), model.Brands);
                sbDescription.AppendFormat("{0}: {1} \n<br>", GetFieldDisplayName(nameof(OneStepApplyVendorModel.AdditionalInfo)), model.AdditionalInfo);

                var description = Core.Html.HtmlHelper.FormatText(sbDescription.ToString(), false, false, true, false, false, false);
                //disabled by default
                var vendor = new Vendor
                {
                    Name = applyVendorModel.Name,
                    Email = applyVendorModel.Email,
                    //some default settings
                    PageSize = 6,
                    AllowCustomersToSelectPageSize = true,
                    PageSizeOptions = _vendorSettings.DefaultVendorPageSizeOptions,
                    PictureId = 0,
                    Description = description
                    // TODO: add custom fields
                };
                _vendorService.InsertVendor(vendor);
                //search engine name (the same as vendor name)
                var seName = vendor.ValidateSeName(vendor.Name, vendor.Name, true);
                _urlRecordService.SaveSlug(vendor, seName, 0);

                if (_workContext.CurrentCustomer.IsRegistered())
                {
                    //associate to the current customer
                    //but a store owner will have to manually add this customer role to "Vendors" role
                    //if he wants to grant access to admin area
                    _workContext.CurrentCustomer.VendorId = vendor.Id;
                    _customerService.UpdateCustomer(_workContext.CurrentCustomer);
                }

                //notify store owner here (email)
                _workflowMessageService.SendNewVendorAccountApplyStoreOwnerNotification(_workContext.CurrentCustomer,
                    vendor, _localizationSettings.DefaultAdminLanguageId);

                applyVendorModel.DisableFormInput = true;
                applyVendorModel.Result = _localizationService.GetResource("Vendors.ApplyAccount.Submitted");
                return ViewApplyVendor(applyVendorModel);
            }

            //If we got this far, something failed, redisplay form
            applyVendorModel = _vendorModelFactory.PrepareApplyVendorModel(applyVendorModel, false, true);
            return ViewApplyVendor(applyVendorModel);
        }

        [NonAction]
        public override ActionResult ApplyVendorSubmit(ApplyVendorModel model, bool captchaValid, HttpPostedFileBase uploadedFile)
        {
            return base.ApplyVendorSubmit(model, captchaValid, uploadedFile);
        }

        private ActionResult ViewApplyVendor(ApplyVendorModel applyVendorModel)
        {
            var model = applyVendorModel.ToOneStepApplyVendorModel();
            SetContries(model);
            SetCategories(model);
            return View("OneStepApplyVendor", model);
        }

        private void SetContries(OneStepApplyVendorModel model)
        {
            if (model.AvailableCountries.Count > 0)
                return;

            model.AvailableCountries.Add(new SelectListItem { Text = _localizationService.GetResource("Address.SelectCountry"), Value = "0" });

            foreach (var c in _countryService.GetAllCountries(_workContext.WorkingLanguage.Id))
            {
                model.AvailableCountries.Add(new SelectListItem
                {
                    Text = c.GetLocalized(x => x.Name),
                    Value = c.Id.ToString(),
                    Selected = c.Id == model.CountryId
                });
            }
        }

        private string GetCountryName(int countryId)
        {
            return _countryService.GetCountryById(countryId).GetLocalized(x => x.Name);
        }

        private void SetCategories(OneStepApplyVendorModel model)
        {
            if (model.AvailableCategories.Count > 0)
                return;

            foreach (var c in _catalogModelFactory.PrepareCategorySimpleModels())
            {
                model.AvailableCategories.Add(new SelectListItem
                {
                    Text = c.Name,
                    Value = c.Id.ToString(),
                    Selected = false
                });
            }
        }

        private string GetCategoriesNames(IList<int> categoryIds)
        {
            var selectedCategoriesNames = _catalogModelFactory
                .PrepareCategorySimpleModels()
                .Where(c => categoryIds.Contains(c.Id))
                .Select(c => c.Name);

            return string.Join(", ", selectedCategoriesNames);
        }

        private string GetFieldDisplayName(string field)
        {
            return AttributeUtil.GetAttributeValue(
                    typeof(OneStepApplyVendorModel),
                    field,
                    typeof(NopResourceDisplayName),
                    nameof(NopResourceDisplayName.DisplayName)
                    ).ToString();
        }

    }
}
