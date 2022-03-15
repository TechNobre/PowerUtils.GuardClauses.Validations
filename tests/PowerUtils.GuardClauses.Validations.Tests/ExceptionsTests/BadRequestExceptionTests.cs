using System;
using System.IO;
using System.Net;
using System.Runtime.Serialization;
using PowerUtils.Validations;
using PowerUtils.Validations.Exceptions;

namespace PowerUtils.GuardClauses.Validations.Tests.ExceptionsTests;

[Trait("Type", "Exceptions")]
public class BadRequestExceptionTests
{
    [Fact(DisplayName = "Instance a BadRequestException without parameters")]
    public void Constructor_WithoutParameters()
    {
        // Arrange && Act
        var act = new BadRequestException();


        // Assert
        act.Validate(HttpStatusCode.BadRequest);
    }

    [Fact(DisplayName = "Instance a BadRequestException with message")]
    public void Constructor_WithMessage()
    {
        // Arrange
        var message = "Fake message";


        // Act
        var act = new BadRequestException(message);


        // Assert
        act.Validate(HttpStatusCode.BadRequest, message);
    }

    [Fact(DisplayName = "Instance a BadRequestException with message and inner exception")]
    public void Constructor_WithMessageAndInnerException()
    {
        // Arrange
        var message = "Fake message";
        var innerException = new InvalidOperationException();


        // Act
        var act = new BadRequestException(message, innerException);


        // Assert
        act.Validate<InvalidOperationException>(HttpStatusCode.BadRequest, message);
    }

    [Fact(DisplayName = "Serialization and Deserialization MaxLatitudeException - Should be equivalent")]
    public void SerializeDeserialize_Equivalent()
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

    [Fact(DisplayName = "Try call GetObjectData with null info - Should return an 'ArgumentNullException'")]
    public void GetObjectData_NullInfo_ArgumentNullException()
    {
        // Arrange
        var exception = new BadRequestException();


        // Act
        var act = Record.Exception(() => exception.GetObjectData(null, new StreamingContext()));


        // Assert
        act.Should()
            .BeOfType<ArgumentNullException>();
    }

    [Fact(DisplayName = "Instance a BadRequestException with error")]
    public void Constructor_WithError()
    {
        // Arrange
        var property = "FakeProp";
        var errorCode = "FakeError";


        // Act
        var act = new BadRequestException(property, errorCode);


        // Assert
        act.Validate(HttpStatusCode.BadRequest, property, errorCode);
    }


    [Fact(DisplayName = "Instance a BadRequestException with error and message")]
    public void Constructor_WithErrorAndMessage()
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


    [Fact(DisplayName = "Throw a BadRequestException with error")]
    public void Throw_WithError()
    {
        // Arrange
        var property = "FakeProp";
        var errorCode = "FakeError";


        // Act
        var act = Record.Exception(() => BadRequestException.Throw(property, errorCode));


        // Assert
        act.Validate<BadRequestException>(HttpStatusCode.BadRequest, property, errorCode, "The property 'FakeProp' contains the error 'FakeError");
    }


    [Fact(DisplayName = "Throw a BadRequestException with invalid error")]
    public void Throw_InvalidError()
    {
        // Arrange
        var property = "FakeProp";


        // Act
        var act = Record.Exception(() => BadRequestException.ThrowInvalid(property));


        // Assert
        act.Validate<BadRequestException>(HttpStatusCode.BadRequest, property, ErrorCodes.INVALID, "The property 'FakeProp' contains the error 'INVALID");
    }
}
