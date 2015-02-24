using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ResourceMetadata.Models;

namespace ResourceMetadata.Data.Configurations
{
    internal class AdvertConfiguration : EntityTypeConfiguration<Advert>
    {
        public AdvertConfiguration()
        {
            HasRequired(advert => advert.User).WithMany(user => user.Adverts);
        }
    }
}
