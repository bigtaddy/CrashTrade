using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using ResourceMetadata.API.ViewModels;
using ResourceMetadata.Models;
using ResourceMetadata.Service;

namespace ResourceMetadata.API.Controllers
{
    public class AdvertController : ApiController
    {
        private readonly IAdvertService advertService;

        public AdvertController(IAdvertService advertService)
        {
            this.advertService = advertService;
        }

        public IHttpActionResult Get()
        {
            var advertModels = advertService.GetAdverts();
            var advertModelViewModels = new List<AdvertViewModel>();
            Mapper.Map(advertModels, advertModelViewModels);
            return Ok(advertModelViewModels);
        }

        public IHttpActionResult Get(int id)
        {
            var advertModel = advertService.GetAdvertById(id);
            var viewModel = new AdvertViewModel();
            Mapper.Map(advertModel, viewModel);
            return Ok(viewModel);
        }


        [Authorize(Roles = "Admin")]
        public IHttpActionResult Post(AdvertViewModel advertModelViewModel)
        {
            var entity = new Advert();
            Mapper.Map(advertModelViewModel, entity);
            advertService.AddAdvert(entity);
            Mapper.Map(entity, advertModelViewModel);
            return Created(Url.Link("DefaultApi", new { controller = "Advert", id = advertModelViewModel.Id }), advertModelViewModel);
        }

        [Authorize(Roles = "Admin")]
        public IHttpActionResult Put(int id, AdvertViewModel advertModelViewModel)
        {
            advertModelViewModel.Id = id;
            var carModel = advertService.GetAdvertById(id);
            Mapper.Map(advertModelViewModel, carModel);
            advertService.UpdateAdvert(carModel);
            return Ok(advertModelViewModel);
        }

        [Authorize(Roles = "Admin")]
        public IHttpActionResult Delete(int id)
        {
            advertService.DeleteAdvert(id);
            return Ok();
        }
    }
}
