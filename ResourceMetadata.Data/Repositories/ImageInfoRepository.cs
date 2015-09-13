using ResourceMetadata.Data.Infrastructure;
using ResourceMetadata.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceMetadata.Data.Repositories
{

    public class ImageInfoRepository : RepositoryBase<ImageInfo>, IImageInfoRepository
    {

        public ImageInfoRepository(IDatabaseFactory dbFactory)
            : base(dbFactory)
        {

        }
    }


    public interface IImageInfoRepository : IRepository<ImageInfo>
    {
    }
}
