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
    public class CarModelsController : ApiController
    {
        private readonly ICarModelService carModelService;

        public CarModelsController(ICarModelService carModelService)
        {
            this.carModelService = carModelService;
        }

        public IHttpActionResult Get()
        {
            var carModels = carModelService.GetCarModels();
            var carModelViewModels = new List<CarModelViewModel>();
            Mapper.Map(carModels, carModelViewModels);
            return Ok(carModelViewModels);
        }

        public IHttpActionResult Get(int id)
        {
            var carModel = carModelService.GetCarModelById(id);
            var viewModel = new CarModelViewModel();
            Mapper.Map(carModel, viewModel);
            return Ok(viewModel);
        }


        [Authorize(Roles = "Admin")]
        public IHttpActionResult Post(CarModelViewModel carModelViewModel)
        {
            var entity = new CarModel();
            Mapper.Map(carModelViewModel, entity);
            carModelService.AddCarModel(entity);
            Mapper.Map(entity, carModelViewModel);
            return Created(Url.Link("DefaultApi", new { controller = "CarModels", id = carModelViewModel.Id }), carModelViewModel);
        }

        [Authorize(Roles = "Admin")]
        public IHttpActionResult Put(int id, CarModelViewModel carModelViewModel)
        {
            carModelViewModel.Id = id;
            var carModel = carModelService.GetCarModelById(id);
            Mapper.Map(carModelViewModel, carModel);
            carModelService.UpdateCarModel(carModel);
            return Ok(carModelViewModel);
        }

        [Authorize(Roles = "Admin")]
        public IHttpActionResult Delete(int id)
        {
            carModelService.DeleteCarModel(id);
            return Ok();
        }
    }
}
