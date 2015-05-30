using System;

namespace ResourceMetadata.Models
{
    public class ImageInfo
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public int AdvertId { get; set; }

        public virtual Advert Advert { get; set; }

    }
}
