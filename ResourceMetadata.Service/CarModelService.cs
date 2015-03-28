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
    public class CarModelService : ICarModelService
    {
        private ICarModelRepository repository;
        private IUnitOfWork unitOfWork;

        public CarModelService(ICarModelRepository repository, IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<CarModel> GetCarModels()
        {
            return repository.GetAll();
        }

        public CarModel GetCarModelById(int id)
        {
            return repository.GetById(id);
        }

        public CarModel AddCarModel(CarModel carModel)
        {
            repository.Add(carModel);
             SaveChanges();
            return carModel;
        }

        public CarModel UpdateCarModel(CarModel carModel)
        {
            repository.Update(carModel);
            SaveChanges();
            return carModel;
        }

        public void DeleteCarModel(int carModelId)
        {
            var carModel = repository.GetById(carModelId);
            repository.Delete(carModel);
            SaveChanges();
        }

        public void SaveChanges()
        {
            unitOfWork.SaveChanges();
        }
    }

    public interface ICarModelService
    {
        IEnumerable<CarModel> GetCarModels();
        CarModel GetCarModelById(int id);
        CarModel AddCarModel(CarModel carModel);
        CarModel UpdateCarModel(CarModel carModel);
        void DeleteCarModel(int carModelId);

    }
}
