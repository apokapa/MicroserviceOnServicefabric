using System.Web.Http;
using WebActivatorEx;
using ProductsSrvc;
using Swashbuckle.Application;



namespace ProductsSrvc
{
    public class SwaggerConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.EnableSwagger(c =>
            {
                c.SingleApiVersion("v1", "ProductSrvc");
            })
        .EnableSwaggerUi(c =>
        {
        });
        }


    }
}
