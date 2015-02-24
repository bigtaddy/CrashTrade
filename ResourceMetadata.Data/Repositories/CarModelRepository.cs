using ResourceMetadata.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ResourceMetadata.Data.Infrastructure;

namespace ResourceMetadata.Data.Repositories
{

    public class CarModelRepository : RepositoryBase<CarModel>, ICarModelRepository
    {
        public CarModelRepository(IDatabaseFactory dbFactory)
            : base(dbFactory)
        {

        }
    }

    public interface ICarModelRepository : IRepository<CarModel>
    {

    }
}
