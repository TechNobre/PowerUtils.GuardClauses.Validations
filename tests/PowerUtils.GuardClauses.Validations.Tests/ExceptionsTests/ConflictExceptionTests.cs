using System;
using System.IO;
using System.Net;
using System.Runtime.Serialization;
using PowerUtils.Validations;
using PowerUtils.Validations.Exceptions;

namespace PowerUtils.GuardClauses.Validations.Tests.ExceptionsTests;

public class ConflictExceptionTests
{
    [Fact]
    public void ConflictException_Constructor_StatusConflict()
    {
        // Arrange && Act
        var act = new ConflictException();


        // Assert
        act.Validate(HttpStatusCode.Conflict);
    }

    [Fact]
    public void ConflictException_Constructor_WithMessage()
    {
        // Arrange
        var message = "Fake message";


        // Act
        var act = new ConflictException(message);


        // Assert
        act.Validate(HttpStatusCode.Conflict, message);
    }

    [Fact]
    public void InvalidOperationException_Constructor_WithMessageAndInnerException()
    {
        // Arrange
        var message = "Fake message";
        var innerException = new InvalidOperationException();


        // Act
        var act = new ConflictException(message, innerException);


        // Assert
        act.Validate<InvalidOperationException>(HttpStatusCode.Conflict, message);
    }

    [Fact]
    public void ConflictException_SerializeDeserialize_Equivalent()
    {
        // Arrange
        var exception = new ConflictException();


        // Act
        BaseValidationException act;
        using(var memoryStream = new MemoryStream())
        {
            var dataContractSerializer = new DataContractSerializer(typeof(ConflictException));

            dataContractSerializer.WriteObject(memoryStream, exception);

            memoryStream.Seek(0, SeekOrigin.Begin);

            act = (ConflictException)dataContractSerializer.ReadObject(memoryStream);
        }


        // Assert
        act.Should()
            .BeEquivalentTo(exception);

        act.Validate(HttpStatusCode.Conflict);
    }

    [Fact]
    public void NullInfo_GetObjectData_ArgumentNullException()
    {
        // Arrange
        var exception = new ConflictException();


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
        var message = "FakeMessafe";


        // Act
        var act = new ConflictException(property, message);


        // Assert
        act.Validate(HttpStatusCode.Conflict, property, ErrorCodes.DUPLICATED, message);
    }

    [Fact]
    public void ErrorCodePropertyAndMessage_Constructor_WithErrorAndMessage()
    {
        // Arrange
        var property = "FakeProp";
        var errorCode = "FakeError";
        var message = "FakeMessafe";


        // Act
        var act = new ConflictException(property, errorCode, message);


        // Assert
        act.Validate(HttpStatusCode.Conflict, property, errorCode, message);
    }


    [Fact]
    public void Property_Throw_WithError()
    {
        // Arrange
        var property = "FakeProp";


        // Act
        var act = Record.Exception(() => ConflictException.Throw(property));


        // Assert
        act.Validate<ConflictException>(HttpStatusCode.Conflict, property, ErrorCodes.DUPLICATED, "The property 'FakeProp' contains the error 'DUPLICATED");
    }


    [Fact]
    public void ErrorCodeAndProperty_Throw_WithErrorAndError()
    {
        // Arrange
        var property = "FakeProp";
        var errorCode = "FakeError";


        // Act
        var act = Record.Exception(() => ConflictException.Throw(property, errorCode));


        // Assert
        act.Validate<ConflictException>(HttpStatusCode.Conflict, property, errorCode, "The property 'FakeProp' contains the error 'FakeError");
    }
}
