using Autofac;
using Autofac.Core;
using Nop.Core.Caching;
using Nop.Core.Configuration;
using Nop.Core.Infrastructure;
using Nop.Core.Infrastructure.DependencyManagement;
using Nop.Web.Factories;
using Nop.Web.Themes.BooksThemes.Factories;

namespace Nop.Web.Infrastructure
{
    /// <summary>
    /// Dependency registrar
    /// </summary>
    public class DependencyRegistrarForBooks : IDependencyRegistrar
    {
        /// <summary>
        /// Register services and interfaces
        /// </summary>
        /// <param name="builder">Container builder</param>
        /// <param name="typeFinder">Type finder</param>
        /// <param name="config">Config</param>
        public virtual void Register(ContainerBuilder builder, ITypeFinder typeFinder, NopConfig config)
        {
            
            builder.RegisterType<BooksProductModelFactory>().As<IProductModelFactory>()
                .WithParameter(ResolvedParameter.ForNamed<ICacheManager>("nop_cache_static"))
                .InstancePerLifetimeScope();
           
        }

        /// <summary>
        /// Order of this dependency registrar implementation
        /// </summary>
        public int Order
        {
            get { return 3; }
        }
    }
}
