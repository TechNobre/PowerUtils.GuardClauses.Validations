using System.Net;
using PowerUtils.Validations;
using PowerUtils.Validations.Exceptions;
using PowerUtils.Validations.GuardClauses;

namespace PowerUtils.GuardClauses.Validations.Tests.GuardClausesTests;

[Trait("Type", "Guards")]
public class GuardValidationStringExtensionsTests
{
    [Fact]
    public void IfNull_Null_Exception()
    {
        // Arrange
        string client = null;


        // Act
        var act = Record.Exception(() => Guard.Validate.IfNull(client));


        // Assert
        act.Validate<PropertyException>(HttpStatusCode.BadRequest, nameof(client), ErrorCodes.REQUIRED);
    }

    [Fact]
    public void IfNull_Empty_Valid()
    {
        // Arrange
        var client = "";


        // Act
        var act = Record.Exception(() => Guard.Validate.IfNull(client));


        // Assert
        act.Should()
            .BeNull();
    }

    [Fact]
    public void IfNull_DirectValue_Exception()
    {
        // Act
        var act = Record.Exception(() => Guard.Validate.IfNull(null));


        // Assert
        act.Validate<PropertyException>(HttpStatusCode.BadRequest, "null", ErrorCodes.REQUIRED);
    }

    [Fact]
    public void IfNull_SetParameterName_Exception()
    {
        // Act
        var act = Record.Exception(() => Guard.Validate.IfNull(null, "Product"));


        // Assert
        act.Validate<PropertyException>(HttpStatusCode.BadRequest, "Product", ErrorCodes.REQUIRED);
    }




    [Fact]
    public void IfNullOrEmpty_Null_Exception()
    {
        // Arrange
        string client = null;


        // Act
        var act = Record.Exception(() => Guard.Validate.IfNullOrEmpty(client));


        // Assert
        act.Validate<PropertyException>(HttpStatusCode.BadRequest, nameof(client), ErrorCodes.REQUIRED);
    }

    [Fact]
    public void IfNullOrEmpty_Empty_Exception()
    {
        // Arrange
        var client = "";


        // Act
        var act = Record.Exception(() => Guard.Validate.IfNullOrEmpty(client));


        // Assert
        act.Validate<PropertyException>(HttpStatusCode.BadRequest, nameof(client), ErrorCodes.REQUIRED);
    }

    [Fact]
    public void IfNullOrEmpty_WithValue_Valid()
    {
        // Arrange
        var client = "fake";


        // Act
        var act = Record.Exception(() => Guard.Validate.IfNullOrEmpty(client));


        // Assert
        act.Should()
            .BeNull();
    }




    [Fact]
    public void IfNullOrWhiteSpace_Null_Exception()
    {
        // Arrange
        string client = null;


        // Act
        var act = Record.Exception(() => Guard.Validate.IfNullOrEmpty(client));


        // Assert
        act.Validate<PropertyException>(HttpStatusCode.BadRequest, nameof(client), ErrorCodes.REQUIRED);
    }

    [Fact]
    public void IfNullOrWhiteSpace_Empty_Exception()
    {
        // Arrange
        var client = "";


        // Act
        var act = Record.Exception(() => Guard.Validate.IfNullOrWhiteSpace(client));


        // Assert
        act.Validate<PropertyException>(HttpStatusCode.BadRequest, nameof(client), ErrorCodes.REQUIRED);
    }

    [Fact]
    public void IfNullOrWhiteSpace_WithSpace_Exception()
    {
        // Arrange
        var client = "      ";


        // Act
        var act = Record.Exception(() => Guard.Validate.IfNullOrWhiteSpace(client));


        // Assert
        act.Validate<PropertyException>(HttpStatusCode.BadRequest, nameof(client), ErrorCodes.REQUIRED);
    }

    [Fact]
    public void IfNullOrWhiteSpace_WithValue_Valid()
    {
        // Arrange
        var client = "fake";


        // Act
        var act = Record.Exception(() => Guard.Validate.IfNullOrWhiteSpace(client));


        // Assert
        act.Should()
            .BeNull();
    }



    [Fact]
    public void IfLengthGreaterThan_Null_Valid()
    {
        // Arrange
        string client = null;


        // Act
        var act = Record.Exception(() => Guard.Validate.IfLengthGreaterThan(client, 1));


        // Assert
        act.Should()
            .BeNull();
    }

    [Fact]
    public void IfLengthGreaterThan_BigText_Exception()
    {
        // Arrange
        var client = "Fake fake fake";


        // Act
        var act = Record.Exception(() => Guard.Validate.IfLengthGreaterThan(client, 5));


        // Assert
        act.Validate<PropertyException>(HttpStatusCode.BadRequest, nameof(client), "MAX:5");
    }

    [Fact]
    public void IfLengthGreaterThan_WithSpace_Valid()
    {
        // Arrange
        var client = "Fake";


        // Act
        var act = Record.Exception(() => Guard.Validate.IfLengthGreaterThan(client, 5));


        // Assert
        act.Should()
            .BeNull();
    }



    [Fact]
    public void IfLengthLessThan_Null_Valid()
    {
        // Arrange
        string client = null;


        // Act
        var act = Record.Exception(() => Guard.Validate.IfLengthLessThan(client, 1));


        // Assert
        act.Should()
            .BeNull();
    }

    [Fact]
    public void IfLengthLessThan_BigText_Exception()
    {
        // Arrange
        var client = "Fake";


        // Act
        var act = Record.Exception(() => Guard.Validate.IfLengthLessThan(client, 5));


        // Assert
        act.Validate<PropertyException>(HttpStatusCode.BadRequest, nameof(client), "MIN:5");
    }

    [Fact]
    public void IfLengthLessThan_WithSpace_Valid()
    {
        // Arrange
        var client = "Fake fake fake";


        // Act
        var act = Record.Exception(() => Guard.Validate.IfLengthLessThan(client, 5));


        // Assert
        act.Should()
            .BeNull();
    }



    [Fact]
    public void IfLengthZero_Null_Valid()
    {
        // Arrange
        string client = null;


        // Act
        var act = Record.Exception(() => Guard.Validate.IfLengthZero(client));


        // Assert
        act.Should()
            .BeNull();
    }

    [Fact]
    public void IfLengthZero_ZeroLength_Exception()
    {
        // Arrange
        var client = "";


        // Act
        var act = Record.Exception(() => Guard.Validate.IfLengthZero(client));


        // Assert
        act.Validate<PropertyException>(HttpStatusCode.BadRequest, nameof(client), "MIN:0");
    }

    [Fact]
    public void IfLengthZero_WithSpace_Valid()
    {
        // Arrange
        var client = "Fake";


        // Act
        var act = Record.Exception(() => Guard.Validate.IfLengthZero(client));


        // Assert
        act.Should()
            .BeNull();
    }
}
