using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Text;
using System.Threading.Tasks;
using ResourceMetadata.Data.Infrastructure;
using ResourceMetadata.Models;

namespace ResourceMetadata.Data.Repositories
{
    public class SparePartAdvertRepository : RepositoryBase<SparePartAdvert>, ISparePartAdvertRepository
    {
        public SparePartAdvertRepository(IDatabaseFactory dbFactory)
            : base(dbFactory)
        {

        }

        public IEnumerable<SparePartAdvert> GetAllForUser(int pageNumber, int itemsPerPage, string userId)
        {
            return
                dbset
                    .Where(c => c.UserId == userId)
                    .OrderBy(c => c.CreatedOn)
                    .Skip((pageNumber - 1) * itemsPerPage)
                    .Take(itemsPerPage);
        }

        public IEnumerable<SparePartAdvert> GetAll(int pageNumber, int itemsPerPage, string sortOptions, string filterOptions)
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

    public interface ISparePartAdvertRepository : IRepository<SparePartAdvert>
    {
        IEnumerable<SparePartAdvert> GetAll(int pageNumber, int itemsPerPage, string sortOptions, string filterOptions);
        IEnumerable<SparePartAdvert> GetAllForUser(int pageNumber, int itemsPerPage, string userId);
        int GetCount(string filterOptions);
    }
}

