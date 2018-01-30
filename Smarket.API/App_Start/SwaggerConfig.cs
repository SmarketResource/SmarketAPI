using System.Globalization;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using Swashbuckle.Application;
using Swashbuckle.Swagger;
using WebActivatorEx;
using Smarket.API;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace Smarket.API
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                    {
                        c.DocumentFilter<TokenEndpointDocumentFilter>();
                        c.SingleApiVersion("v1", "Smarket.API");
                        c.IncludeXmlComments(string.Format(@"{0}\bin\SmarketAPI.xml", System.AppDomain.CurrentDomain.BaseDirectory));
                    })
                    .EnableSwaggerUi();
        }
    }
}