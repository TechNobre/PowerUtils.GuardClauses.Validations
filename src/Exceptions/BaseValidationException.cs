using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.Serialization;
using PowerUtils.Net.Constants;

namespace PowerUtils.Validations.Exceptions
{
    [Serializable]
    public abstract class BaseValidationException : Exception
    {
        /// <summary>
        /// HTTP status code (int)
        /// </summary>
        public int Status => (int)StatusCode;

        /// <summary>
        /// HTTP status code (enum)
        /// </summary>
        public HttpStatusCode StatusCode { get; private set; }

        /// <summary>
        /// Gets or sets a link to the help file associated with this exception
        /// For HttpExeptions a link to status code information https://tools.ietf.org/html/rfc7231
        /// </summary>
        /// <returns>The Uniform Resource Name (URN) or Uniform Resource Locator (URL)</returns>
        public new string HelpLink { get; private set; }

        /// <summary>
        /// Gets the list of errors
        /// </summary>
        public IEnumerable<KeyValuePair<string, string>> Errors => _errors;
        private Dictionary<string, string> _errors { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseValidationException"></see> class with <paramref name="statusCode">statusCode</paramref> and <paramref name="helpLink">helpLink</paramref>
        /// </summary>
        /// <param name="statusCode">Status code for exception</param>
        /// <param name="helpLink">Link for documentations about the status code</param>
        protected BaseValidationException(HttpStatusCode statusCode, string helpLink)
            : base($"An error occurred with the status code '{statusCode}'")
        {
            StatusCode = statusCode;
            HelpLink = helpLink;
            _errors = new Dictionary<string, string>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseValidationException"></see> class with <paramref name="statusCode">statusCode</paramref>,
        /// <paramref name="helpLink">helpLink</paramref> and a <paramref name="message">specified error message</paramref>
        /// </summary>
        /// <param name="statusCode">Status code for exception</param>
        /// <param name="helpLink">Link for documentations about the status code</param>
        /// <param name="message">The error message that explains the reason for the exception</param>
        protected BaseValidationException(HttpStatusCode statusCode, string helpLink, string message)
            : base(message)
        {
            StatusCode = statusCode;
            HelpLink = helpLink;
            _errors = new Dictionary<string, string>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseValidationException"></see> class with <paramref name="statusCode">statusCode</paramref>,
        /// <paramref name="helpLink">helpLink</paramref>, <paramref name="message">specified error message</paramref> and a <paramref name="innerException">reference to the inner exception that is the cause of this exception</paramref>
        /// </summary>
        /// <param name="statusCode">Status code for exception</param>
        /// <param name="helpLink">Link for documentations about the status code</param>
        /// <param name="message">The error message that explains the reason for the exception</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference if no inner exception is specified</param>
        protected BaseValidationException(HttpStatusCode statusCode, string helpLink, string message, Exception innerException)
            : base(message, innerException)
        {
            StatusCode = statusCode;
            HelpLink = helpLink;
            _errors = new Dictionary<string, string>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseValidationException"></see> class with serialized data
        /// </summary>
        /// <param name="info">The <see cref="SerializationInfo"></see> that holds the serialized object data about the exception being thrown</param>
        /// <param name="context">The <see cref="StreamingContext"></see> that contains contextual information about the source or destination</param>
        /// <exception cref="ArgumentNullException">The <paramref name="info">info</paramref> parameter is null</exception>
        /// <exception cref="SerializationException">The class name is null or <see cref="P:System.Exception.HResult"></see> is zero (0)</exception>
        protected BaseValidationException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            StatusCode = (HttpStatusCode)info.GetValue(nameof(StatusCode), typeof(int));

            HelpLink = ((int)StatusCode).GetStatusCodeLink();
            _errors = new Dictionary<string, string>();
        }

        /// <summary>
        /// Sets the <see cref="SerializationInfo"></see> with information about the exception
        /// </summary>
        /// <param name="info">The <see cref="SerializationInfo"></see> that holds the serialized object data about the exception being thrown</param>
        /// <param name="context">The <see cref="StreamingContext"></see> that contains contextual information about the source or destination</param>
        /// <exception cref="ArgumentNullException">The <paramref name="info">info</paramref> parameter is a null reference (Nothing in Visual Basic)</exception>
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if(info == null)
            {
                throw new ArgumentNullException(nameof(info));
            }

            info.AddValue(nameof(StatusCode), (int)StatusCode);
            base.GetObjectData(info, context);
        }

        protected void AddError(string property, string errorCode)
            => _errors.Add(property, errorCode);
    }
}
