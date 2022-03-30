using System.Net;
using PowerUtils.Validations;
using PowerUtils.Validations.Exceptions;
using PowerUtils.Validations.GuardClauses;

namespace PowerUtils.GuardClauses.Validations.Tests.GuardClausesTests;

[Trait("Type", "Guards")]
public class GuardValidationGeolocationExtensionsTests
{
    [Fact]
    public void FloatLatitude_Small_Exception()
    {
        // Arrange
        var degree = -90.1f;


        // Act
        var act = Record.Exception(() => Guard.Validate.IfLatitudeOutOfRange(degree));


        // Assert
        act.Validate<PropertyException>(HttpStatusCode.BadRequest, nameof(degree), ErrorCodes.MIN_LATITUDE);
    }

    [Fact]
    public void FloatLatitude_Large_Exception()
    {
        // Arrange
        var degree = 90.1f;


        // Act
        var act = Record.Exception(() => Guard.Validate.IfLatitudeOutOfRange(degree));


        // Assert
        act.Validate<PropertyException>(HttpStatusCode.BadRequest, nameof(degree), ErrorCodes.MAX_LATITUDE);
    }

    [Fact]
    public void FloatLatitude_Valid_NotException()
    {
        // Arrange
        var degree = 18.1f;


        // Act
        var act = Record.Exception(() => Guard.Validate.IfLatitudeOutOfRange(degree));


        // Assert
        act.Should()
            .BeNull();
    }


    [Fact]
    public void FloatLongitude_Small_Exception()
    {
        // Arrange
        var degree = -180.1f;


        // Act
        var act = Record.Exception(() => Guard.Validate.IfLongitudeOutOfRange(degree));


        // Assert
        act.Validate<PropertyException>(HttpStatusCode.BadRequest, nameof(degree), ErrorCodes.MIN_LONGITUDE);
    }

    [Fact]
    public void FloatLongitude_Large_Exception()
    {
        // Arrange
        var degree = 180.1f;


        // Act
        var act = Record.Exception(() => Guard.Validate.IfLongitudeOutOfRange(degree));


        // Assert
        act.Validate<PropertyException>(HttpStatusCode.BadRequest, nameof(degree), ErrorCodes.MAX_LONGITUDE);
    }

    [Fact]
    public void FloatLongitude_Valid_NotException()
    {
        // Arrange
        var degree = 18.1f;


        // Act
        var act = Record.Exception(() => Guard.Validate.IfLongitudeOutOfRange(degree));


        // Assert
        act.Should()
            .BeNull();
    }

    [Fact]
    public void FloatLatitudeNullable_Null_NotException()
    {
        // Arrange
        float? degree = null;


        // Act
        var act = Record.Exception(() => Guard.Validate.IfLatitudeOutOfRange(degree));


        // Assert
        act.Should()
            .BeNull();
    }

    [Fact]
    public void FloatLatitudeNullable_Small_Exception()
    {
        // Arrange
        float? degree = -90.1f;


        // Act
        var act = Record.Exception(() => Guard.Validate.IfLatitudeOutOfRange(degree));


        // Assert
        act.Validate<PropertyException>(HttpStatusCode.BadRequest, nameof(degree), ErrorCodes.MIN_LATITUDE);
    }

    [Fact]
    public void FloatLatitudeNullable_Large_Exception()
    {
        // Arrange
        float? degree = 90.1f;


        // Act
        var act = Record.Exception(() => Guard.Validate.IfLatitudeOutOfRange(degree));


        // Assert
        act.Validate<PropertyException>(HttpStatusCode.BadRequest, nameof(degree), ErrorCodes.MAX_LATITUDE);
    }

    [Fact]
    public void FloatLatitudeNullable_Valid_NotException()
    {
        // Arrange
        float? degree = 18.1f;


        // Act
        var act = Record.Exception(() => Guard.Validate.IfLatitudeOutOfRange(degree));


        // Assert
        act.Should()
            .BeNull();
    }

