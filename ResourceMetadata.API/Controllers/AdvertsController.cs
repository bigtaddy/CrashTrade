using System;
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
    public class AdvertsController : ApiController
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
        public HttpResponseMessage GetAll(int pageNumber, int itemsPerPage)
        {
            var advertModels = advertService.GetAdverts(pageNumber, itemsPerPage);
            var advertModelViewModels = new List<AdvertViewModel>();
            var count = advertService.GetCount();
            Mapper.Map(advertModels, advertModelViewModels);
            SetCorrectImagesPaths(advertModelViewModels);
            return Request.CreateResponse(HttpStatusCode.OK, new { adverts = advertModelViewModels, count });
        }

        [HttpGet]
        [Route("api/Adverts/My")]
        [Authorize(Roles = "Admin, Member")]
        public HttpResponseMessage GetForUser(int pageNumber, int itemsPerPage)
        {
            var advertModels = advertService.GetAdvertsForUser(pageNumber, itemsPerPage, User.Identity.GetUserId());
            var advertModelViewModels = new List<AdvertViewModel>();
            var count = advertService.GetCount(User.Identity.GetUserId());
            Mapper.Map(advertModels, advertModelViewModels);
            SetCorrectImagesPaths(advertModelViewModels);
            return Request.CreateResponse(HttpStatusCode.OK, new { adverts = advertModelViewModels, count });
        }

        [HttpGet]
        [Route("api/Adverts/Sale")]
        [AllowAnonymous]
        public HttpResponseMessage SaleAdverts(int pageNumber, int itemsPerPage)
        {
            var advertModels = advertService.GetAdverts(AdvertType.Sale, pageNumber, itemsPerPage);
            var advertModelViewModels = new List<AdvertViewModel>();

            var count = advertService.GetCount(AdvertType.Sale);
            Mapper.Map(advertModels, advertModelViewModels);
            SetCorrectImagesPaths(advertModelViewModels);
            return Request.CreateResponse(HttpStatusCode.OK, new { adverts = advertModelViewModels, count });
        }

        [HttpGet]
        [Route("api/Adverts/Repair")]
        [AllowAnonymous]
        public HttpResponseMessage RepairAdverts(int pageNumber, int itemsPerPage)
        {
            var advertModels = advertService.GetAdverts(AdvertType.Repair, pageNumber, itemsPerPage);
            var advertModelViewModels = new List<AdvertViewModel>();

            var count = advertService.GetCount(AdvertType.Repair);
            Mapper.Map(advertModels, advertModelViewModels);
            SetCorrectImagesPaths(advertModelViewModels);
            return Request.CreateResponse(HttpStatusCode.OK, new { adverts = advertModelViewModels, count });
        }

        [AllowAnonymous]
        public IHttpActionResult Get(int id)
        {
            var advertModel = advertService.GetAdvertById(id);
            var viewModel = new AdvertViewModel();
            Mapper.Map(advertModel, viewModel);
            SetCorrectImagesPaths(viewModel);
            return Ok(viewModel);
        }


        [Authorize(Roles = "Admin, Member")]
        public IHttpActionResult Post(AdvertViewModel advertModelViewModel)
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
