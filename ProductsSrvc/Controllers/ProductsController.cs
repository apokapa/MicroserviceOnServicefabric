using ProductsSrvc.ErrorHandling;
using System.Threading.Tasks;
using System.Web.Http;

namespace ProductsSrvc.Controllers
{

    
    [RoutePrefix("prodsrvc")]
    [ApiExceptionFilter]
    public class ProductsController : ApiController
    {

        ProductsRepository _repo = new ProductsRepository();

        // GET prodsrvc/products
        [Route("products")]
        public async Task<IHttpActionResult> GetProducts()
        {
            var products = await _repo.GetProducts();
            return Ok(products);
        }

        // GET prodsrvc/products/5
        [Route("products/{Id}")]
        public async Task<IHttpActionResult> GetProduct(int Id)
        {
            var product = await _repo.GetProduct(Id);
            return Ok(product);
        }

        // POST prodsrvc/products
        [Route("products")]
        [HttpPost]
        public async Task<IHttpActionResult> AddProduct([FromBody] Product product)
        {
            var Id = await _repo.AddProduct(product);
            return Ok(Id);
        }

        // PUT prodsrvc/products/5
        [Route("products/{Id}")]
        [HttpPut]
        public async Task<IHttpActionResult> UpdateProduct(int Id,[FromBody] Product product)
        {
            await _repo.UpdateProduct(Id,product);
            return Ok();
        }

        // DELETE prodsrvc/products/5
        [Route("products/{Id}")]
        [HttpDelete]
        public async Task<IHttpActionResult> DeleteProduct(int Id)
        {
            await _repo.DeleteProduct(Id);
            return Ok();
        }

    }
}
