using System.Net;
using PowerUtils.Validations.Exceptions;
using PowerUtils.Validations.GuardClauses;

namespace PowerUtils.GuardClauses.Validations.Tests.GuardClausesTests;

[Trait("Type", "Guards")]
public class GuardValidationULongExtensionsTests
{
    [Fact]
    public void IfGreaterThan_LargeNumber_Exception()
    {
        // Arrange
        var quantity = 241Lu;


        // Act
        var act = Record.Exception(() => Guard.Validate.IfGreaterThan(quantity, 5Lu));


        // Assert
        act.Validate<PropertyException>(HttpStatusCode.BadRequest, nameof(quantity), "MAX:5");
    }

    [Fact]
    public void IfGreaterThan_NotLargeNumber_Valid()
    {
        // Arrange
        var quantity = 4Lu;


        // Act
        var act = Guard.Validate.IfGreaterThan(quantity, 5Lu);


        // Assert
        act.Should()
            .Be(quantity);
    }



    [Fact]
    public void IfGreaterThanNullable_Null_Valid()
    {
        // Arrange
        ulong? quantity = null;


        // Act
        var act = Record.Exception(() => Guard.Validate.IfGreaterThan(quantity, 5Lu));


        // Assert
        act.Should()
            .Be(quantity);
    }


    [Fact]
    public void IfGreaterThanNullable_LargeNumber_Exception()
    {
        // Arrange
        ulong? quantity = 241;


        // Act
        var act = Record.Exception(() => Guard.Validate.IfGreaterThan(quantity, 5Lu));


        // Assert
        act.Validate<PropertyException>(HttpStatusCode.BadRequest, nameof(quantity), "MAX:5");
    }

    [Fact]
    public void IfGreaterThanNullable_NotLargeNumber_Valid()
    {
        // Arrange
        ulong? quantity = 4;


        // Act
        var act = Guard.Validate.IfGreaterThan(quantity, 5Lu);


        // Assert
        act.Should()
            .Be(quantity);
    }



    [Fact]
    public void IfLessThan_SmallNumber_Exception()
    {
        // Arrange
        var quantity = 4Lu;


        // Act
        var act = Record.Exception(() => Guard.Validate.IfLessThan(quantity, 5Lu));


        // Assert
        act.Validate<PropertyException>(HttpStatusCode.BadRequest, nameof(quantity), "MIN:5");
    }

    [Fact]
    public void IfLessThan_NotSmallNumber_Valid()
    {
        // Arrange
        var quantity = 14Lu;


        // Act
        var act = Guard.Validate.IfLessThan(quantity, 5Lu);


        // Assert
        act.Should()
            .Be(quantity);
    }



    [Fact]
    public void IfLessThanNullable_Null_Valid()
    {
        // Arrange
        ulong? quantity = null;


        // Act
        var act = Record.Exception(() => Guard.Validate.IfLessThan(quantity, 5Lu));


        // Assert
        act.Should()
            .Be(quantity);
    }


    [Fact]
    public void IfLessThanNullable_SmallNumber_Exception()
    {
        // Arrange
        ulong? quantity = 2;


        // Act
        var act = Record.Exception(() => Guard.Validate.IfLessThan(quantity, 5Lu));


        // Assert
        act.Validate<PropertyException>(HttpStatusCode.BadRequest, nameof(quantity), "MIN:5");
    }

    [Fact]
    public void IfLessThanNullable_NotSmallNumber_Valid()
    {
        // Arrange
        ulong? quantity = 45;


        // Act
        var act = Guard.Validate.IfLessThan(quantity, 5Lu);


        // Assert
        act.Should()
            .Be(quantity);
    }


    [Fact]
    public void IfEquals_Equals_Exception()
    {
        // Arrange
        ulong quantity = 5;


        // Act
        var act = Record.Exception(() => Guard.Validate.IfEquals(quantity, 5));


        // Assert
        act.Validate<PropertyException>(HttpStatusCode.BadRequest, nameof(quantity), "INVALID");
    }

    [Fact]
    public void IfEquals_Different_Valid()
    {
        // Arrange
        ulong quantity = 5;


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
        ulong? quantity = null;


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
        ulong? quantity = 4;


        // Act
        var act = Record.Exception(() => Guard.Validate.IfEquals(quantity, 4));


        // Assert
        act.Validate<PropertyException>(HttpStatusCode.BadRequest, nameof(quantity), "INVALID");
    }

    [Fact]
    public void IfEqualsNullable_Different_Valid()
    {
        // Arrange
        ulong? quantity = 5;


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
        ulong quantity = 22;


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
        ulong quantity = 51;


        // Act
        var act = Record.Exception(() => Guard.Validate.IfDifferent(quantity, 12));


        // Assert
        act.Validate<PropertyException>(HttpStatusCode.BadRequest, nameof(quantity), "INVALID");
    }


    [Fact]
    public void IfDifferentNullable_Null_Exception()
    {
        // Arrange
        ulong? quantity = null;


        // Act
        var act = Record.Exception(() => Guard.Validate.IfDifferent(quantity, 74));


        // Assert
        act.Validate<PropertyException>(HttpStatusCode.BadRequest, nameof(quantity), "INVALID");
    }

    [Fact]
    public void IfDifferentNullable_Equals_Valid()
    {
        // Arrange
        ulong? quantity = 78;


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
        ulong? quantity = 45;


        // Act
        var act = Record.Exception(() => Guard.Validate.IfDifferent(quantity, 321));


        // Assert
        act.Validate<PropertyException>(HttpStatusCode.BadRequest, nameof(quantity), "INVALID");
    }

    [Fact]
    public void IfOutOfRange_InRange_Valid()
    {
        // Arrange
        ulong quantity = 45;


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
        ulong quantity = 5;


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
        ulong quantity = 55;


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
        ulong? quantity = null;


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
        ulong? quantity = 45;


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
        ulong? quantity = 5;


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
        ulong? quantity = 55;


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
