
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using SuiteSolution.Core.Data;
using SuiteSolution.Core.Entities;
using SuiteSolution.Service;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;


namespace SuiteSolution.WebAPI
{
    public class AutoFacContainer
    {
       

        public void Initialise(HttpConfiguration config)
        {

            var builder = new ContainerBuilder();

            //Controller
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            //builder.RegisterControllers(Assembly.GetExecutingAssembly());

            //builder.RegisterFilterProvider();
            builder.Register<SuiteDbContext>(b =>
            {
                var context = new SuiteDbContext();
                return context;
            }).InstancePerLifetimeScope();

            //Repository
            builder.RegisterAssemblyTypes(Assembly.Load("SuiteSolution.Core")).
                Where(_ => _.Name.EndsWith("Repository")).
                AsImplementedInterfaces().
                InstancePerLifetimeScope();

            builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IGenericRepository<>)).InstancePerDependency();

            //Service
            builder.RegisterAssemblyTypes(Assembly.Load("SuiteSolution.Service")).
                Where(_ => _.Name.EndsWith("Service")).
                AsImplementedInterfaces().
                InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(Service<,>)).As(typeof(IService<>)).InstancePerDependency();
            //builder.RegisterType<ProductExportService>().As<IProductExportService>().InstancePerRequest();

            //builder.RegisterType<TestService>().As<ITestService>().InstancePerRequest();



            var container = builder.Build();

            var resolver = new AutofacWebApiDependencyResolver(container);
            // Set the dependency resolver for Web API.
            GlobalConfiguration.Configuration.DependencyResolver = resolver;

            // Set MVC DI resolver to use our Autofac container
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            //config.DependencyResolver = resolver;
        }

     


    }
}