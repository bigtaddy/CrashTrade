using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using ResourceMetadata.API.Mappers;
using ResourceMetadata.Data;
using ResourceMetadata.Data.Infrastructure;
using ResourceMetadata.Data.Repositories;
using ResourceMetadata.Models;
using ResourceMetadata.Service;

namespace ResourceMetadata.API
{
    public static class Bootstrapper
    {
        public static void Configure()
        {
            ConfigureAutofacContainer();
            AutoMapperConfiguration.Configure();
        }

        public static void ConfigureAutofacContainer()
        {

            var webApiContainerBuilder = new ContainerBuilder();
            ConfigureWebApiContainer(webApiContainerBuilder);
        }

        public static void ConfigureWebApiContainer(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<DatabaseFactory>().As<IDatabaseFactory>().AsImplementedInterfaces().InstancePerApiRequest();
            containerBuilder.RegisterType<UnitOfWork>().As<IUnitOfWork>().AsImplementedInterfaces().InstancePerApiRequest();
            containerBuilder.RegisterType<ManufactureRepository>().As<IManufactureRepository>().InstancePerApiRequest();
            containerBuilder.RegisterType<CarModelRepository>().As<ICarModelRepository>().InstancePerApiRequest();
            containerBuilder.RegisterType<AdvertRepository>().As<IAdvertRepository>().InstancePerApiRequest();
            containerBuilder.RegisterType<UserRepository>().As<IUserRepository>().InstancePerApiRequest();
            containerBuilder.RegisterType<ImageInfoRepository>().As<IImageInfoRepository>().InstancePerApiRequest();
            containerBuilder.RegisterType<ManufactureService>().As<IManufactureService>().InstancePerApiRequest();
            containerBuilder.RegisterType<CarModelService>().As<ICarModelService>().InstancePerApiRequest();
            containerBuilder.RegisterType<AdvertService>().As<IAdvertService>().InstancePerApiRequest();
            containerBuilder.RegisterType<UserService>().As<IUserService>().InstancePerApiRequest();
            containerBuilder.RegisterType<ImageInfoService>().As<IImageInfoService>().InstancePerApiRequest();

            containerBuilder.Register(c => new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ResourceManagerContext())
            {
                /*Avoids UserStore invoking SaveChanges on every actions.*/
                //AutoSaveChanges = false
            })).As<UserManager<ApplicationUser>>().InstancePerApiRequest();

            containerBuilder.RegisterApiControllers(System.Reflection.Assembly.GetExecutingAssembly());
            IContainer container = containerBuilder.Build();
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

    }
}