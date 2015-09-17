using ResourceMetadata.Data.Infrastructure;
using ResourceMetadata.Data.Repositories;
using ResourceMetadata.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceMetadata.Service
{
    public class ImageInfoService : IImageInfoService
    {
        private IImageInfoRepository repository;
        private IUnitOfWork unitOfWork;

        public ImageInfoService(IImageInfoRepository repository, IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<ImageInfo> GetAll()
        {
            return repository.GetAll();
        }

        public ImageInfo GetById(int id)
        {
            return repository.GetById(id);
        }

        public ImageInfo Add(ImageInfo model)
        {
            repository.Add(model);
            SaveChanges();
            return model;
        }

        public ImageInfo Update(ImageInfo model)
        {
            repository.Update(model);
            SaveChanges();
            return model;
        }

        public void Delete(int id)
        {
            var model = repository.GetById(id);
            repository.Delete(model);
            SaveChanges();
        }

        public void SaveChanges()
        {
            unitOfWork.SaveChanges();
        }
    }

    public interface IImageInfoService
    {
        IEnumerable<ImageInfo> GetAll();
        ImageInfo GetById(int id);
        ImageInfo Add(ImageInfo model);
        ImageInfo Update(ImageInfo model);
        void Delete(int id);
    }
}

