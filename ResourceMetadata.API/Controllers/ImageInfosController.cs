using AutoMapper;
using ResourceMetadata.API.Providers;
using ResourceMetadata.API.ViewModels;
using ResourceMetadata.Models;
using ResourceMetadata.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace ResourceMetadata.API.Controllers
{
    public class ImageInfosController : BaseApiController
    {
        private readonly IImageInfoService imageService;
        private readonly IAdvertService advertService;


        private const string RelativeUploadPath = "~/Images/";
        private string uploadPath = HttpContext.Current.Server.MapPath(RelativeUploadPath);

        public ImageInfosController(IImageInfoService imageInfoService, IAdvertService advertService)
        {
            this.imageService = imageInfoService;
            this.advertService = advertService;
        }


        [HttpPost]
        [Authorize(Roles = "Admin, Member")]
        [Route("api/Images/{id}")]
        public async Task<HttpResponseMessage> Post(int id)
        {
            var advertModel = advertService.GetAdvertById(id);

            /* if (advertModel.UserId != User.Identity.GetUserId())
             {
                 return Request.CreateResponse(HttpStatusCode.Forbidden);
             }*/

            if (advertModel == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            if (!Request.Content.IsMimeMultipartContent())
            {
                return Request.CreateResponse(HttpStatusCode.UnsupportedMediaType);
            }

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
                    if (string.IsNullOrEmpty(file.Headers.ContentDisposition.FileName))
                    {
                        throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotAcceptable, "This request is not properly formatted"));
                    }

                    var fi = new FileInfo(file.LocalFileName);

                    advertModel.ImageInfos.Add(new ImageInfo
                    {
                        FullName = fi.Name,
                        AdvertId = advertModel.Id
                 
                    });
                }
                advertService.UpdateAdvert(advertModel);

            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }


            return Request.CreateResponse(HttpStatusCode.OK);
        }


        [HttpGet]
        [AllowAnonymous]
        [Route("api/Images/{id}")]
        public IHttpActionResult GetbyAdvertId(int id)
        {
            var advertModel = advertService.GetAdvertById(id);
            var images = Mapper.Map<ICollection<ImageInfo>, ICollection<ImageViewModel>>(advertModel.ImageInfos);

            foreach (var image in images)
            {
                image.FullName = Url.Content(RelativeUploadPath + image.FullName);
            }
            return Ok(images);
        }


        [HttpPost]
        [Authorize(Roles = "Admin, Member")]
        [Route("api/Images/DeleteByIds")]
        public HttpResponseMessage DeleteByIds(int[] ids)
        {
            foreach (var id in ids)
            {   
                var image = imageService.GetById(id);
                if (image != null) {
                    File.Delete(uploadPath + image.FullName);
                    imageService.Delete(id);
                }
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

    }

 
}