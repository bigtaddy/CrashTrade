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
    public class DbExceptionFilter : ExceptionFilterAttribute
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
                context.Response = context.Request.CreateResponse(HttpStatusCode.Forbidden, new ErrorModel(ex.ToString()));
            }
            logger.Error(ex.ToString());
            base.OnException(context);
        }
    }
}