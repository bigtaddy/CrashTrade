using Microsoft.AspNet.Identity.EntityFramework;
using ResourceMetadata.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ResourceMetadata.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("CrashT", throwIfV1Schema: false)
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

    }
}