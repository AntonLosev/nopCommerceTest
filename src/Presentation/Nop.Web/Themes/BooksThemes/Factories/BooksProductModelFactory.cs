using System.Collections.Generic;
using System.Linq;
using Nop.Core;
using Nop.Core.Caching;
using Nop.Core.Domain.Catalog;
using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Media;
using Nop.Core.Domain.Orders;
using Nop.Core.Domain.Seo;
using Nop.Core.Domain.Vendors;
using Nop.Services.Catalog;
using Nop.Services.Directory;
using Nop.Services.Helpers;
using Nop.Services.Localization;
using Nop.Services.Media;
using Nop.Services.Security;
using Nop.Services.Shipping.Date;
using Nop.Services.Stores;
using Nop.Services.Tax;
using Nop.Services.Vendors;
using Nop.Web.Factories;
using Nop.Web.Framework.Security.Captcha;
using Nop.Web.Models.Catalog;

namespace Nop.Web.Themes.BooksThemes.Factories
{
    /// <summary>
    /// Represents the product model factory
    /// </summary>
    public partial class BooksProductModelFactory : ProductModelFactory
    {
        #region Constructors

        public BooksProductModelFactory(ISpecificationAttributeService specificationAttributeService,
            ICategoryService categoryService,
            IManufacturerService manufacturerService,
            IProductService productService,
            IVendorService vendorService,
            IProductTemplateService productTemplateService,
            IProductAttributeService productAttributeService,
            IWorkContext workContext,
            IStoreContext storeContext,
            ITaxService taxService,
            ICurrencyService currencyService,
            IPictureService pictureService,
            ILocalizationService localizationService,
            IMeasureService measureService,
            IPriceCalculationService priceCalculationService,
            IPriceFormatter priceFormatter,
            IWebHelper webHelper,
            IDateTimeHelper dateTimeHelper,
            IProductTagService productTagService,
            IAclService aclService,
            IStoreMappingService storeMappingService,
            IPermissionService permissionService,
            IDownloadService downloadService,
            IProductAttributeParser productAttributeParser,
            IDateRangeService dateRangeService,
            MediaSettings mediaSettings,
            CatalogSettings catalogSettings,
            VendorSettings vendorSettings,
            CustomerSettings customerSettings,
            CaptchaSettings captchaSettings,
            SeoSettings seoSettings,
            ICacheManager cacheManager) : base(specificationAttributeService,
                categoryService,
                manufacturerService,
             productService,
             vendorService,
             productTemplateService,
             productAttributeService,
             workContext,
             storeContext,
             taxService,
             currencyService,
             pictureService,
             localizationService,
             measureService,
             priceCalculationService,
             priceFormatter,
             webHelper,
             dateTimeHelper,
             productTagService,
             aclService,
             storeMappingService,
             permissionService,
             downloadService,
             productAttributeParser,
             dateRangeService,
             mediaSettings,
             catalogSettings,
             vendorSettings,
             customerSettings,
             captchaSettings,
             seoSettings,
             cacheManager)
        {            
        }
        #endregion

        #region Methods     

        /// <summary>
        /// Prepare the product overview models
        /// </summary>
        /// <param name="products">Collection of products</param>
        /// <param name="preparePriceModel">Whether to prepare the price model</param>
        /// <param name="preparePictureModel">Whether to prepare the picture model</param>
        /// <param name="productThumbPictureSize">Product thumb picture size (longest side); pass null to use the default value of media settings</param>
        /// <param name="prepareSpecificationAttributes">Whether to prepare the specification attribute models</param>
        /// <param name="forceRedirectionAfterAddingToCart">Whether to force redirection after adding to cart</param>
        /// <returns>Collection of product overview model</returns>
        public override IEnumerable<ProductOverviewModel> PrepareProductOverviewModels(
            IEnumerable<Product> products,
            bool preparePriceModel = true, 
            bool preparePictureModel = true,
            int? productThumbPictureSize = null, 
            bool prepareSpecificationAttributes = false,
            bool forceRedirectionAfterAddingToCart = false)
        {

            var models = base.PrepareProductOverviewModels(products,
             preparePriceModel,
             preparePictureModel,
             productThumbPictureSize,
             prepareSpecificationAttributes,
             forceRedirectionAfterAddingToCart);

            foreach (var model in models)
            {
                model.Author = products.FirstOrDefault(p => p.Id == model.Id)?.GetLocalized(x => x.Author);
            }
           
            return models;
        }

        /// <summary>
        /// Prepare the product details model
        /// </summary>
        /// <param name="product">Product</param>
        /// <param name="updatecartitem">Updated shopping cart item</param>
        /// <param name="isAssociatedProduct">Whether the product is associated</param>
        /// <returns>Product details model</returns>
        public override ProductDetailsModel PrepareProductDetailsModel(
            Product product,
            ShoppingCartItem updatecartitem = null, 
            bool isAssociatedProduct = false)
        {
            var model = base.PrepareProductDetailsModel(product, updatecartitem, isAssociatedProduct);
            model.Author = product.GetLocalized(x => x.Author);

            return model;
        }

        #endregion
    }
}