    [Fact]
    public void FloatLongitudeNullable_Null_NotException()
    {
        // Arrange
        float? degree = null;


        // Act
        var act = Record.Exception(() => Guard.Validate.IfLongitudeOutOfRange(degree));


        // Assert
        act.Should()
            .BeNull();
    }

    [Fact]
    public void FloatLongitudeNullable_Small_Exception()
    {
        // Arrange
        float? degree = -180.1f;


        // Act
        var act = Record.Exception(() => Guard.Validate.IfLongitudeOutOfRange(degree));


        // Assert
        act.Validate<PropertyException>(HttpStatusCode.BadRequest, nameof(degree), ErrorCodes.MIN_LONGITUDE);
    }

    [Fact]
    public void FloatLongitudeNullable_Large_Exception()
    {
        // Arrange
        float? degree = 180.1f;


        // Act
        var act = Record.Exception(() => Guard.Validate.IfLongitudeOutOfRange(degree));


        // Assert
        act.Validate<PropertyException>(HttpStatusCode.BadRequest, nameof(degree), ErrorCodes.MAX_LONGITUDE);
    }

    [Fact]
    public void FloatLongitudeNullable_Valid_NotException()
    {
        // Arrange
        float? degree = 18.1f;


        // Act
        var act = Record.Exception(() => Guard.Validate.IfLongitudeOutOfRange(degree));


        // Assert
        act.Should()
            .BeNull();
    }


    [Fact]
    public void DoubleLatitude_Small_Exception()
    {
        // Arrange
        var degree = -90.1;


        // Act
        var act = Record.Exception(() => Guard.Validate.IfLatitudeOutOfRange(degree));


        // Assert
        act.Validate<PropertyException>(HttpStatusCode.BadRequest, nameof(degree), ErrorCodes.MIN_LATITUDE);
    }

    [Fact]
    public void DoubleLatitude_Large_Exception()
    {
        // Arrange
        var degree = 90.1;


        // Act
        var act = Record.Exception(() => Guard.Validate.IfLatitudeOutOfRange(degree));


        // Assert
        act.Validate<PropertyException>(HttpStatusCode.BadRequest, nameof(degree), ErrorCodes.MAX_LATITUDE);
    }

    [Fact]
    public void DoubleLatitude_Valid_NotException()
    {
        // Arrange
        var degree = 18.1;


        // Act
        var act = Record.Exception(() => Guard.Validate.IfLatitudeOutOfRange(degree));


        // Assert
        act.Should()
            .BeNull();
    }


    [Fact]
    public void DoubleLongitude_Small_Exception()
    {
        // Arrange
        var degree = -180.1;


        // Act
        var act = Record.Exception(() => Guard.Validate.IfLongitudeOutOfRange(degree));


        // Assert
        act.Validate<PropertyException>(HttpStatusCode.BadRequest, nameof(degree), ErrorCodes.MIN_LONGITUDE);
    }

    [Fact]
    public void DoubleLongitude_Large_Exception()
    {
        // Arrange
        var degree = 180.1;


        // Act
        var act = Record.Exception(() => Guard.Validate.IfLongitudeOutOfRange(degree));


        // Assert
        act.Validate<PropertyException>(HttpStatusCode.BadRequest, nameof(degree), ErrorCodes.MAX_LONGITUDE);
    }

    [Fact]
    public void DoubleLongitude_Valid_NotException()
    {
        // Arrange
        var degree = 18.1;


        // Act
        var act = Record.Exception(() => Guard.Validate.IfLongitudeOutOfRange(degree));


        // Assert
        act.Should()
            .BeNull();
    }

    [Fact]
    public void DoubleLatitudeNullable_Null_NotException()
    {
        // Arrange
        double? degree = null;


        // Act
        var act = Record.Exception(() => Guard.Validate.IfLatitudeOutOfRange(degree));


        // Assert
        act.Should()
            .BeNull();
    }

