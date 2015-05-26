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

        public IEnumerable<Advert> GetAll(AdvertType advertType)
        {
            return base.GetAll().Where(c => c.AdvertType == advertType);
        }
    }

    public interface IAdvertRepository : IRepository<Advert>
    {
        IEnumerable<Advert> GetAll(AdvertType advertType);
    }
}
