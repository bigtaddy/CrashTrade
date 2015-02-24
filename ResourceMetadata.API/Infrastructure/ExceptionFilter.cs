using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;
using ResourceMetadata.API.Models;

namespace ResourceMetadata.API.Infrastructure
{
    /// <summary>
    /// Exception handler
    /// </summary>
    public class ExceptionFilter : ExceptionFilterAttribute
    {
        /// <summary>
        /// Called when [exception].
        /// </summary>
        /// <param name="context">The context.</param>
        public override void OnException(HttpActionExecutedContext context)
        {
            var logger = NLog.LogManager.GetCurrentClassLogger();
            Exception ex = context.Exception;
            if (ex is DbException)
            {
                context.Response = context.Request.CreateResponse(HttpStatusCode.InternalServerError,
                    new ErrorModel(ex.ToString()));
            }

            var requestIdHeader = context.Request.Headers.FirstOrDefault(x => x.Key.Equals("RequestId"));
            var errorText = string.Empty;
            if (requestIdHeader.Value != null)
            {
                errorText = string.Format("Request with id = {0} has failed.{1} ",
                    string.Join("", requestIdHeader.Value), Environment.NewLine);
            }
            errorText += string.Format("Error Details: " + ex);
            logger.Error(errorText);
            base.OnException(context);
        }
    }
}