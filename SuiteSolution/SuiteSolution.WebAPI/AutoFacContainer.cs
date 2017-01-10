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
        public static IContainer Container { get; set; }
        public object ReferencedAssemblies { get; private set; }

        public void Initialise(HttpConfiguration config)
        {

            var builder = new ContainerBuilder();
            builder.RegisterFilterProvider();
            builder.Register<DbContext>(b =>
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


            //Controller
            builder.RegisterApiControllers(Assembly.Load("SuiteSolution.WebAPI"));

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            var resolver = new AutofacWebApiDependencyResolver(container);
            config.DependencyResolver = resolver;
        }

     


    }
}