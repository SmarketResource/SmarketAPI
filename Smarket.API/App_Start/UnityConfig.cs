using Smarket.API.Domain.Interfaces.IContext;
using Smarket.API.Domain.Interfaces.IRepositories;
using Smarket.API.Domain.Interfaces.IServices;
using Smarket.API.Infrastructure.Repositories;
using Smarket.API.Model.Context;
using Smarket.API.Model.EntityModel;
using Smarket.API.Service.Services;
using System.Web.Http;
using System.Web.Http.Dependencies;
using Unity;
using Unity.WebApi;

namespace Smarket.API.App_Start
{
    public static class UnityConfig
    {

        public static IDependencyResolver RegisterComponents()
        {
            var container = new UnityContainer();

            //DbContext
            container.RegisterType<IDbContext, SmarketContext>();

            //Repositories
            container.RegisterType<IRepositoryBase<EntityBase>, RepositoryBase<EntityBase>>();
            container.RegisterType<IRepositoryUser,             RepositoryUser>();
            container.RegisterType<IRepositoryBase<TypeUsers>,  RepositoryBase<TypeUsers>>();
            container.RegisterType<IRepositoryBase<Phones>,     RepositoryBase<Phones>>();
            container.RegisterType<IRepositoryBase<Address>,    RepositoryBase<Address>>();
            container.RegisterType<IRepositoryBase<TypePhone>,  RepositoryBase<TypePhone>>();
            container.RegisterType<IRepositoryConsumer,         RepositoryConsumer>();
            container.RegisterType<IRepositoryLog,              RepositoryLog>();
            container.RegisterType<IRepositoryPhone,            RepositoryPhone>();
            container.RegisterType<IRepositoryConsumersPhones,  RepositoryConsumersPhones>();
            container.RegisterType<IRepositoryCommerce,         RepositoryCommerce>();
            container.RegisterType<IRepositoryMarket,           RepositoryMarket>();
            container.RegisterType<IRepositoryAddress,          RepositoryAddress>();
            container.RegisterType<IRepositoryCity,             RepositoryCity>();
            container.RegisterType<IRepositoryState,            RepositoryState>();
            container.RegisterType<IRepositoryBrand,            RepositoryBrand>();
            container.RegisterType<IRepositoryCategory,         RepositoryCategory>();

            //Services
            container.RegisterType<IServiceBase<EntityBase>,    ServiceBase<EntityBase>>();
            container.RegisterType<IServiceUser,                ServiceUser>();
            container.RegisterType<IServiceLogin,               ServiceLogin>();
            container.RegisterType<IServiceConsumer,            ServiceConsumer>();
            container.RegisterType<IServiceLog,                 ServiceLog>();
            container.RegisterType<IServicePhone,               ServicePhone>();
            container.RegisterType<IServiceCommerce,            ServiceCommerce>();
            container.RegisterType<IServiceMarket,              ServiceMarket>();
            container.RegisterType<IServiceCity,                ServiceCity>();
            container.RegisterType<IServiceState,               ServiceState>();
            container.RegisterType<IServiceBrand,               ServiceBrand>();
            container.RegisterType<IServiceCategory,            ServiceCategory>();    

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
            return GlobalConfiguration.Configuration.DependencyResolver;

        }
    }
}