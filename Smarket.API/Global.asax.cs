using Smarket.API.App_Start;
using Smarket.API.AutoMapper;
using System.Web;
using System.Web.Http;

namespace Smarket.API
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            UnityConfig.RegisterComponents();
            AutoMapperConfig.RegisterMappings();
        }
    }
}
