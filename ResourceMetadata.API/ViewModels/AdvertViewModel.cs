using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ResourceMetadata.Models;


namespace ResourceMetadata.API.ViewModels
{
    public class AdvertViewModel
    {
        private string url;

        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int ManufactureId { get; set; }

        public int CarModelId { get; set; }

        public string ManufactureName { get; set; }

        public string CarModelName { get; set; }

        public int Year { get; set; }

        public int SweptVolume { get; set; }
        public string Contacts { get; set; }

        public FuelType FuelType { get; set; }

        public TransmissionType TransmissionType { get; set; }

        public bool SaleType { get; set; }

        public bool CoachworkRepairType { get; set; }

        public bool MechanicalRepairType { get; set; }

        public int? Price { get; set; }

        public ICollection<ImageViewModel> ImageInfos { get; set; }
    }
}