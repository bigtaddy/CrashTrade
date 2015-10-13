using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ResourceMetadata.Models
{
    public class Advert
    {
        public int Id { get; set; }

        public bool SaleType { get; set; }

        public bool CoachworkRepairType { get; set; }

        public bool MechanicalRepairType { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime CreatedOn { get; set; }

        public int ManufactureId { get; set; }

        public virtual Manufacture Manufacture { get; set; }

        public int CarModelId { get; set; }

        public virtual CarModel CarModel { get; set; }

        public int Year { get; set; }

        public int? SweptVolume { get; set; }

        public int? Price { get; set; }

        public string Contacts { get; set; }

        public FuelType FuelType { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public virtual ICollection<ImageInfo> ImageInfos { get; set; }

    }

    public enum FuelType : int
    {
        Petrol = 1,
        Diesel = 2
    }

    public enum AdvertType : int
    {
        Repair = 1,
        Sale = 2
    }
}
