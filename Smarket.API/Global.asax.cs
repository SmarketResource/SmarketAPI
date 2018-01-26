using Smarket.API.App_Start;
using Smarket.API.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace Smarket.API
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            UnityConfig.RegisterComponents();
            AutoMapperConfig.RegisterMappings();

            GlobalConfiguration.Configure(WebApiConfig.Register);

        }
    }
}
