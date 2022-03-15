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
        act.Validate<PropertyException>(HttpStatusCode.BadRequest, nameof(quantity), "MAX:5");
    }

    [Fact]
    public void IfGreaterThan_NotLargeNumber_Valid()
    {
        // Arrange
        var quantity = 4f;


        // Act
        var act = Record.Exception(() => Guard.Validate.IfGreaterThan(quantity, 5f));


        // Assert
        act.Should()
            .BeNull();
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
            .BeNull();
    }


    [Fact]
    public void IfGreaterThanNullable_LargeNumber_Exception()
    {
        // Arrange
        float? quantity = 241;


        // Act
        var act = Record.Exception(() => Guard.Validate.IfGreaterThan(quantity, 5f));


        // Assert
        act.Validate<PropertyException>(HttpStatusCode.BadRequest, nameof(quantity), "MAX:5");
    }

    [Fact]
    public void IfGreaterThanNullable_NotLargeNumber_Valid()
    {
        // Arrange
        float? quantity = 4;


        // Act
        var act = Record.Exception(() => Guard.Validate.IfGreaterThan(quantity, 5f));


        // Assert
        act.Should()
            .BeNull();
    }



    [Fact]
    public void IfLessThan_SmallNumber_Exception()
    {
        // Arrange
        var quantity = 4f;


        // Act
        var act = Record.Exception(() => Guard.Validate.IfLessThan(quantity, 5f));


        // Assert
        act.Validate<PropertyException>(HttpStatusCode.BadRequest, nameof(quantity), "MIN:5");
    }

    [Fact]
    public void IfLessThan_NotSmallNumber_Valid()
    {
        // Arrange
        var quantity = 14f;


        // Act
        var act = Record.Exception(() => Guard.Validate.IfLessThan(quantity, 5f));


        // Assert
        act.Should()
            .BeNull();
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
            .BeNull();
    }


    [Fact]
    public void IfLessThanNullable_SmallNumber_Exception()
    {
        // Arrange
        float? quantity = 2;


        // Act
        var act = Record.Exception(() => Guard.Validate.IfLessThan(quantity, 5f));


        // Assert
        act.Validate<PropertyException>(HttpStatusCode.BadRequest, nameof(quantity), "MIN:5");
    }

    [Fact]
    public void IfLessThanNullable_NotSmallNumber_Valid()
    {
        // Arrange
        float? quantity = 45;


        // Act
        var act = Record.Exception(() => Guard.Validate.IfLessThan(quantity, 5f));


        // Assert
        act.Should()
            .BeNull();
    }
}
