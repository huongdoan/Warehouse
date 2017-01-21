using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;
using SuiteSolution.WebAPI;
using System.Web.Http;
using System.IO;

[assembly: OwinStartup(typeof(SuiteSolution.Startup))]

namespace SuiteSolution
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();
            new AutoFacContainer().Initialise(config);

            app.UseWebApi(config);
        }
    }
}
