using System;
using System.IO;
using System.Net;
using System.Runtime.Serialization;
using PowerUtils.Validations;
using PowerUtils.Validations.Exceptions;

namespace PowerUtils.GuardClauses.Validations.Tests.ExceptionsTests;

[Trait("Type", "Exceptions")]
public class UnauthorizedExceptionTests
{
    [Fact(DisplayName = "Instance a UnauthorizedException without parameters")]
    public void Constructor_WithoutParameters()
    {
        // Arrange && Act
        var act = new UnauthorizedException();


        // Assert
        act.Validate(HttpStatusCode.Unauthorized);
    }

    [Fact(DisplayName = "Instance a UnauthorizedException with message")]
    public void Constructor_WithMessage()
    {
        // Arrange
        var message = "Fake message";


        // Act
        var act = new UnauthorizedException(message);


        // Assert
        act.Validate(HttpStatusCode.Unauthorized, message);
    }

    [Fact(DisplayName = "Instance a UnauthorizedException with message and inner exception")]
    public void Constructor_WithMessageAndInnerException()
    {
        // Arrange
        var message = "Fake message";
        var innerException = new InvalidOperationException();


        // Act
        var act = new UnauthorizedException(message, innerException);


        // Assert
        act.Validate<InvalidOperationException>(HttpStatusCode.Unauthorized, message);
    }

    [Fact(DisplayName = "Serialization and Deserialization MaxLatitudeException - Should be equivalent")]
    public void SerializeDeserialize_Equivalent()
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

    [Fact(DisplayName = "Try call GetObjectData with null info - Should return an 'ArgumentNullException'")]
    public void GetObjectData_NullInfo_ArgumentNullException()
    {
        // Arrange
        var exception = new UnauthorizedException();


        // Act
        var act = Record.Exception(() => exception.GetObjectData(null, new StreamingContext()));


        // Assert
        act.Should()
            .BeOfType<ArgumentNullException>();
    }


    [Fact(DisplayName = "Instance a UnauthorizedException with error and message")]
    public void Constructor_WithPropertyAndMessage()
    {
        // Arrange
        var property = "FakeProp";
        var message = "FakeMessafe";


        // Act
        var act = new UnauthorizedException(property, message);


        // Assert
        act.Validate(HttpStatusCode.Unauthorized, property, ErrorCodes.UNAUTHORIZED, message);
    }


    [Fact(DisplayName = "Throw a UnauthorizedException with error")]
    public void Throw_WithError()
    {
        // Arrange
        var property = "FakeProp";


        // Act
        var act = Record.Exception(() => UnauthorizedException.Throw(property));


        // Assert
        act.Validate<UnauthorizedException>(HttpStatusCode.Unauthorized, property, ErrorCodes.UNAUTHORIZED, "The property 'FakeProp' contains the error 'UNAUTHORIZED");
    }
}
