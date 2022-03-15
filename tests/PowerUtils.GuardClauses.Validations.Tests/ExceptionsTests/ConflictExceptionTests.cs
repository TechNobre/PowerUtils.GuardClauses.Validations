using System;
using System.IO;
using System.Net;
using System.Runtime.Serialization;
using PowerUtils.Validations;
using PowerUtils.Validations.Exceptions;

namespace PowerUtils.GuardClauses.Validations.Tests.ExceptionsTests;

[Trait("Type", "Exceptions")]
public class ConflictExceptionTests
{
    [Fact(DisplayName = "Instance a ConflictException without parameters")]
    public void Constructor_WithoutParameters()
    {
        // Arrange && Act
        var act = new ConflictException();


        // Assert
        act.Validate(HttpStatusCode.Conflict);
    }

    [Fact(DisplayName = "Instance a ConflictException with message")]
    public void Constructor_WithMessage()
    {
        // Arrange
        var message = "Fake message";


        // Act
        var act = new ConflictException(message);


        // Assert
        act.Validate(HttpStatusCode.Conflict, message);
    }

    [Fact(DisplayName = "Instance a ConflictException with message and inner exception")]
    public void Constructor_WithMessageAndInnerException()
    {
        // Arrange
        var message = "Fake message";
        var innerException = new InvalidOperationException();


        // Act
        var act = new ConflictException(message, innerException);


        // Assert
        act.Validate<InvalidOperationException>(HttpStatusCode.Conflict, message);
    }

    [Fact(DisplayName = "Serialization and Deserialization MaxLatitudeException - Should be equivalent")]
    public void SerializeDeserialize_Equivalent()
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

    [Fact(DisplayName = "Try call GetObjectData with null info - Should return an 'ArgumentNullException'")]
    public void GetObjectData_NullInfo_ArgumentNullException()
    {
        // Arrange
        var exception = new ConflictException();


        // Act
        var act = Record.Exception(() => exception.GetObjectData(null, new StreamingContext()));


        // Assert
        act.Should()
            .BeOfType<ArgumentNullException>();
    }


    [Fact(DisplayName = "Instance a ConflictException with error and message")]
    public void Constructor_WithPropertyAndMessage()
    {
        // Arrange
        var property = "FakeProp";
        var message = "FakeMessafe";


        // Act
        var act = new ConflictException(property, message);


        // Assert
        act.Validate(HttpStatusCode.Conflict, property, ErrorCodes.DUPLICATED, message);
    }


    [Fact(DisplayName = "Throw a ConflictException with property")]
    public void Throw_WithError()
    {
        // Arrange
        var property = "FakeProp";


        // Act
        var act = Record.Exception(() => ConflictException.Throw(property));


        // Assert
        act.Validate<ConflictException>(HttpStatusCode.Conflict, property, ErrorCodes.DUPLICATED, "The property 'FakeProp' contains the error 'DUPLICATED");
    }
}
