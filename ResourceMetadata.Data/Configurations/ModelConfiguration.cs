using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ResourceMetadata.Models;

namespace ResourceMetadata.Data.Configurations
{

    internal class CarModelConfiguration : EntityTypeConfiguration<CarModel>
    {
        public CarModelConfiguration()
        {
            HasRequired(model => model.Manufacture).WithMany(manufacture => manufacture.CarModels).WillCascadeOnDelete(false);
        }
    }
}
