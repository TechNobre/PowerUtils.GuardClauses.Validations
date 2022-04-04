using System.Collections.Generic;
using System.Net;
using PowerUtils.GuardClauses.Validations.Tests.Fakes;
using PowerUtils.Validations;
using PowerUtils.Validations.Exceptions;
using PowerUtils.Validations.GuardClauses;

namespace PowerUtils.GuardClauses.Validations.Tests.GuardClausesTests;

[Trait("Type", "Guards")]
public class GuardValidationObjectExtensionsTests
{
    [Fact]
    public void IfNull_NullObject_Exception()
    {
        // Arrange
        object client = null;


        // Act
        var act = Record.Exception(() => Guard.Validate.IfNull(client));


        // Assert
        act.Validate<PropertyException>(HttpStatusCode.BadRequest, nameof(client), ErrorCodes.REQUIRED);
    }

    [Fact]
    public void IfNull_NullList_Exception()
    {
        // Arrange
        List<string> list = null;


        // Act
        var act = Record.Exception(() => Guard.Validate.IfNull(list));


        // Assert
        act.Validate<PropertyException>(HttpStatusCode.BadRequest, nameof(list), ErrorCodes.REQUIRED);
    }

    [Fact]
    public void IfNull_NullArray_Exception()
    {
        // Arrange
        string[] array = null;


        // Act
        var act = Record.Exception(() => Guard.Validate.IfNull(array));


        // Assert
        act.Validate<PropertyException>(HttpStatusCode.BadRequest, nameof(array), ErrorCodes.REQUIRED);
    }

    [Fact]
    public void IfNull_NotNull_Valid()
    {
        // Arrange
        var client = new object();


        // Act
        var act = Guard.Validate.IfNull(client);


        // Assert
        act.Should()
            .Be(client);
    }

    [Fact]
    public void IfNull_NullClass_Valid()
    {
        // Arrange
        FakeObj fakeObj = null;


        // Act
        var act = Record.Exception(() => Guard.Validate.IfNull(fakeObj));


        // Assert
        act.Validate<PropertyException>(
            HttpStatusCode.BadRequest,
            nameof(fakeObj),
            ErrorCodes.REQUIRED
        );
    }

    [Fact]
    public void IfNull_NotNullClass_Valid()
    {
        // Arrange
        var fakeObj = new FakeObj();


        // Act
        var act = Guard.Validate.IfNull(fakeObj);


        // Assert
        act.Should()
            .Be(fakeObj);
        act.Should()
            .BeOfType<FakeObj>();
    }
}
