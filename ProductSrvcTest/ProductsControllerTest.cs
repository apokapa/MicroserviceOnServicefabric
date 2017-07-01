using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using ProductsSrvc.Controllers;
using ProductsSrvc;
using System.Web.Http.Results;
using System.Collections.Generic;

namespace ProductSrvcTest
{
    [TestClass]
    public class ProductsControllerTest
    {
        [TestMethod]
        public async Task GetProducts()
        {
            //Arrange
            ProductsController controller = new ProductsController();

            //Act
            var result = await controller.GetProducts() as OkNegotiatedContentResult<IEnumerable<Product>>;
            var products = result.Content as IList<Product>;

            //Assert
            Assert.IsTrue(products.Count > 0);
        }

        [TestMethod]
        public async Task ProductCRUD()
        {
            //Arrange
            Product product = new Product();
            product.Name = "UnitTestProduct";
            product.Price = 100;
            product.CategoryId = 1;

            //Act AddProduct
            var Id = await AddProduct(product);
            product.Id = Id;
            //Asser AddProduct
            Assert.IsTrue(product.Id > 0);

            //Act GetProduct
            var _product = await GetProduct(Id);
            //Assert GetProduct
            Assert.IsTrue(_product.Id == product.Id);

            //Act UpdateProduct
            product.Name = "UnitTestProductUpdate";

            await UpdateProduct(product.Id, product);

            _product = await GetProduct(Id);

            //Assert UpdateProduct
            Assert.IsTrue(_product.Name == product.Name);

            //Act DeleteProduct
            await DeleteProduct(product.Id);
            _product = await GetProduct(Id);

            //Assert DeleteProduct
            Assert.IsNull(_product);

        }

        public async Task<int> AddProduct(Product product)
        {
            //Arrange
            ProductsController controller = new ProductsController();
            int Id;

            //Act
            var result = await controller.AddProduct(product) as OkNegotiatedContentResult<int>;
            Id = result.Content;

            return Id;
        }

        public async Task<Product> GetProduct(int Id)
        {
            //Arrange
            ProductsController controller = new ProductsController();

            //Act
            var result = await controller.GetProduct(Id) as OkNegotiatedContentResult<Product>;

            return result.Content;
        }

        public async Task UpdateProduct(int Id, Product product)
        {
            //Arrange
            ProductsController controller = new ProductsController();

            //Act
            var result = await controller.UpdateProduct(Id, product);
        }

        public async Task DeleteProduct(int Id)
        {
            //Arrange
            ProductsController controller = new ProductsController();

            //Act
            await controller.DeleteProduct(Id);

        }

    }
}
