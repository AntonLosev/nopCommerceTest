using System.Web.Mvc;
using Nop.Web.Framework;
using Nop.Web.Framework.Mvc;

namespace Nop.Plugin.Widgets.BooksStock.Models
{
    public class ConfigurationModel : BaseNopModel
    {
        public int ActiveStoreScopeConfiguration { get; set; }
     
        [NopResourceDisplayName("Plugins.Widgets.BooksStock.InformationText")]
        [AllowHtml]
        public string InformationText { get; set; }
        public bool InformationText_OverrideForStore { get; set; }
    }
}