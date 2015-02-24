using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ResourceMetadata.API.Models
{
    public class ErrorModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorModel"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public ErrorModel(string message)
        {
            this.Message = message;
        }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>
        /// The message.
        /// </value>
        public string Message { get; set; }
    }
}