using Smarket.API.App_Start;
using System.Web.Http;

namespace Smarket.API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configuração e serviços da Web API
            config.DependencyResolver = UnityConfig.RegisterComponents();

            // Rotas da Web API
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}"
            );
        }
    }
}
