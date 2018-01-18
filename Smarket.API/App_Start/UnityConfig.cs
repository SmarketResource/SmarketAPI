using Smarket.API.Domain.Interfaces.IContext;
using Smarket.API.Domain.Interfaces.IRepositories;
using Smarket.API.Domain.Interfaces.IServices;
using Smarket.API.Infrastructure.Repositories;
using Smarket.API.Model.Context;
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
            container.RegisterType<IRepositoryBase<TypePhone>,  RepositoryBase<TypePhone>>();
            container.RegisterType<IRepositoryConsumer,         RepositoryConsumer>();
            container.RegisterType<IRepositoryLog,              RepositoryLog>();

            //Services
            container.RegisterType<IServiceBase<EntityBase>, ServiceBase<EntityBase>>();
            container.RegisterType<IServiceUser,             ServiceUser>();
            container.RegisterType<IServiceLogin,            ServiceLogin>();
            container.RegisterType<IServiceConsumer,         ServiceConsumer>();
            container.RegisterType<IServiceLog,              ServiceLog>();


            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
            return GlobalConfiguration.Configuration.DependencyResolver;

        }
    }
}