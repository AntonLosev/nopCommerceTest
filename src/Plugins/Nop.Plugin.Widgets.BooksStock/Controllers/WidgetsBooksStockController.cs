using System.Web.Mvc;
using Nop.Core;
using Nop.Core.Caching;
using Nop.Plugin.Widgets.BooksStock.Models;
using Nop.Services.Configuration;
using Nop.Services.Localization;
using Nop.Services.Media;
using Nop.Services.Stores;
using Nop.Web.Framework.Controllers;

namespace Nop.Plugin.Widgets.BooksStock.Controllers
{
    public class WidgetsBooksStockController : BasePluginController
    {
        private readonly IWorkContext _workContext;
        private readonly IStoreContext _storeContext;
        private readonly IStoreService _storeService;
        private readonly ISettingService _settingService;
        private readonly ILocalizationService _localizationService;

        public WidgetsBooksStockController(IWorkContext workContext,
            IStoreContext storeContext,
            IStoreService storeService, 
            IPictureService pictureService,
            ISettingService settingService,
            ICacheManager cacheManager,
            ILocalizationService localizationService)
        {
            this._workContext = workContext;
            this._storeContext = storeContext;
            this._storeService = storeService;
            this._settingService = settingService;
            this._localizationService = localizationService;
        }

     

        [AdminAuthorize]
        [ChildActionOnly]
        public ActionResult Configure()
        {
            //load settings for a chosen store scope
            var storeScope = this.GetActiveStoreScopeConfiguration(_storeService, _workContext);
            var booksStockSettings = _settingService.LoadSetting<BooksStockSettings>(storeScope);
            var model = new ConfigurationModel
            {
                InformationText = booksStockSettings.InformationText,
                ActiveStoreScopeConfiguration = storeScope
            };

            if (storeScope > 0)
            {
                model.InformationText_OverrideForStore = _settingService.SettingExists(booksStockSettings, x => x.InformationText, storeScope);
            }

            return View("~/Plugins/Widgets.BooksStock/Views/Configure.cshtml", model);
        }

        [HttpPost]
        [AdminAuthorize]
        [ChildActionOnly]
        public ActionResult Configure(ConfigurationModel model)
        {
            var storeScope = this.GetActiveStoreScopeConfiguration(_storeService, _workContext);
            var booksStockSettings = _settingService.LoadSetting<BooksStockSettings>(storeScope);

            booksStockSettings.InformationText = model.InformationText;
            
            _settingService.SaveSettingOverridablePerStore(booksStockSettings, x => x.InformationText, model.InformationText_OverrideForStore, storeScope, false);
            
            _settingService.ClearCache();

            SuccessNotification(_localizationService.GetResource("Admin.Plugins.Saved"));
            return Configure();
        }

        [ChildActionOnly]
        public ActionResult PublicInfo(string widgetZone, object additionalData = null)
        {
            var booksStockSettings = _settingService.LoadSetting<BooksStockSettings>(_storeContext.CurrentStore.Id);

            var model = new PublicInfoModel {InformationText = booksStockSettings.InformationText };
            
            return View("~/Plugins/Widgets.BooksStock/Views/PublicInfo.cshtml", model);
        }
    }
}