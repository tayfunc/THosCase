namespace THosCase.Data.Context
{
    using System.Configuration;
    using System.Data.Entity;
    using System.Data.Entity.Core.EntityClient;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using System.Data.SqlClient;

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("THosEntities")
        {
            Database.SetInitializer<ApplicationDbContext>(null);

            Database.SetInitializer(new NullDatabaseInitializer<ApplicationDbContext>());
        }

        static ApplicationDbContext()
        {
            // Entity Framework SQL Provider'ı zorla yükle
            var ensureDllIsCopied = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductProperty> ProductProperties { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
