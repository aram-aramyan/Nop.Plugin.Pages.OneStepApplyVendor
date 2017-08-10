using FluentValidation.Attributes;
using Nop.Plugin.Pages.OneStepApplyVendor.Validators;
using Nop.Web.Framework;
using Nop.Web.Models.Vendors;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Nop.Plugin.Pages.OneStepApplyVendor.Models
{
    [Validator(typeof(OneStepApplyVendorValidator))]
    public class OneStepApplyVendorModel : ApplyVendorModel
    {

        /// <summary>
        /// Название компании *
        /// </summary>
        [NopResourceDisplayName("OneStepApplyVendor.Fields.Company")]
        public string Company
        {
            get
            {
                return Name;
            }
            set
            {
                Name = value;
            }
        }

        /// <summary>
        /// Страна *
        /// </summary>
        [NopResourceDisplayName("OneStepApplyVendor.Fields.Country")]
        public int CountryId
        {
            get
            {
                return CustomProperties.ContainsKey(nameof(CountryId)) ? (int)CustomProperties[nameof(CountryId)] : 0;
            }
            set
            {
                CustomProperties[nameof(CountryId)] = value;
            }
        }

        public IList<SelectListItem> AvailableCountries
        {
            get
            {
                if (!CustomProperties.ContainsKey(nameof(AvailableCountries)))
                {
                    CustomProperties[nameof(AvailableCountries)] = new List<SelectListItem>();
                }

                return (IList<SelectListItem>)CustomProperties[nameof(AvailableCountries)];
            }
            set
            {
                CustomProperties[nameof(AvailableCountries)] = value;
            }
        }

        /// <summary>
        /// Телефон
        /// </summary>
        [NopResourceDisplayName("OneStepApplyVendor.Fields.Phone")]
        public string Phone
        {
            get
            {
                return CustomProperties.ContainsKey(nameof(Phone)) ? (string)CustomProperties[nameof(Phone)] : null;
            }
            set
            {
                CustomProperties[nameof(Phone)] = value;
            }
        }

        /// <summary>
        /// E-mail *
        /// </summary>
        [NopResourceDisplayName("OneStepApplyVendor.Fields.Mail")]
        public string Mail
        {
            get
            {
                return Email;
            }
            set
            {
                Email = value;
            }
        }

        /// <summary>
        /// Имя контактного лица
        /// </summary>
        [NopResourceDisplayName("OneStepApplyVendor.Fields.FirstName")]
        public string FirstName
        {
            get
            {
                return CustomProperties.ContainsKey(nameof(FirstName)) ? (string)CustomProperties[nameof(FirstName)] : null;
            }
            set
            {
                CustomProperties[nameof(FirstName)] = value;
            }
        }

        /// <summary>
        /// Фамилия контактного лица
        /// </summary>
        [NopResourceDisplayName("OneStepApplyVendor.Fields.LastName")]
        public string LastName
        {
            get
            {
                return CustomProperties.ContainsKey(nameof(LastName)) ? (string)CustomProperties[nameof(LastName)] : null;
            }
            set
            {
                CustomProperties[nameof(LastName)] = value;
            }
        }

        /// <summary>
        /// Сайт
        /// </summary>
        [NopResourceDisplayName("OneStepApplyVendor.Fields.WebSite")]
        public string WebSite
        {
            get
            {
                return CustomProperties.ContainsKey(nameof(WebSite)) ? (string)CustomProperties[nameof(WebSite)] : null;
            }
            set
            {
                CustomProperties[nameof(WebSite)] = value;
            }
        }

        /// <summary>
        /// Направление сотрудничества (верхний уровень каталога - чекбоксы)
        /// </summary>
        [NopResourceDisplayName("OneStepApplyVendor.Fields.Categories")]
        public IList<int> Categories
        {
            get
            {
                return CustomProperties.ContainsKey(nameof(Categories)) ? (IList<int>)CustomProperties[nameof(Categories)] : null;
            }
            set
            {
                CustomProperties[nameof(Categories)] = value;
            }
        }

        public IList<SelectListItem> AvailableCategories
        {
            get
            {
                if (!CustomProperties.ContainsKey(nameof(AvailableCategories)))
                {
                    CustomProperties[nameof(AvailableCategories)] = new List<SelectListItem>();
                }

                return (IList<SelectListItem>)CustomProperties[nameof(AvailableCategories)];
            }
            set
            {
                CustomProperties[nameof(AvailableCategories)] = value;
            }
        }

        /// <summary>
        /// Бренды которые представляете
        /// </summary>
        [NopResourceDisplayName("OneStepApplyVendor.Fields.Brands")]
        public string Brands
        {
            get
            {
                return CustomProperties.ContainsKey(nameof(Brands)) ? (string)CustomProperties[nameof(Brands)] : null;
            }
            set
            {
                CustomProperties[nameof(Brands)] = value;
            }
        }

        /// <summary>
        /// Дополнительно
        /// </summary>
        [NopResourceDisplayName("OneStepApplyVendor.Fields.AdditionalInfo")]
        public string AdditionalInfo
        {
            get
            {
                return Description;
            }
            set
            {
                Description = value;
            }
        }

    }
}
