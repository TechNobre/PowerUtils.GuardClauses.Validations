using System;
using System.IO;
using System.Net;
using System.Runtime.Serialization;
using PowerUtils.Validations;
using PowerUtils.Validations.Exceptions;

namespace PowerUtils.GuardClauses.Validations.Tests.ExceptionsTests;

[Trait("Type", "Exceptions")]
public class NotFoundExceptionTests
{
    [Fact(DisplayName = "Instance a NotFoundException without parameters")]
    public void Constructor_WithoutParameters()
    {
        // Arrange && Act
        var act = new NotFoundException();


        // Assert
        act.Validate(HttpStatusCode.NotFound);
    }

    [Fact(DisplayName = "Instance a NotFoundException with message")]
    public void Constructor_WithMessage()
    {
        // Arrange
        var message = "Fake message";


        // Act
        var act = new NotFoundException(message);


        // Assert
        act.Validate(HttpStatusCode.NotFound, message);
    }

    [Fact(DisplayName = "Instance a NotFoundException with message and inner exception")]
    public void Constructor_WithMessageAndInnerException()
    {
        // Arrange
        var message = "Fake message";
        var innerException = new InvalidOperationException();


        // Act
        var act = new NotFoundException(message, innerException);


        // Assert
        act.Validate<InvalidOperationException>(HttpStatusCode.NotFound, message);
    }

    [Fact(DisplayName = "Serialization and Deserialization MaxLatitudeException - Should be equivalent")]
    public void SerializeDeserialize_Equivalent()
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

    [Fact(DisplayName = "Try call GetObjectData with null info - Should return an 'ArgumentNullException'")]
    public void GetObjectData_NullInfo_ArgumentNullException()
    {
        // Arrange
        var exception = new NotFoundException();


        // Act
        var act = Record.Exception(() => exception.GetObjectData(null, new StreamingContext()));


        // Assert
        act.Should()
            .BeOfType<ArgumentNullException>();
    }


    [Fact(DisplayName = "Instance a NotFoundException with error and message")]
    public void Constructor_WithPropertyAndMessage()
    {
        // Arrange
        var property = "FakeProp";
        var message = "FakeMessafe";


        // Act
        var act = new NotFoundException(property, message);


        // Assert
        act.Validate(HttpStatusCode.NotFound, property, ErrorCodes.NOT_FOUND, message);
    }


    [Fact(DisplayName = "Throw a NotFoundException with property")]
    public void Throw_WithError()
    {
        // Arrange
        var property = "FakeProp";


        // Act
        var act = Record.Exception(() => NotFoundException.Throw(property));


        // Assert
        act.Validate<NotFoundException>(HttpStatusCode.NotFound, property, ErrorCodes.NOT_FOUND, "The property 'FakeProp' contains the error 'NOT_FOUND");
    }
}
