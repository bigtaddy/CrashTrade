﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using AutoMapper;
using Microsoft.AspNet.Identity;
using ResourceMetadata.API.ViewModels;
using ResourceMetadata.Data;
using ResourceMetadata.Data.Infrastructure;
using ResourceMetadata.Models;
using ResourceMetadata.Service;

namespace ResourceMetadata.API.Controllers
{
    public class AdvertsController : BaseApiController
    {
        private readonly IAdvertService advertService;
        private const string RelativeUploadPath = "~/Images/";


        public AdvertsController(IAdvertService advertService)
        {
            this.advertService = advertService;
        }

        [HttpGet]
        [Route("api/Adverts/All")]
        [AllowAnonymous]
        public HttpResponseMessage GetAll(int pageNumber, int itemsPerPage, string sortOptions, string filterOptions)
        {
            var advertModels = advertService.GetAdverts(pageNumber, itemsPerPage, sortOptions, filterOptions);
            var advertModelViewModels = new List<AdvertViewModel>();
            var count = advertService.GetCount(filterOptions);
            Mapper.Map(advertModels, advertModelViewModels);
            SetCorrectImagesPaths(advertModelViewModels);
            return Request.CreateResponse(HttpStatusCode.OK, new { adverts = advertModelViewModels, count });
        }

        [HttpGet]
        [Route("api/Adverts/My")]
        [Authorize(Roles = "Admin, Member")]
        public HttpResponseMessage GetForUser(int pageNumber, int itemsPerPage, string sortOptions, string filterOptions)
        {
            filterOptions = "(" + filterOptions + (") And UserId=\"" + User.Identity.GetUserId() + "\"");

            return GetAll(pageNumber, itemsPerPage, sortOptions, filterOptions);
        }

        [HttpGet]
        [Route("api/Adverts/Get")]
        [AllowAnonymous]
        public IHttpActionResult GetById(int id)
        {
            var advertModel = advertService.GetAdvertById(id);
            var viewModel = new AdvertViewModel();
            Mapper.Map(advertModel, viewModel);
            SetCorrectImagesPaths(viewModel);
            return Ok(viewModel);
        }

        [HttpPost]
        [Route("api/Adverts/Save")]
        [Authorize(Roles = "Admin, Member")]
        public IHttpActionResult Save(AdvertViewModel advertModelViewModel)
        {
            var entity = new Advert();
            Mapper.Map(advertModelViewModel, entity);
            entity.UserId = User.Identity.GetUserId();
            advertService.AddAdvert(entity);
            Mapper.Map(entity, advertModelViewModel);
            return Created(Url.Link("DefaultApi", new {controller = "Adverts", id = advertModelViewModel.Id}),
                advertModelViewModel);
        }

        [Authorize(Roles = "Admin, Member")]
        public IHttpActionResult Put(int id, AdvertViewModel advertModelViewModel)
        {
            advertModelViewModel.Id = id;
            var advert = advertService.GetAdvertById(id);
            if (advert.UserId != User.Identity.GetUserId())
            {
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.Forbidden, "Permission denied"));
            }


            Mapper.Map(advertModelViewModel, advert);
            advertService.UpdateAdvert(advert);
            return Ok(advertModelViewModel);
        }

        [Authorize(Roles = "Admin, Member")]
        public IHttpActionResult Delete(int id)
        {
            var advert = advertService.GetAdvertById(id);
            if (advert.UserId != User.Identity.GetUserId())
            {
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.Forbidden, "Permission denied"));
            }

            advertService.DeleteAdvert(id);
            return Ok();
        }


        private void SetCorrectImagesPaths(List<AdvertViewModel> adverts)
        {
            foreach (var advert in adverts)
            {
                foreach (var image in advert.ImageInfos)
                {
                    image.FullName = Url.Content(RelativeUploadPath + image.FullName);
                }
            }
        }

        private void SetCorrectImagesPaths(AdvertViewModel advert)
        {
            foreach (var image in advert.ImageInfos)
            {
                image.FullName = Url.Content(RelativeUploadPath + image.FullName);
            }
        }

    }

}
