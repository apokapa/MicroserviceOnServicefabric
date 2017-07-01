using System.Data.Entity;

namespace ProductsSrvc
{
    public class ProductsDbContext : DbContext
    {
        public ProductsDbContext(): base("name=MyAppConString") { }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

    }
}
