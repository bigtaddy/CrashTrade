using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ResourceMetadata.API.ViewModels
{
    public class CarModelViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int? ManufactureId { get; set; }

        public string Manufacture { get; set; }

    }
}