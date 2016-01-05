using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ResourceMetadata.Models;

namespace ResourceMetadata.Data.Configurations
{

    internal class SparePartAdvertConfiguration : EntityTypeConfiguration<SparePartAdvert>
    {
        public SparePartAdvertConfiguration()
        {
            HasRequired(sparePartAdvert => sparePartAdvert.User).WithMany(user => user.SparePartAdverts);
        }
    }
}
