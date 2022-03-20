using System;
using System.Net;
using PowerUtils.Validations;
using PowerUtils.Validations.Exceptions;
using PowerUtils.Validations.GuardClauses;

namespace PowerUtils.GuardClauses.Validations.Tests.GuardClausesTests;

[Trait("Type", "Guards")]
public class GuardValidationGuidExtensionsTests
{
    [Fact]
    public void IfEmpty_Empty_Exception()
    {
        // Arrange
        var id = Guid.Empty;


        // Act
        var act = Record.Exception(() => Guard.Validate.IfEmpty(id));


        // Assert
        act.Validate<PropertyException>(HttpStatusCode.BadRequest, nameof(id), ErrorCodes.REQUIRED);
    }

    [Fact]
    public void IfEmpty_NotEmpty_Valid()
    {
        // Arrange
        var id = Guid.NewGuid();


        // Act
        var act = Record.Exception(() => Guard.Validate.IfEmpty(id));


        // Assert
        act.Should()
            .BeNull();
    }

    [Fact]
    public void IfEquals_Equals_Exception()
    {
        // Arrange
        var id = Guid.Parse("dd348c71-3115-493f-873c-03bd4ccfae02");


        // Act
        var act = Record.Exception(() => Guard.Validate.IfEquals(id, Guid.Parse("dd348c71-3115-493f-873c-03bd4ccfae02")));


        // Assert
        act.Validate<PropertyException>(HttpStatusCode.BadRequest, nameof(id), "INVALID");
    }

    [Fact]
    public void IfEquals_Different_Valid()
    {
        // Arrange
        var id = Guid.Parse("ec243094-2d85-41a5-bd15-ce8f3af96b96");


        // Act
        var act = Record.Exception(() => Guard.Validate.IfEquals(id, Guid.Parse("dd348c71-3115-493f-873c-03bd4ccfae02")));


        // Assert
        act.Should()
            .BeNull();
    }


    [Fact]
    public void IfEqualsNullable_Null_Valid()
    {
        // Arrange
        Guid? id = null;


        // Act
        var act = Record.Exception(() => Guard.Validate.IfEquals(id, Guid.Parse("dd348c71-3115-493f-873c-03bd4ccfae02")));


        // Assert
        act.Should()
            .BeNull();
    }

    [Fact]
    public void IfEqualsNullable_BothNull_Exception()
    {
        // Arrange
        Guid? id = null;


        // Act
        var act = Record.Exception(() => Guard.Validate.IfEquals(id, null));


        // Assert
        act.Validate<PropertyException>(HttpStatusCode.BadRequest, nameof(id), "INVALID");
    }

    [Fact]
    public void IfEqualsNullable_Equals_Exception()
    {
        // Arrange
        Guid? id = Guid.Parse("dd348c71-3115-493f-873c-03bd4ccfae02");


        // Act
        var act = Record.Exception(() => Guard.Validate.IfEquals(id, Guid.Parse("dd348c71-3115-493f-873c-03bd4ccfae02")));


        // Assert
        act.Validate<PropertyException>(HttpStatusCode.BadRequest, nameof(id), "INVALID");
    }

    [Fact]
    public void IfEqualsNullable_Different_Valid()
    {
        // Arrange
        Guid? id = Guid.Parse("dd348c71-3115-493f-873c-03bd4ccfae02");


        // Act
        var act = Record.Exception(() => Guard.Validate.IfEquals(id, Guid.Parse("ec243094-2d85-41a5-bd15-ce8f3af96b96")));


        // Assert
        act.Should()
            .BeNull();
    }


    [Fact]
    public void IfDifferent_Equals_Valid()
    {
        // Arrange
        Guid? id = Guid.Parse("ec243094-2d85-41a5-bd15-ce8f3af96b96");


        // Act
        var act = Record.Exception(() => Guard.Validate.IfDifferent(id, Guid.Parse("ec243094-2d85-41a5-bd15-ce8f3af96b96")));


        // Assert
        act.Should()
            .BeNull();
    }

    [Fact]
    public void IfDifferent_Different_Exception()
    {
        // Arrange
        Guid? id = Guid.Parse("ec243094-2d85-41a5-bd15-ce8f3af96b96");


        // Act
        var act = Record.Exception(() => Guard.Validate.IfDifferent(id, Guid.Parse("dd348c71-3115-493f-873c-03bd4ccfae02")));


        // Assert
        act.Validate<PropertyException>(HttpStatusCode.BadRequest, nameof(id), "INVALID");
    }


    [Fact]
    public void IfDifferentNullable_Null_Exception()
    {
        // Arrange
        Guid? id = null;


        // Act
        var act = Record.Exception(() => Guard.Validate.IfDifferent(id, Guid.Parse("dd348c71-3115-493f-873c-03bd4ccfae02")));


        // Assert
        act.Validate<PropertyException>(HttpStatusCode.BadRequest, nameof(id), "INVALID");
    }

    [Fact]
    public void IfDifferentNullable_BothNull_Exception()
    {
        // Arrange
        Guid? id = null;


        // Act
        var act = Record.Exception(() => Guard.Validate.IfDifferent(id, null));


        // Assert
        act.Should()
            .BeNull();
    }

    [Fact]
    public void IfDifferentNullable_Equals_Valid()
    {
        // Arrange
        Guid? id = Guid.Parse("ec243094-2d85-41a5-bd15-ce8f3af96b96");


        // Act
        var act = Record.Exception(() => Guard.Validate.IfDifferent(id, Guid.Parse("ec243094-2d85-41a5-bd15-ce8f3af96b96")));


        // Assert
        act.Should()
            .BeNull();
    }

    [Fact]
    public void IfDifferentNullable_Different_Exception()
    {
        // Arrange
        Guid? id = Guid.Parse("ec243094-2d85-41a5-bd15-ce8f3af96b96");


        // Act
        var act = Record.Exception(() => Guard.Validate.IfDifferent(id, Guid.Parse("dd348c71-3115-493f-873c-03bd4ccfae02")));


        // Assert
        act.Validate<PropertyException>(HttpStatusCode.BadRequest, nameof(id), "INVALID");
    }
}
