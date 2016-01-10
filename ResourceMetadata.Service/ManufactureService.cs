using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ResourceMetadata.Data.Infrastructure;
using ResourceMetadata.Data.Repositories;
using ResourceMetadata.Models;

namespace ResourceMetadata.Service
{
    public class ManufactureService : IManufactureService
    {
        private IManufactureRepository repository;
        private IUnitOfWork unitOfWork;

        public ManufactureService(IManufactureRepository repository, IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<Manufacture> GetManufactures()
        {
            return repository.GetAll();
        }

        public Manufacture GetManufactureById(int id)
        {
            return repository.GetById(id);
        }

        public Manufacture AddManufacture(Manufacture manufacture)
        {
            repository.Add(manufacture);
            SaveChanges();
            return manufacture;
        }

        public Manufacture UpdateManufacture(Manufacture manufacture)
        {
            repository.Update(manufacture);
            SaveChanges();
            return manufacture;
        }

        public void DeleteManufacture(int manufactureId)
        {
            var manufacture = repository.GetById(manufactureId);
            repository.Delete(manufacture);
            SaveChanges();
        }

        public void AddManufactures(IEnumerable<Manufacture> manufactures)
        {
            foreach (var manufacture in manufactures) {
                repository.Add(manufacture);
            }
            SaveChanges();
        }

        public void SaveChanges()
        {
            unitOfWork.SaveChanges();
        }
    }

      public interface IManufactureService
    {
        IEnumerable<Manufacture> GetManufactures();
        Manufacture GetManufactureById(int id);
        Manufacture AddManufacture(Manufacture location);
        Manufacture UpdateManufacture(Manufacture location);
        void DeleteManufacture(int manufactureId);
        void AddManufactures(IEnumerable<Manufacture> manufactures);

    }

}
