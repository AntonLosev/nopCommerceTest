using Nop.Core.Domain.Localization;
using Nop.Core.Domain.Security;
using Nop.Core.Domain.Seo;
using Nop.Core.Domain.Stores;

namespace Nop.Core.Domain.Catalog
{
    /// <summary>
    /// Represents a product
    /// </summary>
    public partial class Product : BaseEntity, ILocalizedEntity, ISlugSupported, IAclSupported, IStoreMappingSupported
    {
        public string Author { get; set; }
    }
}