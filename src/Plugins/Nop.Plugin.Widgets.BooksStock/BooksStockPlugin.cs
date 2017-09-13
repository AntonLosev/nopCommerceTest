using Nop.Core.Plugins;
using Nop.Services.Cms;
using System.Collections.Generic;
using System.Web.Routing;
using Nop.Services.Configuration;
using Nop.Services.Localization;

namespace Nop.Plugin.Widgets.BooksStock
{
    public class BooksStockPlugin : BasePlugin, IWidgetPlugin
    {
        private readonly ISettingService _settingService;
        public BooksStockPlugin(ISettingService settingService)
        {
            this._settingService = settingService;
        }

        public IList<string> GetWidgetZones()
        {
            // return new List<string>() { "head_html_tag", "body_start_html_tag_after", "header", "header_selectors", "left_side_column_before", "left_side_column_after_category_navigation", "left_side_column_after", "main_column_before", "content_before", "content_after", "main_column_after", "right_side_column_before", "right_side_column_after", "footer", "body_end_html_tag_before" };

            return new List<string> { "productdetails_top" };

        }

        public void GetDisplayWidgetRoute(
            string widgetZone, 
            out string actionName, 
            out string controllerName,
            out RouteValueDictionary routeValues)
        {

            actionName = "PublicInfo";
            controllerName = "WidgetsBooksStock";
            routeValues = new RouteValueDictionary
            {
                {"Namespaces", "Nop.Plugin.Widgets.BooksStock.Controllers"},
                {"area", null},
                {"widgetZone", widgetZone}
            };
        }

        public void GetConfigurationRoute(
            out string actionName, 
            out string controllerName,
            out RouteValueDictionary routeValues)
        {
            actionName = "Configure";
            controllerName = "WidgetsBooksStock";
            routeValues = new RouteValueDictionary
            {
                {"Namespaces", "Nop.Plugin.Widgets.BooksStock.Controllers"},
                {"area", null}
            };

        }

        public override void Install()
        {
            //settings
            var settings = new BooksStockSettings
            {
                InformationText = "Test Text",

            };
            _settingService.SaveSetting(settings);

            this.AddOrUpdatePluginLocaleResource("Plugins.Widgets.BooksStock.InformationText", "Text 1");
            this.AddOrUpdatePluginLocaleResource("Plugins.Widgets.BooksStock.TextId", "IdId 1");
           
            base.Install();
        }

        public override void Uninstall()
        {
            //settings
            _settingService.DeleteSetting<BooksStockSettings>();

            //locales
            this.DeletePluginLocaleResource("Plugins.Widgets.BooksStock.InformationText");
            this.DeletePluginLocaleResource("Plugins.Widgets.BooksStock.TextId");
            
            base.Uninstall();
        }
    }
}
