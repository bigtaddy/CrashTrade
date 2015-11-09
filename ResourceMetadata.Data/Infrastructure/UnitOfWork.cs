using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceMetadata.Data.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext dbContext;
        private readonly IDatabaseFactory dbFactory;
        protected ApplicationDbContext DbContext
        {
            get
            {
                return dbContext ?? dbFactory.Get();
            }
        }

        public UnitOfWork(IDatabaseFactory dbFactory)
        {
            this.dbFactory = dbFactory;
        }

        public void SaveChanges()
        {
            DbContext.SaveChanges();
        }
    }
}
