using ResourceMetadata.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ResourceMetadata.Models;

namespace ResourceMetadata.Data.Repositories
{
    public class ManufactureRepository : RepositoryBase<Manufacture>, IManufactureRepository
    {
        public ManufactureRepository(IDatabaseFactory dbFactory)
            : base(dbFactory)
        {

        }
    }

    public interface IManufactureRepository : IRepository<Manufacture>
    {

    }
}
