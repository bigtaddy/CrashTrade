using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Microsoft.AspNet.Identity;
using ResourceMetadata.API.ViewModels;
using ResourceMetadata.Models;
using ResourceMetadata.Service;

namespace ResourceMetadata.API.Controllers
{
    public class SparePartAdvertsController : BaseApiController
    {
        private readonly ISparePartAdvertService advertService;
        private const string RelativeUploadPath = "~/Images/";


        public SparePartAdvertsController(ISparePartAdvertService advertService)
        {
            this.advertService = advertService;
        }

        [HttpGet]
        [Route("api/SparePartAdverts/GetAll")]
        [AllowAnonymous]
        public HttpResponseMessage GetAll(int pageNumber, int itemsPerPage, string sortOptions, string filterOptions)
        {
            var advertModels = advertService.GetAdverts(pageNumber, itemsPerPage, sortOptions, filterOptions);

            var advertModelViewModels = new List<SparePartAdvertViewModel>();
            var count = advertService.GetCount(filterOptions);
            Mapper.Map(advertModels, advertModelViewModels);
            SetCorrectImagesPaths(advertModelViewModels);
            return Request.CreateResponse(HttpStatusCode.OK, new { adverts = advertModelViewModels, count });
        }

        [HttpGet]
        [Route("api/SparePartAdverts/My")]
        [Authorize(Roles = "Admin, Member")]
        public HttpResponseMessage GetForUser(int pageNumber, int itemsPerPage, string sortOptions, string filterOptions)
        {
            filterOptions = "(" + filterOptions + (") And UserId=\"" + User.Identity.GetUserId() + "\"");

            return GetAll(pageNumber, itemsPerPage, sortOptions, filterOptions);
        }

        [HttpGet]
        [Route("api/SparePartAdverts/GetById")]
        [AllowAnonymous]
        public IHttpActionResult Get(int id)
        {
            var advertModel = advertService.GetAdvertById(id);
            var viewModel = new SparePartAdvertViewModel();
            Mapper.Map(advertModel, viewModel);
            SetCorrectImagesPaths(viewModel);
            return Ok(viewModel);
        }

        [HttpPost]
        [Route("api/SparePartAdverts/Save")]
        [Authorize(Roles = "Admin, Member")]
        public IHttpActionResult Post(SparePartAdvertViewModel advertModelViewModel)
        {
            var entity = new SparePartAdvert();
            Mapper.Map(advertModelViewModel, entity);
            entity.UserId = User.Identity.GetUserId();
            advertService.AddAdvert(entity);
            Mapper.Map(entity, advertModelViewModel);
            return Created(Url.Link("DefaultApi", new { controller = "Adverts", id = advertModelViewModel.Id }),
                advertModelViewModel);
        }

        [Authorize(Roles = "Admin, Member")]
        public IHttpActionResult Put(int id, SparePartAdvertViewModel advertModelViewModel)
        {
            advertModelViewModel.Id = id;
            var advert = advertService.GetAdvertById(id);
            if (advert.UserId != User.Identity.GetUserId() && !User.IsInRole("Admin"))
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
            if (advert.UserId != User.Identity.GetUserId() && !User.IsInRole("Admin"))
            {
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.Forbidden, "Permission denied"));
            }

            advertService.DeleteAdvert(id);
            return Ok();
        }

        private void SetCorrectImagesPaths(List<SparePartAdvertViewModel> adverts)
        {
            foreach (var advert in adverts)
            {
                foreach (var image in advert.ImageInfos)
                {
                    image.FullName = Url.Content(RelativeUploadPath + image.FullName);
                }
            }
        }

        private void SetCorrectImagesPaths(SparePartAdvertViewModel advert)
        {
            foreach (var image in advert.ImageInfos)
            {
                image.FullName = Url.Content(RelativeUploadPath + image.FullName);
            }
        }
    }
}
