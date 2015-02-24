using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceMetadata.Models
{
    public class CarModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int? ManufactureId { get; set; }

        public virtual Manufacture Manufacture { get; set; }

    }
}
