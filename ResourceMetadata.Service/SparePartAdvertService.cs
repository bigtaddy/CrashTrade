using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using ResourceMetadata.Data.Infrastructure;
using ResourceMetadata.Data.Repositories;
using ResourceMetadata.Models;

namespace ResourceMetadata.Service
{
    public class SparePartAdvertService: ISparePartAdvertService
    {

        private ISparePartAdvertRepository repository;
        private IUnitOfWork unitOfWork;
        private readonly UserManager<ApplicationUser> userManager;


        public SparePartAdvertService(ISparePartAdvertRepository repository, IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<SparePartAdvert> GetAdverts(int pageNumber, int itemsPerPage, string sortOptions, string filterOptions)
        {
            return repository.GetAll(pageNumber, itemsPerPage, sortOptions, filterOptions);
        }

        public IEnumerable<SparePartAdvert> GetAdvertsForUser(int pageNumber, int itemsPerPage, string userId)
        {
            return repository.GetAllForUser(pageNumber, itemsPerPage, userId);
        }



        public SparePartAdvert AddAdvert(SparePartAdvert advert)
        {
            advert.CreatedOn = DateTime.Now;
            repository.Add(advert);
            SaveChanges();
            return advert;
        }

        public SparePartAdvert GetAdvertById(int id)
        {
            return repository.GetById(id);
        }

        public SparePartAdvert UpdateAdvert(SparePartAdvert advert)
        {
            repository.Update(advert);
            SaveChanges();
            return advert;
        }

        public void DeleteAdvert(int advertId)
        {
            var advert = repository.GetById(advertId);
            repository.Delete(advert);
            SaveChanges();
        }

        public int GetCount(string filterOptions)
        {
            return repository.GetCount(filterOptions);
        }

        public void SaveChanges()
        {
            unitOfWork.SaveChanges();
        }
    }

    public interface ISparePartAdvertService
    {
        IEnumerable<SparePartAdvert> GetAdverts(int pageNumber, int itemsPerPage, string sortOptions, string filterOptions);
        IEnumerable<SparePartAdvert> GetAdvertsForUser(int pageNumber, int itemsPerPage, string userId);
        SparePartAdvert AddAdvert(SparePartAdvert advert);
        SparePartAdvert GetAdvertById(int id);
        SparePartAdvert UpdateAdvert(SparePartAdvert advert);
        void DeleteAdvert(int advertId);
        int GetCount(string filterOptions);
    }
}