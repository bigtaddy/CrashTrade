﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using ResourceMetadata.Data.Infrastructure;
using ResourceMetadata.Data.Repositories;
using ResourceMetadata.Models;

namespace ResourceMetadata.Service
{
    public class AdvertService : IAdvertService
    {

        private IAdvertRepository repository;
        private IUnitOfWork unitOfWork;
        private readonly UserManager<ApplicationUser> userManager;


        public AdvertService(IAdvertRepository repository, IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<Advert> GetAdverts()
        {
            return repository.GetAll();
        }

        public IEnumerable<Advert> GetAdverts(AdvertType advertType)
        {
            return repository.GetAll(advertType);
        }

        public Advert AddAdvert(Advert advert)
        {
            advert.CreatedOn = DateTime.Now;
            repository.Add(advert);
            SaveChanges();
            return advert;
        }

        public Advert GetAdvertById(int id)
        {
            return repository.GetById(id);
        }

        public Advert UpdateAdvert(Advert advert)
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

        public void SaveChanges()
        {
            unitOfWork.SaveChanges();
        }
    }

    public interface IAdvertService
    {
        IEnumerable<Advert> GetAdverts();
        IEnumerable<Advert> GetAdverts(AdvertType advertType);
        Advert AddAdvert(Advert advert);
        Advert GetAdvertById(int id);
        Advert UpdateAdvert(Advert advert);
        void DeleteAdvert(int advertId);
    }
}
