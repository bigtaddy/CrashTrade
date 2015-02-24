using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ResourceMetadata.Models;

namespace ResourceMetadata.Data.Configurations
{
    internal class ManufactureConfiguration : EntityTypeConfiguration<Manufacture>
    {
        public ManufactureConfiguration()
        {
            HasMany(manufacture => manufacture.CarModels).WithOptional(model => model.Manufacture).WillCascadeOnDelete(false);
        }
    }
}
