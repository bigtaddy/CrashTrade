using ResourceMetadata.Data.Infrastructure;
using ResourceMetadata.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
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
                    .Where(c => c.CarModelId == 2) //TODO!!!!!!!!!!!!!!!!!!!!!!!
                    .OrderBy(c => c.CreatedOn)
                    .Skip((pageNumber - 1) * itemsPerPage)
                    .Take(itemsPerPage);
        }

        public IEnumerable<Advert> GetAllForUser(int pageNumber, int itemsPerPage, string userId)
        {
            return
                dbset
                    .Where(c => c.UserId == userId)
                    .OrderBy(c => c.CreatedOn)
                    .Skip((pageNumber - 1) * itemsPerPage)
                    .Take(itemsPerPage);
        }

        public IEnumerable<Advert> GetAll(int pageNumber, int itemsPerPage, string sortOptions, string filterOptions)
        {
                return
                dbset.Where(filterOptions)
                    .OrderBy(sortOptions)
                    .Skip((pageNumber - 1) * itemsPerPage)
                    .Take(itemsPerPage).ToList();
        }

        public int GetCount(string filterOptions)
        {
            return dbset.Where(filterOptions).Count();
        }
    }

    public interface IAdvertRepository : IRepository<Advert>
    {
        IEnumerable<Advert> GetAll(AdvertType advertType, int pageNumber, int itemsPerPage);
        IEnumerable<Advert> GetAll(int pageNumber, int itemsPerPage, string sortOptions, string filterOptions);
        IEnumerable<Advert> GetAllForUser(int pageNumber, int itemsPerPage, string userId);
        int GetCount(string filterOptions);
    }
}
