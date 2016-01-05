using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ResourceMetadata.API.ViewModels
{
    public class SparePartAdvertViewModel
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public DateTime CreatedOn { get; set; }

        public int ManufactureId { get; set; }

        public int CarModelId { get; set; }

        public string ManufactureName { get; set; }

        public string CarModelName { get; set; }

        public int Year { get; set; }

        public string VIN { get; set; }

        public string Contacts { get; set; }

        public virtual ICollection<ImageViewModel> ImageInfos { get; set; }
    }
}