using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ResourceMetadata.API.ViewModels
{
    public class ManufactureViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public virtual IEnumerable<CarModelViewModel> CarModels { get; set; }

    }
}