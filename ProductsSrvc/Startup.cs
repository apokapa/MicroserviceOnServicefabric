using Newtonsoft.Json;
using Owin;
using System.Web.Http;

namespace ProductsSrvc
{
    public class Startup : IOwinAppBuilder
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            HttpConfiguration config = new HttpConfiguration();

            config.MapHttpAttributeRoutes();

            // clear the supported mediatypes of the xml formatter
            config.Formatters.XmlFormatter.SupportedMediaTypes.Clear();
            //json
            var json = config.Formatters.JsonFormatter;
            json.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
            json.SerializerSettings.NullValueHandling = NullValueHandling.Include;

            //Swagger
            SwaggerConfig.Register(config);

            appBuilder.UseWebApi(config);

        }
    }
}