    [Fact]
    public void DoubleLatitudeNullable_Small_Exception()
    {
        // Arrange
        double? degree = -90.1;


        // Act
        var act = Record.Exception(() => Guard.Validate.IfLatitudeOutOfRange(degree));


        // Assert
        act.Validate<PropertyException>(HttpStatusCode.BadRequest, nameof(degree), ErrorCodes.MIN_LATITUDE);
    }

    [Fact]
    public void DoubleLatitudeNullable_Large_Exception()
    {
        // Arrange
        double? degree = 90.1;


        // Act
        var act = Record.Exception(() => Guard.Validate.IfLatitudeOutOfRange(degree));


        // Assert
        act.Validate<PropertyException>(HttpStatusCode.BadRequest, nameof(degree), ErrorCodes.MAX_LATITUDE);
    }

    [Fact]
    public void DoubleLatitudeNullable_Valid_NotException()
    {
        // Arrange
        double? degree = 18.1;


        // Act
        var act = Record.Exception(() => Guard.Validate.IfLatitudeOutOfRange(degree));


        // Assert
        act.Should()
            .BeNull();
    }

    [Fact]
    public void DoubleLongitudeNullable_Null_NotException()
    {
        // Arrange
        double? degree = null;


        // Act
        var act = Record.Exception(() => Guard.Validate.IfLongitudeOutOfRange(degree));


        // Assert
        act.Should()
            .BeNull();
    }

    [Fact]
    public void DoubleLongitudeNullable_Small_Exception()
    {
        // Arrange
        double? degree = -180.1;


        // Act
        var act = Record.Exception(() => Guard.Validate.IfLongitudeOutOfRange(degree));


        // Assert
        act.Validate<PropertyException>(HttpStatusCode.BadRequest, nameof(degree), ErrorCodes.MIN_LONGITUDE);
    }

    [Fact]
    public void DoubleLongitudeNullable_Large_Exception()
    {
        // Arrange
        double? degree = 180.1;


        // Act
        var act = Record.Exception(() => Guard.Validate.IfLongitudeOutOfRange(degree));


        // Assert
        act.Validate<PropertyException>(HttpStatusCode.BadRequest, nameof(degree), ErrorCodes.MAX_LONGITUDE);
    }

    [Fact]
    public void DoubleLongitudeNullable_Valid_NotException()
    {
        // Arrange
        double? degree = 18.1;


        // Act
        var act = Record.Exception(() => Guard.Validate.IfLongitudeOutOfRange(degree));


        // Assert
        act.Should()
            .BeNull();
    }


    [Fact]
    public void DecimalLatitude_Small_Exception()
    {
        // Arrange
        var degree = -90.1m;


        // Act
        var act = Record.Exception(() => Guard.Validate.IfLatitudeOutOfRange(degree));


        // Assert
        act.Validate<PropertyException>(HttpStatusCode.BadRequest, nameof(degree), ErrorCodes.MIN_LATITUDE);
    }

    [Fact]
    public void DecimalLatitude_Large_Exception()
    {
        // Arrange
        var degree = 90.1m;


        // Act
        var act = Record.Exception(() => Guard.Validate.IfLatitudeOutOfRange(degree));


        // Assert
        act.Validate<PropertyException>(HttpStatusCode.BadRequest, nameof(degree), ErrorCodes.MAX_LATITUDE);
    }

    [Fact]
    public void DecimalLatitude_Valid_NotException()
    {
        // Arrange
        var degree = 18.1m;


        // Act
        var act = Record.Exception(() => Guard.Validate.IfLatitudeOutOfRange(degree));


        // Assert
        act.Should()
            .BeNull();
    }


