namespace THosCase
{
    using System.Web.Mvc;
    
    using THosCase.Business.Category;
    using THosCase.Business.Intefaces;
    using THosCase.Business.Product;
    using THosCase.Business.ProductProperty;
    using THosCase.Business.Property;
    using THosCase.Business.User;

    using THosCase.Data.Context;
    using THosCase.Data.Interfaces;
    using THosCase.Data.Repositories;

    using Unity;
    using Unity.Lifetime;
    using Unity.Mvc5;

    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // DbContext registration
            container.RegisterType<ApplicationDbContext>(new HierarchicalLifetimeManager());

            // Repository registration
            container.RegisterType<ICategoryRepository, CategoryRepository>();

            container.RegisterType<IUserRepository, UserRepository>();

            container.RegisterType<IProductRepository, ProductRepository>();

            container.RegisterType<IPropertyRepository, PropertyRepository>();

            container.RegisterType<IProductPropertyRepository, ProductPropertyRepository>();

            // Service registration
            container.RegisterType<ICategoryService, CategoryService>();

            container.RegisterType<IUserService, UserService>();

            container.RegisterType<IProductService, ProductService>();

            container.RegisterType<IPropertyService, PropertyService>();

            container.RegisterType<IProductPropertyService, ProductPropertyService>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}