using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using AutoMapper;
using Microsoft.AspNet.Identity;
using ResourceMetadata.API.ViewModels;
using ResourceMetadata.Models;
using ResourceMetadata.Service;

namespace ResourceMetadata.API.Controllers
{
    public class AdvertsController : ApiController
    {
        private readonly IAdvertService advertService;

        public AdvertsController(IAdvertService advertService)
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

        [HttpGet]
        [Route("api/Adverts/Sale")]
        public HttpResponseMessage SaleAdverts(int pageNumber, int itemsPerPage)
        {
            var advertModels = advertService.GetAdverts(AdvertType.Sale, pageNumber, itemsPerPage);
            var advertModelViewModels = new List<AdvertViewModel>();

            var count = advertService.GetCount(AdvertType.Sale);
            Mapper.Map(advertModels, advertModelViewModels);
            return Request.CreateResponse(HttpStatusCode.OK, new { adverts = advertModelViewModels, count });
        }

        [HttpGet]
        [Route("api/Adverts/Repair")]
        public HttpResponseMessage RepairAdverts(int pageNumber, int itemsPerPage)
        {
            var advertModels = advertService.GetAdverts(AdvertType.Repair, pageNumber, itemsPerPage);
            var advertModelViewModels = new List<AdvertViewModel>();

            var count = advertService.GetCount(AdvertType.Repair);
            Mapper.Map(advertModels, advertModelViewModels);
            return Request.CreateResponse(HttpStatusCode.OK, new { adverts = advertModelViewModels, count });
        }

        public IHttpActionResult Get(int id)
        {
            var advertModel = advertService.GetAdvertById(id);
            var viewModel = new AdvertViewModel();
            Mapper.Map(advertModel, viewModel);
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
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.InternalServerError, "Permission denied"));
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


   


        [HttpPost]
        [Authorize(Roles = "Admin, Member")]
        [Route("api/Adverts/UploadImage/{id}")]
        public async Task<HttpResponseMessage> UploadImage(int id )
        {
            var advertModel = advertService.GetAdvertById(id);

            if (advertModel.UserId != User.Identity.GetUserId())
            {
                return Request.CreateResponse(HttpStatusCode.Forbidden);
            }

            string uploadPath = HttpContext.Current.Server.MapPath("~/App_Data/FileUploads");

            if (Request.Content.IsMimeMultipartContent())
            {
                try
                {
                    if (!Directory.Exists(uploadPath))
                    {
                        Directory.CreateDirectory(uploadPath);
                    }

                    var streamProvider = new MyStreamProvider(uploadPath);

                    await Request.Content.ReadAsMultipartAsync(streamProvider);


                    foreach (var file in streamProvider.FileData)
                    {
                        var fi = new FileInfo(file.LocalFileName);

                        advertModel.ImageInfos.Add(new ImageInfo
                        {
                            FullName = fi.FullName
                        });                   
                    }
                    advertService.UpdateAdvert(advertModel);

                }
                catch (Exception e)
                {

                }
            }
            else
            {
                Request.CreateResponse(HttpStatusCode.UnsupportedMediaType);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }



    }

    public class MyStreamProvider : MultipartFormDataStreamProvider
    {
        public MyStreamProvider(string uploadPath)
            : base(uploadPath)
        {
        }
        public override string GetLocalFileName(HttpContentHeaders headers)
        {
            string fileName = Guid.NewGuid().ToString()
                + Path.GetExtension(headers.ContentDisposition.FileName.Replace("\"", string.Empty));
            return fileName;
        }
    }
}
