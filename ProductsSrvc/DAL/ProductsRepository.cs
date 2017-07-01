using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsSrvc
{
    public class ProductsRepository : IProductsRepository
    {
        public async Task<IEnumerable<Product>> GetProducts()
        {
            using (var context = new ProductsDbContext())
            {

                var results = await context.Products.AsNoTracking().OrderBy(p => p.Name).ToListAsync();

                return results;

            }
        }

        public async Task<Product> GetProduct(int Id)
        {
            using (var context = new ProductsDbContext())
            {

                var results = await context.Products.FindAsync(Id);

                return results;

            }
        }

        public async Task<int> AddProduct(Product product)
        {
            using (var context = new ProductsDbContext())
            {
                if (product == null)
                {
                    throw new ArgumentNullException("product is null");
                }

                context.Products.Add(product);
                await context.SaveChangesAsync();

                return product.Id;
            }
        }

        public async Task UpdateProduct(int Id, Product product)
        {
            using (var context = new ProductsDbContext())
            {
                context.Entry(product).State = EntityState.Modified;
                await context.SaveChangesAsync();

            }
        }

        public async Task DeleteProduct(int Id)
        {
            using (var context = new ProductsDbContext())
            {
                var product = context.Products.Find(Id);
                if (product == null)
                {
                    throw new ArgumentNullException("Product Doesn't exist");
                }

                context.Entry(product).State = EntityState.Deleted;
                await context.SaveChangesAsync();

            }
        }


    }
}
