﻿using System.Web.Http;
using Swashbuckle.Application;
using WebActivatorEx;
using Smarket.API;
using Smarket.API.Filters;

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
                        c.OperationFilter<AddAuthorizationHeaderParameterOperationFilter>();
                    })
                    .EnableSwaggerUi(config => config.DocExpansion(DocExpansion.List));
        }
    }
}