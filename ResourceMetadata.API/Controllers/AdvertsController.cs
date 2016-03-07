using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using AutoMapper;
using Microsoft.AspNet.Identity;
using ResourceMetadata.API.ViewModels;
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

        #region [Base Actions]

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="itemsPerPage">The items per page.</param>
        /// <param name="sortOptions">The sort options.</param>
        /// <param name="filterOptions">The filter options.</param>
        /// <param name="list">The list.</param>
        /// <returns></returns>
        private HttpResponseMessage GetAll<T>(int pageNumber, int itemsPerPage, string sortOptions, string filterOptions, List<T> list) where T : UniversalAdvertViewModel
        {
            var advertModels = advertService.GetAdverts(pageNumber, itemsPerPage, sortOptions, filterOptions);

            var count = advertService.GetCount(filterOptions);
            Mapper.Map(advertModels, list);
            SetCorrectImagesPaths(list);
            return Request.CreateResponse(HttpStatusCode.OK, new { adverts = list, count });
        }

        /// <summary>
        /// Gets all limited.
        /// </summary>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="itemsPerPage">The items per page.</param>
        /// <param name="sortOptions">The sort options.</param>
        /// <param name="filterOptions">The filter options.</param>
        /// <returns></returns>
        private HttpResponseMessage GetAllLimited(int pageNumber, int itemsPerPage, string sortOptions, string filterOptions)
        {
            var advertModels = advertService.GetAdverts(pageNumber, itemsPerPage, sortOptions, filterOptions);
            var advertModelViewModels = new List<LimitedAdvertViewModel>();
            var count = advertService.GetCount(filterOptions);
            Mapper.Map(advertModels, advertModelViewModels);
            return Request.CreateResponse(HttpStatusCode.OK, new { adverts = advertModelViewModels, count });
        }

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="viewModel">The view model.</param>
        /// <returns></returns>
        private IHttpActionResult GetById(int id, UniversalAdvertViewModel viewModel)
        {
            var advertModel = advertService.GetAdvertById(id);
            Mapper.Map(advertModel, viewModel);
            SetCorrectImagesPaths(viewModel);
            return Ok(viewModel);
        }

        /// <summary>
        /// Posts the specified advert model view model.
        /// </summary>
        /// <param name="advertModelViewModel">The advert model view model.</param>
        /// <returns></returns>
        private IHttpActionResult Post(UniversalAdvertViewModel advertModelViewModel, bool isSparePart)
        {
            var entity = new Advert();
            Mapper.Map(advertModelViewModel, entity);
            entity.UserId = User.Identity.GetUserId();
            entity.SparePartType = isSparePart;
            advertService.AddAdvert(entity);
            Mapper.Map(entity, advertModelViewModel);
            return Created(Url.Link("DefaultApi", new { controller = "Adverts", id = advertModelViewModel.Id }),
                advertModelViewModel);
        }

        /// <summary>
        /// Puts the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="advertModelViewModel">The advert model view model.</param>
        /// <returns></returns>
        private IHttpActionResult Put(int id, UniversalAdvertViewModel advertModelViewModel)
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

        #endregion [Base Actions]

        #region [Actions]

        [HttpGet]
        [Route("api/Adverts/GetAllSale")]
        [AllowAnonymous]
        public HttpResponseMessage GetAllSale(int pageNumber, int itemsPerPage, string sortOptions, string filterOptions)
        {
            filterOptions = "(" + filterOptions + (") And SaleType = true");
            var list = new List<AdvertViewModel>();
            return GetAll(pageNumber, itemsPerPage, sortOptions, filterOptions, list);
        }

        [HttpGet]
        [Route("api/Adverts/GetAllSparePart")]
        [AllowAnonymous]
        public HttpResponseMessage GetAllSparePart(int pageNumber, int itemsPerPage, string sortOptions, string filterOptions)
        {
            filterOptions = "(" + filterOptions + (") And SparePartType = true");
            var list = new List<SparePartAdvertViewModel>();
            return GetAll(pageNumber, itemsPerPage, sortOptions, filterOptions, list);
        }

        [HttpGet]
        [Route("api/Adverts/GetAllMechanicalRepair")]
        [AllowAnonymous]
        public HttpResponseMessage GetAllMechanicalRepair(int pageNumber, int itemsPerPage, string sortOptions, string filterOptions)
        {
            filterOptions = "(" + filterOptions + (") And MechanicalRepairType = true");
            var list = new List<AdvertViewModel>();
            return GetAll(pageNumber, itemsPerPage, sortOptions, filterOptions, list);
        }

        [HttpGet]
        [Route("api/Adverts/GetAllCoachworkRepair")]
        [AllowAnonymous]
        public HttpResponseMessage GetAllCoachworkRepair(int pageNumber, int itemsPerPage, string sortOptions, string filterOptions)
        {
            filterOptions = "(" + filterOptions + (") And CoachworkRepairType = true");
            var list = new List<AdvertViewModel>();
            return GetAll(pageNumber, itemsPerPage, sortOptions, filterOptions, list);
        }

        [HttpGet]
        [Route("api/Adverts/My")]
        [Authorize(Roles = "Admin, Member")]
        public HttpResponseMessage GetForUser(int pageNumber, int itemsPerPage, string sortOptions, string filterOptions)
        {
            filterOptions = "(" + filterOptions + (") And UserId=\"" + User.Identity.GetUserId() + "\"");
            var list = new List<UniversalAdvertViewModel>();
            return GetAll(pageNumber, itemsPerPage, sortOptions, filterOptions, list);
        }

        [HttpGet]
        [Route("api/Adverts/GetById")]
        [AllowAnonymous]
        public IHttpActionResult GetAdvert(int id)
        {
            var viewModel = new AdvertViewModel();
            return GetById(id, viewModel);
        }

        [HttpGet]
        [Route("api/SparePartAdverts/GetById")]
        [AllowAnonymous]
        public IHttpActionResult GetSparePartAdvert(int id)
        {
            var viewModel = new SparePartAdvertViewModel();
            return GetById(id, viewModel);
        }

        [HttpPost]
        [Route("api/Adverts/Create")]
        [Authorize(Roles = "Admin, Member")]
        public IHttpActionResult PostAdvert(AdvertViewModel advertModelViewModel)
        {
            return Post(advertModelViewModel, false);
        }

        [HttpPost]
        [Route("api/SparePartAdverts/Create")]
        [Authorize(Roles = "Admin, Member")]
        public IHttpActionResult PostSparePartAdvert(SparePartAdvertViewModel advertModelViewModel)
        {
            return Post(advertModelViewModel, true);
        }

        [HttpPut]
        [Route("api/Adverts/Edit/{id}")]
        [Authorize(Roles = "Admin, Member")]
        public IHttpActionResult PutAdvert(int id, AdvertViewModel advertModelViewModel)
        {
            return Put(id, advertModelViewModel);
        }

        [HttpPut]
        [Route("api/SparePartAdverts/Edit/{id}")]
        [Authorize(Roles = "Admin, Member")]
        public IHttpActionResult PutSparePartAdvert(int id, SparePartAdvertViewModel advertModelViewModel)
        {
            return Put(id, advertModelViewModel);
        }

        [HttpDelete]
        [Route("api/Adverts/Delete")]
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

        #endregion [Actions]

        #region [Auxiliary Functions]

        /// <summary>
        /// Determines whether [is user has access to repair adverts].
        /// </summary>
        /// <returns></returns>
        private bool IsUserHasAccessToRepairAdverts()
        {
            if (User.IsInRole("Admin") || User.IsInRole("PremiumMember"))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Sets the correct images paths.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="adverts">The adverts.</param>
        private void SetCorrectImagesPaths<T>(List<T> adverts) where T : UniversalAdvertViewModel
        {
            foreach (var advert in adverts)
            {
                foreach (var image in advert.ImageInfos)
                {
                    image.FullName = Url.Content(RelativeUploadPath + image.FullName);
                }
            }
        }

        /// <summary>
        /// Sets the correct images paths.
        /// </summary>
        /// <param name="advert">The advert.</param>
        private void SetCorrectImagesPaths(UniversalAdvertViewModel advert)
        {
            foreach (var image in advert.ImageInfos)
            {
                image.FullName = Url.Content(RelativeUploadPath + image.FullName);
            }
        }

        #endregion [Auxiliary Functions]

    }

}
