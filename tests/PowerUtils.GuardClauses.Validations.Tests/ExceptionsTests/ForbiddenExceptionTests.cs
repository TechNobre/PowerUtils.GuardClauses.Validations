using System;
using System.IO;
using System.Net;
using System.Runtime.Serialization;
using PowerUtils.Validations;
using PowerUtils.Validations.Exceptions;

namespace PowerUtils.GuardClauses.Validations.Tests.ExceptionsTests;

[Trait("Type", "Exceptions")]
public class ForbiddenExceptionTests
{
    [Fact(DisplayName = "Instance a ForbiddenException without parameters")]
    public void Constructor_WithoutParameters()
    {
        // Arrange && Act
        var act = new ForbiddenException();


        // Assert
        act.Validate(HttpStatusCode.Forbidden);
    }

    [Fact(DisplayName = "Instance a ForbiddenException with message")]
    public void Constructor_WithMessage()
    {
        // Arrange
        var message = "Fake message";


        // Act
        var act = new ForbiddenException(message);


        // Assert
        act.Validate(HttpStatusCode.Forbidden, message);
    }

    [Fact(DisplayName = "Instance a ForbiddenException with message and inner exception")]
    public void Constructor_WithMessageAndInnerException()
    {
        // Arrange
        var message = "Fake message";
        var innerException = new InvalidOperationException();


        // Act
        var act = new ForbiddenException(message, innerException);


        // Assert
        act.Validate<InvalidOperationException>(HttpStatusCode.Forbidden, message);
    }

    [Fact(DisplayName = "Serialization and Deserialization MaxLatitudeException - Should be equivalent")]
    public void SerializeDeserialize_Equivalent()
    {
        // Arrange
        var exception = new ForbiddenException();


        // Act
        BaseValidationException act;
        using(var memoryStream = new MemoryStream())
        {
            var dataContractSerializer = new DataContractSerializer(typeof(ForbiddenException));

            dataContractSerializer.WriteObject(memoryStream, exception);

            memoryStream.Seek(0, SeekOrigin.Begin);

            act = (ForbiddenException)dataContractSerializer.ReadObject(memoryStream);
        }


        // Assert
        act.Should()
            .BeEquivalentTo(exception);

        act.Validate(HttpStatusCode.Forbidden);
    }

    [Fact(DisplayName = "Try call GetObjectData with null info - Should return an 'ArgumentNullException'")]
    public void GetObjectData_NullInfo_ArgumentNullException()
    {
        // Arrange
        var exception = new ForbiddenException();


        // Act
        var act = Record.Exception(() => exception.GetObjectData(null, new StreamingContext()));


        // Assert
        act.Should()
            .BeOfType<ArgumentNullException>();
    }


    [Fact(DisplayName = "Instance a ForbiddenException with error and message")]
    public void Constructor_WithPropertyAndMessage()
    {
        // Arrange
        var property = "FakeProp";
        var message = "FakeMessafe";


        // Act
        var act = new ForbiddenException(property, message);


        // Assert
        act.Validate(HttpStatusCode.Forbidden, property, ErrorCodes.FORBIDDEN, message);
    }

    [Fact(DisplayName = "Instance a ForbiddenException with error and message")]
    public void Constructor_WithErrorAndMessage()
    {
        // Arrange
        var property = "FakeProp";
        var errorCode = "FakeError";
        var message = "FakeMessafe";


        // Act
        var act = new ForbiddenException(property, errorCode, message);


        // Assert
        act.Validate(HttpStatusCode.Forbidden, property, errorCode, message);
    }


    [Fact(DisplayName = "Throw a ForbiddenException with property")]
    public void Throw_WithError()
    {
        // Arrange
        var property = "FakeProp";


        // Act
        var act = Record.Exception(() => ForbiddenException.Throw(property));


        // Assert
        act.Validate<ForbiddenException>(HttpStatusCode.Forbidden, property, ErrorCodes.FORBIDDEN, "The property 'FakeProp' contains the error 'FORBIDDEN");
    }


    [Fact(DisplayName = "Throw a ForbiddenException with error")]
    public void Throw_WithErrorAndError()
    {
        // Arrange
        var property = "FakeProp";
        var errorCode = "FakeError";


        // Act
        var act = Record.Exception(() => ForbiddenException.Throw(property, errorCode));


        // Assert
        act.Validate<ForbiddenException>(HttpStatusCode.Forbidden, property, errorCode, "The property 'FakeProp' contains the error 'FakeError");
    }
}
