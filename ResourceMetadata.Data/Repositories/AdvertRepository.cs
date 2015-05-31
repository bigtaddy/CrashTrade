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

        public IEnumerable<Advert> GetAll(AdvertType advertType, int pageNumber, int itemsPerPage)
        {
            return
                dbset
                    .Where(c => c.AdvertType == advertType)
                    .OrderBy(c => c.CreatedOn)
                    .Skip((pageNumber - 1) * itemsPerPage)
                    .Take(itemsPerPage);
        }

        public int GetCount(AdvertType advertType)
        {
            return dbset.Count(c => c.AdvertType == advertType);
        }
    }

    public interface IAdvertRepository : IRepository<Advert>
    {
        IEnumerable<Advert> GetAll(AdvertType advertType, int pageNumber, int itemsPerPage);
        int GetCount(AdvertType advertType);
    }
}
