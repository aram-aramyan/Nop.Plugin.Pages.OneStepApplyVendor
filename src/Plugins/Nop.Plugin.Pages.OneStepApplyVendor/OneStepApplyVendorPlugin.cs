using Nop.Core.Plugins;
using Nop.Services.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Plugin.Pages.OneStepApplyVendor
{
    public class OneStepApplyVendorPlugin : BasePlugin
    {
        public override void Install()
        {

            /*
             * OneStepApplyVendor.Fields.Company
             * OneStepApplyVendor.Fields.Country
             * OneStepApplyVendor.Fields.Phone
             * OneStepApplyVendor.Fields.Mail
             * OneStepApplyVendor.Fields.FirstName
             * OneStepApplyVendor.Fields.LastName
             * OneStepApplyVendor.Fields.WebSite
             * OneStepApplyVendor.Fields.Categories
            OneStepApplyVendor.Fields.Brands
            OneStepApplyVendor.Fields.AdditionalInfo

            OneStepApplyVendor.ApplyAccount.Company.Hint
            OneStepApplyVendor.ApplyAccount.Phone.Hint
            OneStepApplyVendor.ApplyAccount.Mail.Hint
            OneStepApplyVendor.ApplyAccount.FirstName.Hint
            OneStepApplyVendor.ApplyAccount.LastName.Hint
            OneStepApplyVendor.ApplyAccount.WebSite.Hint

            OneStepApplyVendor.ApplyAccount.Company.Required
            OneStepApplyVendor.ApplyAccount.Country.Required
            OneStepApplyVendor.ApplyAccount.Mail.Required
             */


            //locales
            this.AddOrUpdatePluginLocaleResource("OneStepApplyVendor.Fields.Company", "Company");
            this.AddOrUpdatePluginLocaleResource("OneStepApplyVendor.Fields.Country", "Country");
            this.AddOrUpdatePluginLocaleResource("OneStepApplyVendor.Fields.Phone", "Phone");
            this.AddOrUpdatePluginLocaleResource("OneStepApplyVendor.Fields.Mail", "E-mail");
            this.AddOrUpdatePluginLocaleResource("OneStepApplyVendor.Fields.FirstName", "FirstName");
            this.AddOrUpdatePluginLocaleResource("OneStepApplyVendor.Fields.LastName", "LastName");
            this.AddOrUpdatePluginLocaleResource("OneStepApplyVendor.Fields.WebSite", "WebSite");
            this.AddOrUpdatePluginLocaleResource("OneStepApplyVendor.Fields.Categories", "Categories");
            this.AddOrUpdatePluginLocaleResource("OneStepApplyVendor.Fields.Brands", "Brands");
            this.AddOrUpdatePluginLocaleResource("OneStepApplyVendor.Fields.AdditionalInfo", "Additional Info");

            this.AddOrUpdatePluginLocaleResource("OneStepApplyVendor.ApplyAccount.Company.Hint", "My Company");
            this.AddOrUpdatePluginLocaleResource("OneStepApplyVendor.ApplyAccount.Phone.Hint", "+1 234 567890");
            this.AddOrUpdatePluginLocaleResource("OneStepApplyVendor.ApplyAccount.Mail.Hint", "me@mycompany.com");
            this.AddOrUpdatePluginLocaleResource("OneStepApplyVendor.ApplyAccount.FirstName.Hint", "James");
            this.AddOrUpdatePluginLocaleResource("OneStepApplyVendor.ApplyAccount.LastName.Hint", "Bond");
            this.AddOrUpdatePluginLocaleResource("OneStepApplyVendor.ApplyAccount.WebSite.Hint", "www.mycompany.com");

            this.AddOrUpdatePluginLocaleResource("OneStepApplyVendor.ApplyAccount.Company.Required", "Company field is required!");
            this.AddOrUpdatePluginLocaleResource("OneStepApplyVendor.ApplyAccount.Country.Required", "You need to select a country!");
            this.AddOrUpdatePluginLocaleResource("OneStepApplyVendor.ApplyAccount.Mail.Required", "Provide your E-mail, please!");

            // locales ru-RU
            var ruLocale = "ru-RU";
            this.AddOrUpdatePluginLocaleResource("OneStepApplyVendor.Fields.Company", "Название компании", ruLocale);
            this.AddOrUpdatePluginLocaleResource("OneStepApplyVendor.Fields.Country", "Страна", ruLocale);
            this.AddOrUpdatePluginLocaleResource("OneStepApplyVendor.Fields.Phone", "Телефон", ruLocale);
            this.AddOrUpdatePluginLocaleResource("OneStepApplyVendor.Fields.Mail", "E-mail", ruLocale);
            this.AddOrUpdatePluginLocaleResource("OneStepApplyVendor.Fields.FirstName", "Имя контактного лица", ruLocale);
            this.AddOrUpdatePluginLocaleResource("OneStepApplyVendor.Fields.LastName", "Фамилия контактного лица", ruLocale);
            this.AddOrUpdatePluginLocaleResource("OneStepApplyVendor.Fields.WebSite", "Сайт", ruLocale);
            this.AddOrUpdatePluginLocaleResource("OneStepApplyVendor.Fields.Categories", "Направление сотрудничества", ruLocale);
            this.AddOrUpdatePluginLocaleResource("OneStepApplyVendor.Fields.Brands", "Бренды которые представляете", ruLocale);
            this.AddOrUpdatePluginLocaleResource("OneStepApplyVendor.Fields.AdditionalInfo", "Дополнительная информация", ruLocale);

            this.AddOrUpdatePluginLocaleResource("OneStepApplyVendor.ApplyAccount.Company.Hint", "ООО Моя компания", ruLocale);
            this.AddOrUpdatePluginLocaleResource("OneStepApplyVendor.ApplyAccount.Phone.Hint", "+7 234 567890", ruLocale);
            this.AddOrUpdatePluginLocaleResource("OneStepApplyVendor.ApplyAccount.Mail.Hint", "me@mycompany.com", ruLocale);
            this.AddOrUpdatePluginLocaleResource("OneStepApplyVendor.ApplyAccount.FirstName.Hint", "Иван", ruLocale);
            this.AddOrUpdatePluginLocaleResource("OneStepApplyVendor.ApplyAccount.LastName.Hint", "Иванов", ruLocale);
            this.AddOrUpdatePluginLocaleResource("OneStepApplyVendor.ApplyAccount.WebSite.Hint", "www.mycompany.com", ruLocale);

            this.AddOrUpdatePluginLocaleResource("OneStepApplyVendor.ApplyAccount.Company.Required", "Введите название компании!", ruLocale);
            this.AddOrUpdatePluginLocaleResource("OneStepApplyVendor.ApplyAccount.Country.Required", "Выберите страну!", ruLocale);
            this.AddOrUpdatePluginLocaleResource("OneStepApplyVendor.ApplyAccount.Mail.Required", "Укажите для E-mail связи!", ruLocale);


            base.Install();
        }

        public override void Uninstall()
        {

            this.DeletePluginLocaleResource("OneStepApplyVendor.Fields.Company");
            this.DeletePluginLocaleResource("OneStepApplyVendor.Fields.Country");
            this.DeletePluginLocaleResource("OneStepApplyVendor.Fields.Phone");
            this.DeletePluginLocaleResource("OneStepApplyVendor.Fields.Mail");
            this.DeletePluginLocaleResource("OneStepApplyVendor.Fields.FirstName");
            this.DeletePluginLocaleResource("OneStepApplyVendor.Fields.LastName");
            this.DeletePluginLocaleResource("OneStepApplyVendor.Fields.WebSite");
            this.DeletePluginLocaleResource("OneStepApplyVendor.Fields.Categories");
            this.DeletePluginLocaleResource("OneStepApplyVendor.Fields.Brands");
            this.DeletePluginLocaleResource("OneStepApplyVendor.Fields.AdditionalInfo");

            this.DeletePluginLocaleResource("OneStepApplyVendor.ApplyAccount.Company.Hint");
            this.DeletePluginLocaleResource("OneStepApplyVendor.ApplyAccount.Phone.Hint");
            this.DeletePluginLocaleResource("OneStepApplyVendor.ApplyAccount.Mail.Hint");
            this.DeletePluginLocaleResource("OneStepApplyVendor.ApplyAccount.FirstName.Hint");
            this.DeletePluginLocaleResource("OneStepApplyVendor.ApplyAccount.LastName.Hint");
            this.DeletePluginLocaleResource("OneStepApplyVendor.ApplyAccount.WebSite.Hint");

            this.DeletePluginLocaleResource("OneStepApplyVendor.ApplyAccount.Company.Required");
            this.DeletePluginLocaleResource("OneStepApplyVendor.ApplyAccount.Country.Required");
            this.DeletePluginLocaleResource("OneStepApplyVendor.ApplyAccount.Mail.Required");

            base.Uninstall();
        }
    }
}
