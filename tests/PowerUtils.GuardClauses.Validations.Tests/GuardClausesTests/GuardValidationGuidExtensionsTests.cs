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
}
