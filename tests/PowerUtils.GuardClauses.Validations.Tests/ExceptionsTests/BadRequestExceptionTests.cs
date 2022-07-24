using System;
using System.IO;
using System.Net;
using System.Runtime.Serialization;
using PowerUtils.Validations;
using PowerUtils.Validations.Exceptions;

namespace PowerUtils.GuardClauses.Validations.Tests.ExceptionsTests;

public class BadRequestExceptionTests
{
    [Fact]
    public void BadRequestException_Constructor_StatusBadRequest()
    {
        // Arrange && Act
        var act = new BadRequestException();


        // Assert
        act.Validate(HttpStatusCode.BadRequest);
    }

    [Fact]
    public void BadRequestException_Constructor_WithMessage()
    {
        // Arrange
        var message = "Fake message";


        // Act
        var act = new BadRequestException(message);


        // Assert
        act.Validate(HttpStatusCode.BadRequest, message);
    }

    [Fact]
    public void InvalidOperationException_Constructor_WithMessageAndInnerException()
    {
        // Arrange
        var message = "Fake message";
        var innerException = new InvalidOperationException();


        // Act
        var act = new BadRequestException(message, innerException);


        // Assert
        act.Validate<InvalidOperationException>(HttpStatusCode.BadRequest, message);
    }

    [Fact]
    public void BadRequestException_SerializeDeserialize_Equivalent()
    {
        // Arrange
        var exception = new BadRequestException();


        // Act
        BaseValidationException act;
        using(var memoryStream = new MemoryStream())
        {
            var dataContractSerializer = new DataContractSerializer(typeof(BadRequestException));

            dataContractSerializer.WriteObject(memoryStream, exception);

            memoryStream.Seek(0, SeekOrigin.Begin);

            act = (BadRequestException)dataContractSerializer.ReadObject(memoryStream);
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
        var exception = new BadRequestException();


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
        var act = new BadRequestException(property, errorCode);


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
        var act = new BadRequestException(property, errorCode, message);


        // Assert
        act.Validate(HttpStatusCode.BadRequest, property, errorCode, message);
    }


    [Fact]
    public void ErrorCodeAndProperty_Throw_WithError()
    {
        // Arrange
        var property = "FakeProp";
        var errorCode = "FakeError";


        // Act
        var act = Record.Exception(() => BadRequestException.Throw(property, errorCode));


        // Assert
        act.Validate<BadRequestException>(HttpStatusCode.BadRequest, property, errorCode, "The property 'FakeProp' contains the error 'FakeError");
    }


    [Fact]
    public void Property_ThrowInvalid_InvalidError()
    {
        // Arrange
        var property = "FakeProp";


        // Act
        var act = Record.Exception(() => BadRequestException.ThrowInvalid(property));


        // Assert
        act.Validate<BadRequestException>(
            HttpStatusCode.BadRequest,
            property,
            ErrorCodes.INVALID,
            "The property 'FakeProp' contains the error 'INVALID"
        );
    }


    [Fact]
    public void Property_ThrowRequired_RequiredError()
    {
        // Arrange
        var property = "FakeProp";


        // Act
        var act = Record.Exception(() => BadRequestException.ThrowRequired(property));


        // Assert
        act.Validate<BadRequestException>(
            HttpStatusCode.BadRequest,
            property,
            ErrorCodes.REQUIRED,
            "The property 'FakeProp' contains the error 'REQUIRED"
        );
    }
}
