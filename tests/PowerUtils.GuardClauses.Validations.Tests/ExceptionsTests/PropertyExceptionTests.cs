using System;
using System.IO;
using System.Net;
using System.Runtime.Serialization;
using PowerUtils.Validations;
using PowerUtils.Validations.Exceptions;

namespace PowerUtils.GuardClauses.Validations.Tests.ExceptionsTests;

[Trait("Type", "Exceptions")]
public class PropertyExceptionTests
{
    [Fact(DisplayName = "Instance a PropertyException without parameters")]
    public void Constructor_WithoutParameters()
    {
        // Arrange && Act
        var act = new PropertyException();


        // Assert
        act.Validate(HttpStatusCode.BadRequest);
    }

    [Fact(DisplayName = "Instance a PropertyException with message")]
    public void Constructor_WithMessage()
    {
        // Arrange
        var message = "Fake message";


        // Act
        var act = new PropertyException(message);


        // Assert
        act.Validate(HttpStatusCode.BadRequest, message);
    }

    [Fact(DisplayName = "Instance a PropertyException with message and inner exception")]
    public void Constructor_WithMessageAndInnerException()
    {
        // Arrange
        var message = "Fake message";
        var innerException = new InvalidOperationException();


        // Act
        var act = new PropertyException(message, innerException);


        // Assert
        act.Validate<InvalidOperationException>(HttpStatusCode.BadRequest, message);
    }

    [Fact(DisplayName = "Serialization and Deserialization MaxLatitudeException - Should be equivalent")]
    public void SerializeDeserialize_Equivalent()
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

    [Fact(DisplayName = "Try call GetObjectData with null info - Should return an 'ArgumentNullException'")]
    public void GetObjectData_NullInfo_ArgumentNullException()
    {
        // Arrange
        var exception = new PropertyException();


        // Act
        var act = Record.Exception(() => exception.GetObjectData(null, new StreamingContext()));


        // Assert
        act.Should()
            .BeOfType<ArgumentNullException>();
    }

    [Fact(DisplayName = "Instance a PropertyException with error")]
    public void Constructor_WithError()
    {
        // Arrange
        var property = "FakeProp";
        var errorCode = "FakeError";


        // Act
        var act = new PropertyException(property, errorCode);


        // Assert
        act.Validate(HttpStatusCode.BadRequest, property, errorCode);
    }


    [Fact(DisplayName = "Instance a PropertyException with error and message")]
    public void Constructor_WithErrorAndMessage()
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


    [Fact(DisplayName = "Throw a PropertyException with error")]
    public void Throw_WithError()
    {
        // Arrange
        var property = "FakeProp";
        var errorCode = "FakeError2";


        // Act
        var act = Record.Exception(() => PropertyException.Throw(property, errorCode));


        // Assert
        act.Validate<PropertyException>(HttpStatusCode.BadRequest, property, errorCode, "The property 'FakeProp' contains the error 'FakeError2");
    }


    [Fact(DisplayName = "Throw a PropertyException with invalid error")]
    public void Throw_InvalidError()
    {
        // Arrange
        var property = "FakeProp2";


        // Act
        var act = Record.Exception(() => PropertyException.ThrowInvalid(property));


        // Assert
        act.Validate<PropertyException>(HttpStatusCode.BadRequest, property, ErrorCodes.INVALID, "The property 'FakeProp2' contains the error 'INVALID");
    }


    [Fact(DisplayName = "Throw Required a PropertyException with invalid error")]
    public void ThrowRequired_RequiredError()
    {
        // Arrange
        var property = "FakeProp";


        // Act
        var act = Record.Exception(() => PropertyException.ThrowRequired(property));


        // Assert
        act.Validate<PropertyException>(HttpStatusCode.BadRequest, property, ErrorCodes.REQUIRED, "The property 'FakeProp' contains the error 'REQUIRED");
    }
}
