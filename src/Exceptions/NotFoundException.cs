using System;
using System.Net;
using System.Runtime.Serialization;
using PowerUtils.Net.Constants;

namespace PowerUtils.Validations.Exceptions
{
    /// <summary>
    /// Represents HTTP NotFound (404) errors that occur during application execution
    /// </summary>
    [Obsolete("This package has been discontinued because it never evolved, and the code present in this package does not justify its continuation. It is preferable to implement this code directly in the project if necessary. The package will be completely removed after 2024/02/03.")]
    [Serializable]
    public class NotFoundException : BaseValidationException
    {
        public static readonly HttpStatusCode STATUS_CODE = HttpStatusCode.NotFound;
        public const string HELP_LINK = StatusCodeLink.NOT_FOUND;
        public const string ERROR_CODE = ErrorCodes.NOT_FOUND;

        /// <summary>
        /// Initializes a new instance of the <see cref="NotFoundException"></see> class with status code NotFound
        /// </summary>
        public NotFoundException()
            : base(STATUS_CODE, HELP_LINK)
        { }


        /// <summary>
        /// Initializes a new instance of the <see cref="NotFoundException"></see> class with status code NotFound and a <paramref name="message">specified error message</paramref>
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception</param>
        public NotFoundException(string message)
            : base(STATUS_CODE, HELP_LINK, message)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="NotFoundException"></see> class with status code NotFound, a <paramref name="message">specified error message</paramref>
        /// and a <paramref name="innerException">reference to the inner exception that is the cause of this exception</paramref>
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference if no inner exception is specified</param>
        public NotFoundException(string message, Exception innerException)
            : base(STATUS_CODE, HELP_LINK, message, innerException)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="NotFoundException"></see> class with serialized data
        /// </summary>
        /// <param name="info">The <see cref="SerializationInfo"></see> that holds the serialized object data about the exception being thrown</param>
        /// <param name="context">The <see cref="StreamingContext"></see> that contains contextual information about the source or destination</param>
        /// <exception cref="ArgumentNullException">The <paramref name="info">info</paramref> parameter is null</exception>
        /// <exception cref="SerializationException">The class name is null or <see cref="P:System.Exception.HResult"></see> is zero (0)</exception>
        protected NotFoundException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="NotFoundException"></see> class with status code NotFound, for a <paramref name="property">specified property</paramref>
        /// and a <paramref name="message">specified error message</paramref>
        /// </summary>
        /// <param name="property">Property name</param>
        /// <param name="message">The error message that explains the reason for the exception</param>
        public NotFoundException(string property, string message)
            : base(STATUS_CODE, HELP_LINK, message)
            => AddError(property, ERROR_CODE);

        /// <summary>
        /// Initializes a new instance of the <see cref="NotFoundException"></see> class with status code NotFound, for a <paramref name="property">specified property</paramref>
        /// with a <paramref name="errorCode">error code</paramref> and a <paramref name="message">specified error message</paramref>
        /// </summary>
        /// <param name="property">Property name</param>
        /// <param name="errorCode">Error code of the property</param>
        /// <param name="message">The error message that explains the reason for the exception</param>
        public NotFoundException(string property, string errorCode, string message)
            : base(STATUS_CODE, HELP_LINK, message)
            => AddError(property, errorCode);

        /// <summary>
        /// Initializes a new instance of the <see cref="NotFoundException"></see> class with status code NotFound, for a <paramref name="property">specified property</paramref>
        /// with a <paramref name="errorCode">error code</paramref> and a <paramref name="innerException">reference to the inner exception that is the cause of this exception</paramref>
        /// </summary>
        /// <param name="property">Property name</param>
        /// <param name="errorCode">Error code of the property</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference if no inner exception is specified</param>
        public NotFoundException(string property, string errorCode, Exception innerException)
            : base(STATUS_CODE, HELP_LINK, innerException)
            => AddError(property, errorCode);


        /// <summary>
        /// Thow a <see cref="NotFoundException"></see> class with status code NotFound, for a <paramref name="property">specified property</paramref>
        /// </summary>
        /// <param name="property">Property name</param>
        public static void Throw(string property)
            => throw Factory.Create(property);

        /// <summary>
        /// Thow a <see cref="NotFoundException"></see> class with status code NotFound, for a <paramref name="property">specified property</paramref>
        /// and with a <paramref name="errorCode">error code</paramref>
        /// </summary>
        /// <param name="property">Property name</param>
        /// <param name="errorCode">Error code of the property</param>
        public static void Throw(string property, string errorCode)
            => throw Factory.Create(property, errorCode);



        public static class Factory
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="NotFoundException"></see> class with status code NotFound, for a <paramref name="property">specified property</paramref>
            /// </summary>
            /// <param name="property">Property name</param>
            public static Exception Create(string property)
                => throw new NotFoundException(property, $"The property '{property}' contains the error '{ERROR_CODE}");

            /// <summary>
            /// Initializes a new instance of the <see cref="NotFoundException"></see> class with status code NotFound, for a <paramref name="property">specified property</paramref>
            /// and with a <paramref name="errorCode">error code</paramref>
            /// </summary>
            /// <param name="property">Property name</param>
            /// <param name="errorCode">Error code of the property</param>
            public static Exception Create(string property, string errorCode)
                => new NotFoundException(property, errorCode, $"The property '{property}' contains the error '{errorCode}");
        }
    }
}
