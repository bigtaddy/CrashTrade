using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ResourceMetadata.Models;

namespace ResourceMetadata.API.ViewModels
{
    public class AdvertViewModel
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public string ImagePath { get; set; }

        public int ManufactureId { get; set; }

        public string Manufacture { get; set; }

        public int ModelId { get; set; }

        public string CarModel { get; set; }

        public int Year { get; set; }

        public FuelType FuelType { get; set; }

    }
}