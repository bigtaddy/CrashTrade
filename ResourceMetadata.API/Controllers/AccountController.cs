using AutoMapper;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using ResourceMetadata.Models;
using ResourceMetadata.Service;
using ResourceMetadata.API.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Microsoft.AspNet.Identity.Owin;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ResourceMetadata.API.Controllers
{
    //http://bitoftech.net/2015/01/21/asp-net-identity-2-with-asp-net-web-api-2-accounts-management/

    public class AccountController : BaseApiController
    {

        [Route("api/Account/GetUsers")]
        public IHttpActionResult GetUsers()
        {
            return Ok(this.AppUserManager.Users.ToList().Select(u => this.TheModelFactory.Create(u)));
        }

        [Route("api/Account/GetUserById")]
        public async Task<IHttpActionResult> GetUserById(string Id)
        {
            var user = await this.AppUserManager.FindByIdAsync(Id);

            if (user != null)
            {
                return Ok(this.TheModelFactory.Create(user));
            }

            return NotFound();

        }

        [HttpPost]
        [Route("api/Account/GetCurrentUser")]
        public async Task<IHttpActionResult> GetCurrentUser()
        {
           var currentUserId = User.Identity.GetUserId();

           var user = await this.AppUserManager.FindByIdAsync(currentUserId);

           if (user != null)
           {
               return Ok(this.TheModelFactory.Create(user));
           }

           return NotFound();
        }

        [Route("api/Account/GetUserByName")]
        public async Task<IHttpActionResult> GetUserByName(string username)
        {
            var user = await this.AppUserManager.FindByNameAsync(username);

            if (user != null)
            {
                return Ok(this.TheModelFactory.Create(user));
            }

            return NotFound();

        }


        [HttpPost]
        [Route("api/Account/Register")]
        [AllowAnonymous]
        public async Task<IHttpActionResult> CreateUser(RegisterViewModel viewModel)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                ApplicationUser user = new ApplicationUser();
                Mapper.Map(viewModel, user);

                user.JoinDate = DateTime.Now.Date;

                var identityResult = await this.AppUserManager.CreateAsync(user, viewModel.Password);

                if (identityResult.Succeeded)
                {
                    this.AppUserManager.AddToRole(user.Id, "Member");

                    string code = await this.AppUserManager.GenerateEmailConfirmationTokenAsync(user.Id);

                    var callbackUrl = "http://c-tr.by/#/Login/?userId=" + user.Id + "&code=" + Base64ForUrlEncode(code);

                   // var callbackUrl = new Uri(Url.Link("ConfirmEmailRoute", new { userId = user.Id, code = code }));

                    await this.AppUserManager.SendEmailAsync(user.Id,
                                                            "Подтвердите ваш аккаунт",
                                                            "Пожалуйста подтвердите ваш аккаунт перейдя по <a href=\"" + callbackUrl + "\">ссылке</a>");

                    return Ok();

                   // Uri locationHeader = new Uri(Url.Link("GetUserById", new { id = user.Id }));

                   // return Created(locationHeader, TheModelFactory.Create(user));
                }
                else
                {
                    return GetErrorResult(identityResult);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }


        [HttpPost]
        [AllowAnonymous]
        [Route("api/Account/ConfirmEmail", Name = "ConfirmEmailRoute")]
        public async Task<IHttpActionResult> ConfirmEmail(ConfirmEmailModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IdentityResult result = await this.AppUserManager.ConfirmEmailAsync(model.userId, Base64ForUrlDecode(model.code));

            if (result.Succeeded)
            {
                return Ok();
            }
            else
            {
                return GetErrorResult(result);
            }
        }


        [HttpPost]
        [Route("api/Account/ChangePassword")]
        public async Task<IHttpActionResult> ChangePassword(ChangePasswordBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IdentityResult result = await this.AppUserManager.ChangePasswordAsync(User.Identity.GetUserId(), model.OldPassword, model.NewPassword);

            if (!result.Succeeded)
            {
                return GetErrorResult(result);
            }

            return Ok();
        }


        [HttpPost]
        [Authorize(Roles = "Admin")]
        [Route("api/Account/DeleteUser/{id:guid}")]
        public async Task<IHttpActionResult> DeleteUser(string id)
        {

            //Only SuperAdmin or Admin can delete users (Later when implement roles)

            var appUser = await this.AppUserManager.FindByIdAsync(id);

            if (appUser != null)
            {
                IdentityResult result = await this.AppUserManager.DeleteAsync(appUser);

                if (!result.Succeeded)
                {
                    return GetErrorResult(result);
                }

                return Ok();

            }

            return NotFound();

        }


        public static string Base64ForUrlEncode(string str)
        {
            var encbuff = Encoding.UTF8.GetBytes(str);
            return HttpServerUtility.UrlTokenEncode(encbuff);
        }

        public static string Base64ForUrlDecode(string str)
        {
            var decbuff = HttpServerUtility.UrlTokenDecode(str);
            return decbuff != null ? Encoding.UTF8.GetString(decbuff) : null;
        }

    }

    public class ConfirmEmailModel
    {
        [Required]
        public string userId { get; set; }

        [Required]
        public string code { get; set; }

    }

    public class ChangePasswordBindingModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

    }
}