using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ResourceMetadata.Models;


namespace ResourceMetadata.API.ViewModels
{
    public class AdvertViewModel : UniversalAdvertViewModel
    {
        public int SweptVolume { get; set; }

        public bool SaleType { get; set; }

        public bool CoachworkRepairType { get; set; }

        public bool MechanicalRepairType { get; set; }

        public int? Price { get; set; }
    }
}