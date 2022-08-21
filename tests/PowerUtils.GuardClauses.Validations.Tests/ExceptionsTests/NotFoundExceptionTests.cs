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
    public class NotFoundExceptionTests
    {
        [Fact]
        public void NotFoundException_Constructor_WithoutParameters()
        {
            // Arrange && Act
            var act = new NotFoundException();


            // Assert
            act.Validate(HttpStatusCode.NotFound);
        }

        [Fact]
        public void NotFoundException_Constructor_WithMessage()
        {
            // Arrange
            var message = "Fake message";


            // Act
            var act = new NotFoundException(message);


            // Assert
            act.Validate(HttpStatusCode.NotFound, message);
        }

        [Fact]
        public void InvalidOperationException_Constructor_WithMessageAndInnerException()
        {
            // Arrange
            var message = "Fake message";
            var innerException = new InvalidOperationException();


            // Act
            var act = new NotFoundException(message, innerException);


            // Assert
            act.Validate<InvalidOperationException>(HttpStatusCode.NotFound, message);
        }

        [Fact]
        public void NotFoundException_SerializeDeserialize_Equivalent()
        {
            // Arrange
            var exception = new NotFoundException();


            // Act
            BaseValidationException act;
            using(var memoryStream = new MemoryStream())
            {
                var dataContractSerializer = new DataContractSerializer(typeof(NotFoundException));

                dataContractSerializer.WriteObject(memoryStream, exception);

                memoryStream.Seek(0, SeekOrigin.Begin);

                act = (NotFoundException)dataContractSerializer.ReadObject(memoryStream);
            }


            // Assert
            act.Should()
                .BeEquivalentTo(exception);

            act.Validate(HttpStatusCode.NotFound);
        }

        [Fact]
        public void NullInfo_GetObjectData_ArgumentNullException()
        {
            // Arrange
            var exception = new NotFoundException();


            // Act
            var act = Record.Exception(() => exception.GetObjectData(null, new StreamingContext()));


            // Assert
            act.Should()
                .BeOfType<ArgumentNullException>();
        }


        [Fact]
        public void ErrorCodeAndProperty_Constructor_WithPropertyAndMessage()
        {
            // Arrange
            var property = "FakeProp";
            var message = "FakeMessafe";


            // Act
            var act = new NotFoundException(property, message);


            // Assert
            act.Validate(HttpStatusCode.NotFound, property, ErrorCodes.NOT_FOUND, message);
        }

        [Fact]
        public void ErrorCodePropertyAndMessage_Constructor_WithErrorAndMessage()
        {
            // Arrange
            var property = "FakeProp";
            var errorCode = "FakeError";
            var message = "FakeMessafe";


            // Act
            var act = new NotFoundException(property, errorCode, message);


            // Assert
            act.Validate(HttpStatusCode.NotFound, property, errorCode, message);
        }


        [Fact]
        public void Property_Throw_WithError()
        {
            // Arrange
            var property = "FakeProp";


            // Act
            var act = Record.Exception(() => NotFoundException.Throw(property));


            // Assert
            act.Validate<NotFoundException>(HttpStatusCode.NotFound, property, ErrorCodes.NOT_FOUND, "The property 'FakeProp' contains the error 'NOT_FOUND");
        }


        [Fact]
        public void ErrorCodeAndProperty_Throw_WithErrorAndError()
        {
            // Arrange
            var property = "FakeProp";
            var errorCode = "FakeError";


            // Act
            var act = Record.Exception(() => NotFoundException.Throw(property, errorCode));


            // Assert
            act.Validate<NotFoundException>(HttpStatusCode.NotFound, property, errorCode, "The property 'FakeProp' contains the error 'FakeError");
        }
    }
}
