using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductsSrvc
{
    public interface IProductsRepository
    {

        Task<IEnumerable<Product>> GetProducts();
        Task<Product> GetProduct(int Id);
        Task<int> AddProduct(Product product);
        Task UpdateProduct(int Id, Product product);
        Task DeleteProduct(int Id);

    }
}
