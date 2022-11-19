using System;
using System.IO;
using System.Net;
using System.Runtime.Serialization;
using FluentAssertions;
using PowerUtils.Validations;
using PowerUtils.Validations.Exceptions;
using Xunit;

namespace PowerUtils.GuardClauses.Validations.Tests.ExceptionsTests
{
    public class PropertyExceptionTests
    {
        [Fact]
        public void PropertyException_Constructor_WithoutParameters()
        {
            // Arrange && Act
            var act = new PropertyException();


            // Assert
            act.Validate(HttpStatusCode.BadRequest);
        }

        [Fact]
        public void PropertyException_Constructor_WithMessage()
        {
            // Arrange
            var message = "Fake message";


            // Act
            var act = new PropertyException(message);


            // Assert
            act.Validate(HttpStatusCode.BadRequest, message);
        }

        [Fact]
        public void PropertyException_Constructor_WithMessageAndInnerException()
        {
            // Arrange
            var message = "Fake message";
            var innerException = new InvalidOperationException();


            // Act
            var act = new PropertyException(message, innerException);


            // Assert
            act.Validate<InvalidOperationException>(HttpStatusCode.BadRequest, message);
        }

        [Fact]
        public void PropertyException_SerializeDeserialize_Equivalent()
        {
            // Arrange
            var exception = new PropertyException();


            // Act
            BaseValidationException act;
            using(var memoryStream = new MemoryStream())
            {
                var dataContractSerializer = new DataContractSerializer(typeof(PropertyException));

                dataContractSerializer.WriteObject(memoryStream, exception);

                memoryStream.Seek(0, SeekOrigin.Begin);

                act = (PropertyException)dataContractSerializer.ReadObject(memoryStream);
            }


            // Assert
            act.Should()
                .BeEquivalentTo(exception);

            act.Validate(HttpStatusCode.BadRequest);
        }

        [Fact]
        public void NullInfo_GetObjectData_ArgumentNullException()
        {
            // Arrange
            var exception = new PropertyException();


            // Act
            var act = Record.Exception(() => exception.GetObjectData(null, new StreamingContext()));


            // Assert
            act.Should()
                .BeOfType<ArgumentNullException>();
        }

        [Fact]
        public void ErrorCodeAndProperty_Constructor_WithError()
        {
            // Arrange
            var property = "FakeProp";
            var errorCode = "FakeError";


            // Act
            var act = new PropertyException(property, errorCode);


            // Assert
            act.Validate(HttpStatusCode.BadRequest, property, errorCode);
        }


        [Fact]
        public void ErrorCodePropertyAndMessage_Constructor_WithErrorAndMessage()
        {
            // Arrange
            var property = "FakeProp";
            var errorCode = "FakeError";
            var message = "FakeMessafe";


            // Act
            var act = new PropertyException(property, errorCode, message);


            // Assert
            act.Validate(HttpStatusCode.BadRequest, property, errorCode, message);
        }


        [Fact]
        public void ErrorCodeAndProperty_Throw_WithError()
        {
            // Arrange
            var property = "FakeProp";
            var errorCode = "FakeError2";


            // Act
            var act = Record.Exception(() => PropertyException.Throw(property, errorCode));


            // Assert
            act.Validate<PropertyException>(HttpStatusCode.BadRequest, property, errorCode, "The property 'FakeProp' contains the error 'FakeError2");
        }


        [Fact]
        public void Property_Throw_InvalidError()
        {
            // Arrange
            var property = "FakeProp2";


            // Act
            var act = Record.Exception(() => PropertyException.ThrowInvalid(property));


            // Assert
            act.Validate<PropertyException>(HttpStatusCode.BadRequest, property, ErrorCodes.INVALID, "The property 'FakeProp2' contains the error 'INVALID");
        }


        [Fact]
        public void Property_ThrowRequired_RequiredError()
        {
            // Arrange
            var property = "FakeProp";


            // Act
            var act = Record.Exception(() => PropertyException.ThrowRequired(property));


            // Assert
            act.Validate<PropertyException>(HttpStatusCode.BadRequest, property, ErrorCodes.REQUIRED, "The property 'FakeProp' contains the error 'REQUIRED");
        }

        [Fact]
        public void PropertyErrorCodeAndInnerException_Instance_ExceptionWithInnerException()
        {
            // Arrange
            var property = "propFakeNotFound";
            var errorCode = "codeFakeNotFound";
            var innerException = new InvalidCastException();


            // Act
            var act = new PropertyException(property, errorCode, innerException);


            // Assert
            act.Validate<PropertyException, InvalidCastException>(
                HttpStatusCode.BadRequest,
                property,
                errorCode,
                "An error occurred with the status code 'BadRequest'"
            );
        }
    }
}
