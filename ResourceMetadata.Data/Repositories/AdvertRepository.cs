using ResourceMetadata.Data.Infrastructure;
using ResourceMetadata.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceMetadata.Data.Repositories
{

    public class AdvertRepository : RepositoryBase<Advert>, IAdvertRepository
    {
        public AdvertRepository(IDatabaseFactory dbFactory)
            : base(dbFactory)
        {

        }
    }

    public interface IAdvertRepository : IRepository<Advert>
    {

    }
}
