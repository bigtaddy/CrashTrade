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
    public class ManufacturesController : ApiController
    {
        private readonly IManufactureService manufactureService;

        public ManufacturesController(IManufactureService manufactureService)
        {
            this.manufactureService = manufactureService;
        }

        public IHttpActionResult Get()
        {
            var manufactures = manufactureService.GetManufactures();
            var manufactureViewModels = new List<ManufactureViewModel>();
            Mapper.Map(manufactures, manufactureViewModels);
            return Ok(manufactureViewModels);
        }

        public IHttpActionResult Get(int id)
        {
            var manufacture = manufactureService.GetManufactureById(id);
            var viewModel = new ManufactureViewModel();
            Mapper.Map(manufacture, viewModel);
            return Ok(viewModel);
        }


        [Authorize(Roles = "Admin")]
        public IHttpActionResult Post(ManufactureViewModel manufacture)
        {
            var entity = new Manufacture();
            Mapper.Map(manufacture, entity);
            manufactureService.AddManufacture(entity);
            Mapper.Map(entity, manufacture);
            return Created(Url.Link("DefaultApi", new { controller = "Manufactures", id = manufacture.Id }), manufacture);
        }

        [Authorize(Roles = "Admin")]
        public IHttpActionResult Put(int id, ManufactureViewModel manufactureViewModel)
        {
            manufactureViewModel.Id = id;
            var manufacture = manufactureService.GetManufactureById(id);
            Mapper.Map(manufactureViewModel, manufacture);
            manufactureService.UpdateManufacture(manufacture);
            return Ok(manufactureViewModel);
        }

        [Authorize(Roles = "Admin")]
        public IHttpActionResult Delete(int id)
        {
            manufactureService.DeleteManufacture(id);
            return Ok();
        }


    }
}
