using System;
using System.Net;
using PowerUtils.Validations;
using PowerUtils.Validations.Exceptions;
using PowerUtils.Validations.GuardClauses;

namespace PowerUtils.GuardClauses.Validations.Tests.GuardClausesTests;

public class GuardValidationGuidExtensionsTests
{
    [Fact]
    public void Empty_IfEmpty_PropertyException()
    {
        // Arrange
        var id = Guid.Empty;


        // Act
        var act = Record.Exception(() => Guard.Validate.IfEmpty(id));


        // Assert
        act.Validate<PropertyException>(HttpStatusCode.BadRequest, nameof(id), ErrorCodes.REQUIRED);
    }

    [Fact]
    public void NotEmpty_IfEmpty_Valid()
    {
        // Arrange
        var id = Guid.NewGuid();


        // Act
        var act = Guard.Validate.IfEmpty(id);


        // Assert
        act.Should()
            .Be(id);
    }

    [Fact]
    public void Equals_IfEquals_PropertyException()
    {
        // Arrange
        var id = Guid.Parse("dd348c71-3115-493f-873c-03bd4ccfae02");


        // Act
        var act = Record.Exception(() => Guard.Validate.IfEquals(id, Guid.Parse("dd348c71-3115-493f-873c-03bd4ccfae02")));


        // Assert
        act.Validate<PropertyException>(HttpStatusCode.BadRequest, nameof(id), "INVALID");
    }

    [Fact]
    public void Different_IfEquals_Valid()
    {
        // Arrange
        var id = Guid.Parse("ec243094-2d85-41a5-bd15-ce8f3af96b96");


        // Act
        var act = Guard.Validate.IfEquals(id, Guid.Parse("dd348c71-3115-493f-873c-03bd4ccfae02"));


        // Assert
        act.Should()
            .Be(id);
    }


    [Fact]
    public void Null_IfEqualsNullable_Valid()
    {
        // Arrange
        Guid? id = null;


        // Act
        var act = Record.Exception(() => Guard.Validate.IfEquals(id, Guid.Parse("dd348c71-3115-493f-873c-03bd4ccfae02")));


        // Assert
        act.Should()
            .Be(id);
    }

    [Fact]
    public void BothNull_IfEqualsNullable_PropertyException()
    {
        // Arrange
        Guid? id = null;


        // Act
        var act = Record.Exception(() => Guard.Validate.IfEquals(id, null));


        // Assert
        act.Validate<PropertyException>(HttpStatusCode.BadRequest, nameof(id), "INVALID");
    }

    [Fact]
    public void Equals_IfEqualsNullable_PropertyException()
    {
        // Arrange
        Guid? id = Guid.Parse("dd348c71-3115-493f-873c-03bd4ccfae02");


        // Act
        var act = Record.Exception(() => Guard.Validate.IfEquals(id, Guid.Parse("dd348c71-3115-493f-873c-03bd4ccfae02")));


        // Assert
        act.Validate<PropertyException>(HttpStatusCode.BadRequest, nameof(id), "INVALID");
    }

    [Fact]
    public void Different_IfEqualsNullable_Valid()
    {
        // Arrange
        Guid? id = Guid.Parse("dd348c71-3115-493f-873c-03bd4ccfae02");


        // Act
        var act = Guard.Validate.IfEquals(id, Guid.Parse("ec243094-2d85-41a5-bd15-ce8f3af96b96"));


        // Assert
        act.Should()
            .Be(id);
    }


    [Fact]
    public void Equals_IfDifferent_Valid()
    {
        // Arrange
        Guid? id = Guid.Parse("ec243094-2d85-41a5-bd15-ce8f3af96b96");


        // Act
        var act = Guard.Validate.IfDifferent(id, Guid.Parse("ec243094-2d85-41a5-bd15-ce8f3af96b96"));


        // Assert
        act.Should()
            .Be(id);
    }

    [Fact]
    public void Different_IfDifferent_PropertyException()
    {
        // Arrange
        Guid? id = Guid.Parse("ec243094-2d85-41a5-bd15-ce8f3af96b96");


        // Act
        var act = Record.Exception(() => Guard.Validate.IfDifferent(id, Guid.Parse("dd348c71-3115-493f-873c-03bd4ccfae02")));


        // Assert
        act.Validate<PropertyException>(HttpStatusCode.BadRequest, nameof(id), "INVALID");
    }


    [Fact]
    public void Null_IfDifferentNullable_PropertyException()
    {
        // Arrange
        Guid? id = null;


        // Act
        var act = Record.Exception(() => Guard.Validate.IfDifferent(id, Guid.Parse("dd348c71-3115-493f-873c-03bd4ccfae02")));


        // Assert
        act.Validate<PropertyException>(HttpStatusCode.BadRequest, nameof(id), "INVALID");
    }

    [Fact]
    public void BothNull_IfDifferentNullable_PropertyException()
    {
        // Arrange
        Guid? id = null;


        // Act
        var act = Record.Exception(() => Guard.Validate.IfDifferent(id, null));


        // Assert
        act.Should()
            .Be(id);
    }

    [Fact]
    public void Equals_IfDifferentNullable_Valid()
    {
        // Arrange
        Guid? id = Guid.Parse("ec243094-2d85-41a5-bd15-ce8f3af96b96");


        // Act
        var act = Guard.Validate.IfDifferent(id, Guid.Parse("ec243094-2d85-41a5-bd15-ce8f3af96b96"));


        // Assert
        act.Should()
            .Be(id);
    }

    [Fact]
    public void Different_IfDifferentNullable_PropertyException()
    {
        // Arrange
        Guid? id = Guid.Parse("ec243094-2d85-41a5-bd15-ce8f3af96b96");


        // Act
        var act = Record.Exception(() => Guard.Validate.IfDifferent(id, Guid.Parse("dd348c71-3115-493f-873c-03bd4ccfae02")));


        // Assert
        act.Validate<PropertyException>(HttpStatusCode.BadRequest, nameof(id), "INVALID");
    }
}
