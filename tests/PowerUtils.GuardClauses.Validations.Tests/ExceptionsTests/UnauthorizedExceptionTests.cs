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
    public class UnauthorizedExceptionTests
    {
        [Fact]
        public void UnauthorizedException_Constructor_WithoutParameters()
        {
            // Arrange && Act
            var act = new UnauthorizedException();


            // Assert
            act.Validate(HttpStatusCode.Unauthorized);
        }

        [Fact]
        public void UnauthorizedException_Constructor_WithMessage()
        {
            // Arrange
            var message = "Fake message";


            // Act
            var act = new UnauthorizedException(message);


            // Assert
            act.Validate(HttpStatusCode.Unauthorized, message);
        }

        [Fact]
        public void InvalidOperationException_Constructor_WithMessageAndInnerException()
        {
            // Arrange
            var message = "Fake message";
            var innerException = new InvalidOperationException();


            // Act
            var act = new UnauthorizedException(message, innerException);


            // Assert
            act.Validate<InvalidOperationException>(HttpStatusCode.Unauthorized, message);
        }

        [Fact]
        public void UnauthorizedException_SerializeDeserialize_Equivalent()
        {
            // Arrange
            var exception = new UnauthorizedException();


            // Act
            BaseValidationException act;
            using(var memoryStream = new MemoryStream())
            {
                var dataContractSerializer = new DataContractSerializer(typeof(UnauthorizedException));

                dataContractSerializer.WriteObject(memoryStream, exception);

                memoryStream.Seek(0, SeekOrigin.Begin);

                act = (UnauthorizedException)dataContractSerializer.ReadObject(memoryStream);
            }


            // Assert
            act.Should()
                .BeEquivalentTo(exception);

            act.Validate(HttpStatusCode.Unauthorized);
        }

        [Fact]
        public void NullInfo_GetObjectData_ArgumentNullException()
        {
            // Arrange
            var exception = new UnauthorizedException();


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
            var act = new UnauthorizedException(property, message);


            // Assert
            act.Validate(HttpStatusCode.Unauthorized, property, ErrorCodes.UNAUTHORIZED, message);
        }

        [Fact]
        public void ErrorCodePropertyAndMessage_Constructor_WithErrorAndMessage()
        {
            // Arrange
            var property = "FakeProp";
            var errorCode = "FakeError";
            var message = "FakeMessafe";


            // Act
            var act = new UnauthorizedException(property, errorCode, message);


            // Assert
            act.Validate(HttpStatusCode.Unauthorized, property, errorCode, message);
        }


        [Fact]
        public void Property_Throw_WithError()
        {
            // Arrange
            var property = "FakeProp";


            // Act
            var act = Record.Exception(() => UnauthorizedException.Throw(property));


            // Assert
            act.Validate<UnauthorizedException>(HttpStatusCode.Unauthorized, property, ErrorCodes.UNAUTHORIZED, "The property 'FakeProp' contains the error 'UNAUTHORIZED");
        }


        [Fact]
        public void ErrorCodeAndProperty_Throw_WithErrorAndError()
        {
            // Arrange
            var property = "FakeProp";
            var errorCode = "FakeError";


            // Act
            var act = Record.Exception(() => UnauthorizedException.Throw(property, errorCode));


            // Assert
            act.Validate<UnauthorizedException>(HttpStatusCode.Unauthorized, property, errorCode, "The property 'FakeProp' contains the error 'FakeError");
        }
    }
}
