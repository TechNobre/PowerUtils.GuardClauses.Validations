using System.Net;
using PowerUtils.Validations.Exceptions;
using PowerUtils.Validations.GuardClauses;

namespace PowerUtils.GuardClauses.Validations.Tests.GuardClausesTests;

[Trait("Type", "Guards")]
public class GuardValidationDecimalExtensionsTests
{
    [Fact]
    public void IfGreaterThan_LargeNumber_Exception()
    {
        // Arrange
        var quantity = 24m;


        // Act
        var act = Record.Exception(() => Guard.Validate.IfGreaterThan(quantity, 5m));


        // Assert
        act.Validate<PropertyException>(
            HttpStatusCode.BadRequest,
            nameof(quantity),
            "MAX:5"
        );
    }

    [Fact]
    public void IfGreaterThan_NotLargeNumber_Valid()
    {
        // Arrange
        var quantity = 4m;


        // Act
        var act = Guard.Validate.IfGreaterThan(quantity, 5m);


        // Assert
        act.Should()
            .Be(quantity);
    }



    [Fact]
    public void IfGreaterThanNullable_Null_Valid()
    {
        // Arrange
        decimal? quantity = null;


        // Act
        var act = Record.Exception(() => Guard.Validate.IfGreaterThan(quantity, 5m));


        // Assert
        act.Should()
            .Be(quantity);
    }


    [Fact]
    public void IfGreaterThanNullable_LargeNumber_Exception()
    {
        // Arrange
        decimal? quantity = 241;


        // Act
        var act = Record.Exception(() => Guard.Validate.IfGreaterThan(quantity, 5m));


        // Assert
        act.Validate<PropertyException>(
            HttpStatusCode.BadRequest,
            nameof(quantity),
            "MAX:5"
        );
    }

    [Fact]
    public void IfGreaterThanNullable_NotLargeNumber_Valid()
    {
        // Arrange
        decimal? quantity = 4;


        // Act
        var act = Guard.Validate.IfGreaterThan(quantity, 5m);


        // Assert
        act.Should()
            .Be(quantity);
    }



    [Fact]
    public void IfLessThan_SmallNumber_Exception()
    {
        // Arrange
        var quantity = 4m;


        // Act
        var act = Record.Exception(() => Guard.Validate.IfLessThan(quantity, 5m));


        // Assert
        act.Validate<PropertyException>(
            HttpStatusCode.BadRequest,
            nameof(quantity),
            "MIN:5"
        );
    }

    [Fact]
    public void IfLessThan_NotSmallNumber_Valid()
    {
        // Arrange
        var quantity = 14m;


        // Act
        var act = Guard.Validate.IfLessThan(quantity, 5m);


        // Assert
        act.Should()
            .Be(quantity);
    }



    [Fact]
    public void IfLessThanNullable_Null_Valid()
    {
        // Arrange
        decimal? quantity = null;


        // Act
        var act = Record.Exception(() => Guard.Validate.IfLessThan(quantity, 5m));


        // Assert
        act.Should()
            .Be(quantity);
    }


    [Fact]
    public void IfLessThanNullable_SmallNumber_Exception()
    {
        // Arrange
        decimal? quantity = 2;


        // Act
        var act = Record.Exception(() => Guard.Validate.IfLessThan(quantity, 5m));


        // Assert
        act.Validate<PropertyException>(
            HttpStatusCode.BadRequest,
            nameof(quantity),
            "MIN:5"
        );
    }

    [Fact]
    public void IfLessThanNullable_NotSmallNumber_Valid()
    {
        // Arrange
        decimal? quantity = 45;


        // Act
        var act = Guard.Validate.IfLessThan(quantity, 5m);


        // Assert
        act.Should()
            .Be(quantity);
    }



    [Fact]
    public void IfEquals_Equals_Exception()
    {
        // Arrange
        decimal quantity = 5;


        // Act
        var act = Record.Exception(() => Guard.Validate.IfEquals(quantity, 5));


        // Assert
        act.Validate<PropertyException>(
            HttpStatusCode.BadRequest,
            nameof(quantity),
            "INVALID"
        );
    }

    [Fact]
    public void IfEquals_Different_Valid()
    {
        // Arrange
        decimal quantity = 5;


        // Act
        var act = Guard.Validate.IfEquals(quantity, 6);


        // Assert
        act.Should()
            .Be(quantity);
    }


    [Fact]
    public void IfEqualsNullable_Null_Valid()
    {
        // Arrange
        decimal? quantity = null;


        // Act
        var act = Record.Exception(() => Guard.Validate.IfEquals(quantity, 5));


        // Assert
        act.Should()
            .Be(quantity);
    }

    [Fact]
    public void IfEqualsNullable_Equals_Exception()
    {
        // Arrange
        decimal? quantity = 4;


        // Act
        var act = Record.Exception(() => Guard.Validate.IfEquals(quantity, 4));


        // Assert
        act.Validate<PropertyException>(
            HttpStatusCode.BadRequest,
            nameof(quantity),
            "INVALID"
        );
    }

    [Fact]
    public void IfEqualsNullable_Different_Valid()
    {
        // Arrange
        decimal? quantity = 5;


        // Act
        var act = Guard.Validate.IfEquals(quantity, 4);


        // Assert
        act.Should()
            .Be(quantity);
    }


    [Fact]
    public void IfDifferent_Equals_Valid()
    {
        // Arrange
        decimal quantity = 22;


        // Act
        var act = Guard.Validate.IfDifferent(quantity, 22);


        // Assert
        act.Should()
            .Be(quantity);
    }

    [Fact]
    public void IfDifferent_Different_Exception()
    {
        // Arrange
        decimal quantity = 51;


        // Act
        var act = Record.Exception(() => Guard.Validate.IfDifferent(quantity, 12));


        // Assert
        act.Validate<PropertyException>(
            HttpStatusCode.BadRequest,
            nameof(quantity),
            "INVALID"
        );
    }


    [Fact]
    public void IfDifferentNullable_Null_Exception()
    {
        // Arrange
        decimal? quantity = null;


        // Act
        var act = Record.Exception(() => Guard.Validate.IfDifferent(quantity, 74));


        // Assert
        act.Validate<PropertyException>(
            HttpStatusCode.BadRequest,
            nameof(quantity),
            "INVALID"
        );
    }

    [Fact]
    public void IfDifferentNullable_Equals_Valid()
    {
        // Arrange
        decimal? quantity = 78;


        // Act
        var act = Guard.Validate.IfDifferent(quantity, 78);


        // Assert
        act.Should()
            .Be(quantity);
    }

    [Fact]
    public void IfDifferentNullable_Different_Exception()
    {
        // Arrange
        decimal? quantity = 45;


        // Act
        var act = Record.Exception(() => Guard.Validate.IfDifferent(quantity, 321));


        // Assert
        act.Validate<PropertyException>(
            HttpStatusCode.BadRequest,
            nameof(quantity),
            "INVALID"
        );
    }
}
