using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;
using System.Web.Http;
using System.Data.Entity;
using System.Web.Mvc;
using ResourceMetadata.Data;

[assembly: OwinStartup(typeof(ResourceMetadata.API.Startup))]

namespace ResourceMetadata.API
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
             ConfigureAuth(app);
             GlobalConfiguration.Configure(WebApiConfig.Register);
             Bootstrapper.Configure();
             Database.SetInitializer<ApplicationDbContext>(new ResourceManagerDbInitializer());
             AreaRegistration.RegisterAllAreas();
             FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
        }
    }
}
