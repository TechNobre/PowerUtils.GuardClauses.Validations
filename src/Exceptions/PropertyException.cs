using System;
using System.Runtime.Serialization;

namespace PowerUtils.Validations.Exceptions
{
    /// <summary>
    /// Represents HTTP BadRequest (400) errors that occur during application execution
    /// </summary>
    [Serializable]
    public class PropertyException : BadRequestException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PropertyException"></see> class with status code BadRequest
        /// </summary>
        public PropertyException()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="PropertyException"></see> class with status code BadRequest and a <paramref name="message">specified error message</paramref>
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception</param>
        public PropertyException(string message)
            : base(message)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="PropertyException"></see> class with status code BadRequest, a <paramref name="message">specified error message</paramref>
        /// and a <paramref name="innerException">reference to the inner exception that is the cause of this exception</paramref>
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference if no inner exception is specified</param>
        public PropertyException(string message, Exception innerException)
            : base(message, innerException)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="PropertyException"></see> class with serialized data
        /// </summary>
        /// <param name="info">The <see cref="SerializationInfo"></see> that holds the serialized object data about the exception being thrown</param>
        /// <param name="context">The <see cref="StreamingContext"></see> that contains contextual information about the source or destination</param>
        /// <exception cref="ArgumentNullException">The <paramref name="info">info</paramref> parameter is null</exception>
        /// <exception cref="SerializationException">The class name is null or <see cref="P:System.Exception.HResult"></see> is zero (0)</exception>
        protected PropertyException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="PropertyException"></see> class with status code BadRequest, for a <paramref name="property">specified property</paramref>
        /// and with a <paramref name="errorCode">error code</paramref>
        /// </summary>
        /// <param name="property">Property name</param>
        /// <param name="errorCode">Error code of the property</param>
        public PropertyException(string property, string errorCode)
            : base(property, errorCode)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="PropertyException"></see> class with status code BadRequest, for a <paramref name="property">specified property</paramref>
        /// with a <paramref name="errorCode">error code</paramref> and a <paramref name="message">specified error message</paramref>
        /// </summary>
        /// <param name="property">Property name</param>
        /// <param name="errorCode">Error code of the property</param>
        /// <param name="message">The error message that explains the reason for the exception</param>
        public PropertyException(string property, string errorCode, string message)
            : base(property, errorCode, message)
        { }


        /// <summary>
        /// Thow a <see cref="PropertyException"></see> class with status code BadRequest, for a <paramref name="property">specified property</paramref>
        /// and with a <paramref name="errorCode">error code</paramref>
        /// </summary>
        /// <param name="property">Property name</param>
        /// <param name="errorCode">Error code of the property</param>
        public static new void Throw(string property, string errorCode)
            => throw Factory.Create(property, errorCode);

        /// <summary>
        /// Thow a <see cref="PropertyException"></see> class with status code BadRequest, for a <paramref name="property">specified property</paramref>
        /// and with a INVALID error code
        /// </summary>
        /// <param name="property">Property name</param>
        public static new void ThrowInvalid(string property)
            => throw Factory.CreateInvalid(property);

        /// <summary>
        /// Thow a <see cref="PropertyException"></see> class with status code BadRequest, for a <paramref name="property">specified property</paramref>
        /// and with a REQUIRED error code
        /// </summary>
        /// <param name="property">Property name</param>
        public static new void ThrowRequired(string property)
            => throw Factory.CreateRequired(property);



        public static new class Factory
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="PropertyException"></see> class with status code BadRequest, for a <paramref name="property">specified property</paramref>
            /// and with a <paramref name="errorCode">error code</paramref>
            /// </summary>
            /// <param name="property">Property name</param>
            /// <param name="errorCode">Error code of the property</param>
            public static Exception Create(string property, string errorCode)
                => throw new PropertyException(property, errorCode, $"The property '{property}' contains the error '{errorCode}");

            /// <summary>
            /// Initializes a new instance of the <see cref="PropertyException"></see> class with status code BadRequest, for a <paramref name="property">specified property</paramref>
            /// and with a INVALID error code
            /// </summary>
            /// <param name="property">Property name</param>
            public static Exception CreateInvalid(string property)
                => Create(property, ErrorCodes.INVALID);

            /// <summary>
            /// Initializes a new instance of the <see cref="PropertyException"></see> class with status code BadRequest, for a <paramref name="property">specified property</paramref>
            /// and with a REQUIRED error code
            /// </summary>
            /// <param name="property">Property name</param>
            public static Exception CreateRequired(string property)
                => Create(property, ErrorCodes.REQUIRED);
        }
    }
}