    [Fact]
    public void DecimalLongitude_Small_Exception()
    {
        // Arrange
        var degree = -180.1m;


        // Act
        var act = Record.Exception(() => Guard.Validate.IfLongitudeOutOfRange(degree));


        // Assert
        act.Validate<PropertyException>(HttpStatusCode.BadRequest, nameof(degree), ErrorCodes.MIN_LONGITUDE);
    }

    [Fact]
    public void DecimalLongitude_Large_Exception()
    {
        // Arrange
        var degree = 180.1m;


        // Act
        var act = Record.Exception(() => Guard.Validate.IfLongitudeOutOfRange(degree));


        // Assert
        act.Validate<PropertyException>(HttpStatusCode.BadRequest, nameof(degree), ErrorCodes.MAX_LONGITUDE);
    }

    [Fact]
    public void DecimalLongitude_Valid_NotException()
    {
        // Arrange
        var degree = 18.1m;


        // Act
        var act = Record.Exception(() => Guard.Validate.IfLongitudeOutOfRange(degree));


        // Assert
        act.Should()
            .BeNull();
    }

    [Fact]
    public void DecimalLatitudeNullable_Null_NotException()
    {
        // Arrange
        decimal? degree = null;


        // Act
        var act = Record.Exception(() => Guard.Validate.IfLatitudeOutOfRange(degree));


        // Assert
        act.Should()
            .BeNull();
    }

    [Fact]
    public void DecimalLatitudeNullable_Small_Exception()
    {
        // Arrange
        decimal? degree = -90.1m;


        // Act
        var act = Record.Exception(() => Guard.Validate.IfLatitudeOutOfRange(degree));


        // Assert
        act.Validate<PropertyException>(HttpStatusCode.BadRequest, nameof(degree), ErrorCodes.MIN_LATITUDE);
    }

    [Fact]
    public void DecimalLatitudeNullable_Large_Exception()
    {
        // Arrange
        decimal? degree = 90.1m;


        // Act
        var act = Record.Exception(() => Guard.Validate.IfLatitudeOutOfRange(degree));


        // Assert
        act.Validate<PropertyException>(HttpStatusCode.BadRequest, nameof(degree), ErrorCodes.MAX_LATITUDE);
    }

    [Fact]
    public void DecimalLatitudeNullable_Valid_NotException()
    {
        // Arrange
        decimal? degree = 18.1m;


        // Act
        var act = Record.Exception(() => Guard.Validate.IfLatitudeOutOfRange(degree));


        // Assert
        act.Should()
            .BeNull();
    }

    [Fact]
    public void DecimalLongitudeNullable_Null_NotException()
    {
        // Arrange
        decimal? degree = null;


        // Act
        var act = Record.Exception(() => Guard.Validate.IfLongitudeOutOfRange(degree));


        // Assert
        act.Should()
            .BeNull();
    }

    [Fact]
    public void DecimalLongitudeNullable_Small_Exception()
    {
        // Arrange
        decimal? degree = -180.1m;


        // Act
        var act = Record.Exception(() => Guard.Validate.IfLongitudeOutOfRange(degree));


        // Assert
        act.Validate<PropertyException>(HttpStatusCode.BadRequest, nameof(degree), ErrorCodes.MIN_LONGITUDE);
    }

    [Fact]
    public void DecimalLongitudeNullable_Large_Exception()
    {
        // Arrange
        decimal? degree = 180.1m;


        // Act
        var act = Record.Exception(() => Guard.Validate.IfLongitudeOutOfRange(degree));


        // Assert
        act.Validate<PropertyException>(HttpStatusCode.BadRequest, nameof(degree), ErrorCodes.MAX_LONGITUDE);
    }

    [Fact]
    public void DecimalLongitudeNullable_Valid_NotException()
    {
        // Arrange
        decimal? degree = 18.1m;


        // Act
        var act = Record.Exception(() => Guard.Validate.IfLongitudeOutOfRange(degree));


        // Assert
        act.Should()
            .BeNull();
    }
}
