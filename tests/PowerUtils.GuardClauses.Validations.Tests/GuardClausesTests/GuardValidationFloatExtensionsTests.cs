using System.Net;
using PowerUtils.Validations.Exceptions;
using PowerUtils.Validations.GuardClauses;

namespace PowerUtils.GuardClauses.Validations.Tests.GuardClausesTests;

[Trait("Type", "Guards")]
public class GuardValidationFloatExtensionsTests
{
    [Fact]
    public void IfGreaterThan_LargeNumber_Exception()
    {
        // Arrange
        var quantity = 241f;


        // Act
        var act = Record.Exception(() => Guard.Validate.IfGreaterThan(quantity, 5f));


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
        var quantity = 4f;


        // Act
        var act = Guard.Validate.IfGreaterThan(quantity, 5f);


        // Assert
        act.Should()
            .Be(quantity);
    }



    [Fact]
    public void IfGreaterThanNullable_Null_Valid()
    {
        // Arrange
        float? quantity = null;


        // Act
        var act = Record.Exception(() => Guard.Validate.IfGreaterThan(quantity, 5f));


        // Assert
        act.Should()
            .Be(quantity);
    }


    [Fact]
    public void IfGreaterThanNullable_LargeNumber_Exception()
    {
        // Arrange
        float? quantity = 241;


        // Act
        var act = Record.Exception(() => Guard.Validate.IfGreaterThan(quantity, 5f));


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
        float? quantity = 4;


        // Act
        var act = Guard.Validate.IfGreaterThan(quantity, 5f);


        // Assert
        act.Should()
            .Be(quantity);
    }



    [Fact]
    public void IfLessThan_SmallNumber_Exception()
    {
        // Arrange
        var quantity = 4f;


        // Act
        var act = Record.Exception(() => Guard.Validate.IfLessThan(quantity, 5f));


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
        var quantity = 14f;


        // Act
        var act = Guard.Validate.IfLessThan(quantity, 5f);


        // Assert
        act.Should()
            .Be(quantity);
    }



    [Fact]
    public void IfLessThanNullable_Null_Valid()
    {
        // Arrange
        float? quantity = null;


        // Act
        var act = Record.Exception(() => Guard.Validate.IfLessThan(quantity, 5f));


        // Assert
        act.Should()
            .Be(quantity);
    }


    [Fact]
    public void IfLessThanNullable_SmallNumber_Exception()
    {
        // Arrange
        float? quantity = 2;


        // Act
        var act = Record.Exception(() => Guard.Validate.IfLessThan(quantity, 5f));


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
        float? quantity = 45;


        // Act
        var act = Guard.Validate.IfLessThan(quantity, 5f);


        // Assert
        act.Should()
            .Be(quantity);
    }


    [Fact]
    public void IfEquals_Equals_Exception()
    {
        // Arrange
        float quantity = 5;


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
        float quantity = 5;


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
        float? quantity = null;


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
        float? quantity = 4;


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
        float? quantity = 5;


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
        float quantity = 22;


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
        float quantity = 51;


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
        float? quantity = null;


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
        float? quantity = 78;


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
        float? quantity = 45;


        // Act
        var act = Record.Exception(() => Guard.Validate.IfDifferent(quantity, 321));


        // Assert
        act.Validate<PropertyException>(
            HttpStatusCode.BadRequest,
            nameof(quantity),
            "INVALID"
        );
    }

    [Fact]
    public void IfOutOfRange_InRange_Valid()
    {
        // Arrange
        var quantity = 45.45741f;


        // Act
        var act = Guard.Validate.IfOutOfRange(quantity, 10, 50);


        // Assert
        act.Should()
            .Be(quantity);
    }

    [Fact]
    public void IfOutOfRange_SmallNumber_Exception()
    {
        // Arrange
        var quantity = 5.45741f;


        // Act
        var act = Record.Exception(() => Guard.Validate.IfOutOfRange(quantity, 10, 50));


        // Assert
        act.Validate<PropertyException>(
            HttpStatusCode.BadRequest,
            nameof(quantity),
            "MIN:10"
        );
    }

    [Fact]
    public void IfOutOfRange_BigNumber_Exception()
    {
        // Arrange
        var quantity = 55.45741f;


        // Act
        var act = Record.Exception(() => Guard.Validate.IfOutOfRange(quantity, 10, 50));


        // Assert
        act.Validate<PropertyException>(
            HttpStatusCode.BadRequest,
            nameof(quantity),
            "MAX:50"
        );
    }

    [Fact]
    public void IfOutOfRangeNullable_NULL_Valid()
    {
        // Arrange
        float? quantity = null;


        // Act
        var act = Guard.Validate.IfOutOfRange(quantity, 10, 50);


        // Assert
        act.Should()
            .Be(quantity);
    }

    [Fact]
    public void IfOutOfRangeNullable_InRange_Valid()
    {
        // Arrange
        float? quantity = 45.45741f;
        

        // Act
        var act = Guard.Validate.IfOutOfRange(quantity, 10, 50);


        // Assert
        act.Should()
            .Be(quantity);
    }

    [Fact]
    public void IfOutOfRangeNullable_SmallNumber_Exception()
    {
        // Arrange
        float? quantity = 5.45741f;
        

        // Act
        var act = Record.Exception(() => Guard.Validate.IfOutOfRange(quantity, 10, 50));


        // Assert
        act.Validate<PropertyException>(
            HttpStatusCode.BadRequest,
            nameof(quantity),
            "MIN:10"
        );
    }

    [Fact]
    public void IfOutOfRangeNullable_BigNumber_Exception()
    {
        // Arrange
        float? quantity = 55.45741f;
        

        // Act
        var act = Record.Exception(() => Guard.Validate.IfOutOfRange(quantity, 10, 50));


        // Assert
        act.Validate<PropertyException>(
            HttpStatusCode.BadRequest,
            nameof(quantity),
            "MAX:50"
        );
    }
}
