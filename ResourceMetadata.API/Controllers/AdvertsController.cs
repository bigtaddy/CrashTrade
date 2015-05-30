using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Web.Http.Results;
using AutoMapper;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json;
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
        public IHttpActionResult SaleAdverts()
        {
            var advertModels = advertService.GetAdverts(AdvertType.Sale);
            var advertModelViewModels = new List<AdvertViewModel>();
            Mapper.Map(advertModels, advertModelViewModels);
            return Ok(advertModelViewModels);
        }

        [HttpGet]
        [Route("api/Adverts/Repair")]
        public IHttpActionResult RepairAdverts()
        {
            var advertModels = advertService.GetAdverts(AdvertType.Repair);
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


        [Authorize(Roles = "Admin, Member")]
        public IHttpActionResult Post(AdvertViewModel advertModelViewModel)
        {
            var entity = new Advert();
            Mapper.Map(advertModelViewModel, entity);
            entity.UserId = User.Identity.GetUserId();
            advertService.AddAdvert(entity);
            Mapper.Map(entity, advertModelViewModel);
            return Created(Url.Link("DefaultApi", new { controller = "Adverts", id = advertModelViewModel.Id }), advertModelViewModel);
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
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.InternalServerError, "Permission denied"));
            }

            advertService.DeleteAdvert(id);
            return Ok();
        }

        [HttpPost]
        [Authorize(Roles = "Admin, Member")]
        [Route("api/Adverts/UploadImage")]
        public IHttpActionResult UploadImage()
        {
            if (!Request.Content.IsMimeMultipartContent())
            {
                return ResponseMessage(this.Request.CreateResponse(HttpStatusCode.UnsupportedMediaType));
            }

//var provider = GetMultipartProvider();
  //   //       var result = await Request.Content.ReadAsMultipartAsync(provider);

            // On upload, files are given a generic name like "BodyPart_26d6abe1-3ae1-416a-9429-b35f15e6e5d5"
            // so this is how you can get the original file name
        //    var originalFileName = GetDeserializedFileName(result.FileData.First());

            // uploadedFileInfo object will give you some additional stuff like file length,
            // creation time, directory name, a few filesystem methods etc..
    //        var uploadedFileInfo = new FileInfo(result.FileData.First().LocalFileName);

            // Remove this line as well as GetFormData method if you're not
            // sending any form data with your upload request
      //      var fileUploadObj = GetFormData<UploadDataModel>(result);

            // Through the request response you can return an object to the Angular controller
            // You will be able to access this in the .success callback through its data attribute
            // If you want to send something to the .error callback, use the HttpStatusCode.BadRequest instead
            var returnData = "ReturnTest";
            return ResponseMessage(this.Request.CreateResponse(HttpStatusCode.OK, new {returnData}));
        }

        // You could extract these two private methods to a separate utility class since
        // they do not really belong to a controller class but that is up to you
        private MultipartFormDataStreamProvider GetMultipartProvider()
        {
            // IMPORTANT: replace "(tilde)" with the real tilde character
            // (our editor doesn't allow it, so I just wrote "(tilde)" instead)
            var uploadFolder = "(tilde)/App_Data/Tmp/FileUploads"; // you could put this to web.config
            var root = HttpContext.Current.Server.MapPath(uploadFolder);
            Directory.CreateDirectory(root);
            return new MultipartFormDataStreamProvider(root);
        }

        // Extracts Request FormatData as a strongly typed model
        private object GetFormData<T>(MultipartFormDataStreamProvider result)
        {
            if (result.FormData.HasKeys())
            {
                var unescapedFormData = Uri.UnescapeDataString(result.FormData
                    .GetValues(0).FirstOrDefault() ?? String.Empty);
                if (!String.IsNullOrEmpty(unescapedFormData))
                    return JsonConvert.DeserializeObject<T>(unescapedFormData);
            }

            return null;
        }

        private string GetDeserializedFileName(MultipartFileData fileData)
        {
            var fileName = GetFileName(fileData);
            return JsonConvert.DeserializeObject(fileName).ToString();
        }

        public string GetFileName(MultipartFileData fileData)
        {
            return fileData.Headers.ContentDisposition.FileName;
        }






    }
}
