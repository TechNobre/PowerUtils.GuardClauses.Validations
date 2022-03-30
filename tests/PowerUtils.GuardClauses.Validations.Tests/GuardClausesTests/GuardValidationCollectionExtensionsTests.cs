using System;
using System.Linq;
using System.Collections.Generic;
using System.Net;
using PowerUtils.Validations;
using PowerUtils.Validations.Exceptions;
using PowerUtils.Validations.GuardClauses;

namespace PowerUtils.GuardClauses.Validations.Tests.GuardClausesTests;

[Trait("Type", "Guards")]
public class GuardValidationCollectionExtensionsTests
{
    [Fact]
    public void IfNull_NullEnumerable_Exception()
    {
        // Arrange
        IEnumerable<string> prodList = null;


        // Act
        var act = Record.Exception(() => Guard.Validate.IfNull(prodList));


        // Assert
        act.Validate<PropertyException>(HttpStatusCode.BadRequest, nameof(prodList), ErrorCodes.REQUIRED);
    }

    [Fact]
    public void IfNull_EmptyEnumerable_Valid()
    {
        // Arrange
        IEnumerable<string> prodList = new List<string>();


        // Act
        var act = Record.Exception(() => Guard.Validate.IfNull(prodList));


        // Assert
        act.Should()
            .BeNull();
    }



    [Fact]
    public void IfEmpty_NullCollection_Valid()
    {
        // Arrange
        ICollection<string> prodList = null;


        // Act
        var act = Record.Exception(() => Guard.Validate.IfEmpty(prodList));


        // Assert
        act.Should()
            .BeNull();
    }

    [Fact]
    public void IfEmpty_EmptyCollection_Exception()
    {
        // Arrange
        ICollection<string> prodList = new List<string>();


        // Act
        var act = Record.Exception(() => Guard.Validate.IfEmpty(prodList));


        // Assert
        act.Validate<PropertyException>(HttpStatusCode.BadRequest, nameof(prodList), ErrorCodes.REQUIRED);
    }

    [Fact]
    public void IfEmpty_WithItemsCollection_Valid()
    {
        // Arrange
        ICollection<string> prodList = new List<string> { "fake", "fake2" };


        // Act
        var act = Record.Exception(() => Guard.Validate.IfEmpty(prodList));


        // Assert
        act.Should()
            .BeNull();
    }


    [Fact]
    public void IfNullOrEmpty_NullArray_Exception()
    {
        // Arrange
        string[] prodList = null;


        // Act
        var act = Record.Exception(() => Guard.Validate.IfNullOrEmpty(prodList));


        // Assert
        act.Validate<PropertyException>(HttpStatusCode.BadRequest, nameof(prodList), ErrorCodes.REQUIRED);
    }

    [Fact]
    public void IfNullOrEmpty_EmptyArray_Exception()
    {
        // Arrange
        var prodList = Array.Empty<string>();


        // Act
        var act = Record.Exception(() => Guard.Validate.IfNullOrEmpty(prodList));


        // Assert
        act.Validate<PropertyException>(HttpStatusCode.BadRequest, nameof(prodList), ErrorCodes.REQUIRED);
    }

    [Fact]
    public void IfNullOrEmpty_WithItemsArray_Valid()
    {
        // Arrange
        var prodList = new string[] { "fake", "fake2" };


        // Act
        var act = Record.Exception(() => Guard.Validate.IfNullOrEmpty(prodList));


        // Assert
        act.Should()
            .BeNull();
    }

    [Fact]
    public void IfCountGreaterThan_NullEnumerable_Valid()
    {
        // Arrange
        IEnumerable<string> prodList = null;


        // Act
        var act = Record.Exception(() => Guard.Validate.IfCountGreaterThan(prodList, 3));


        // Assert
        act.Should()
            .BeNull();
    }

    [Fact]
    public void IfCountGreaterThan_FewItems_Valid()
    {
        // Arrange
        IEnumerable<string> prodList = new string[] { "fake", "fake2" };


        // Act
        var act = Record.Exception(() => Guard.Validate.IfCountGreaterThan(prodList, 3));


        // Assert
        act.Should()
            .BeNull();
    }

    [Fact]
    public void IfCountGreaterThan_ManyItems_Exception()
    {
        // Arrange
        IEnumerable<string> prodList = new string[] { "fake", "fake2", "fake3", "fake4" };


        // Act
        var act = Record.Exception(() => Guard.Validate.IfCountGreaterThan(prodList, 3));


        // Assert
        act.Validate<PropertyException>(HttpStatusCode.BadRequest, nameof(prodList), "MAX:3");
    }

    [Fact]
    public void IfCountLessThan_NullEnumerable_Exception()
    {
        // Arrange
        IEnumerable<string> prodList = null;


        // Act
        var act = Record.Exception(() => Guard.Validate.IfCountLessThan(prodList, 3));


        // Assert
        act.Validate<PropertyException>(HttpStatusCode.BadRequest, nameof(prodList), "MIN:3");
    }

    [Fact]
    public void IfCountLessThan_FewItems_Exception()
    {
        // Arrange
        var prodList = new List<string> { "fake", "fake2", "moq1", "moq2" };
        var enumerable = prodList.Where(w => w.Contains("fake"));


        // Act
        var act = Record.Exception(() => Guard.Validate.IfCountLessThan(enumerable, 3));


        // Assert
        act.Validate<PropertyException>(HttpStatusCode.BadRequest, nameof(enumerable), "MIN:3");
    }

    [Fact]
    public void IfCountLessThan_ManyItems_Valid()
    {
        // Arrange
        IEnumerable<string> prodList = new string[] { "fake", "fake2", "fake3", "fake4" };


        // Act
        var act = Record.Exception(() => Guard.Validate.IfCountLessThan(prodList, 3));


        // Assert
        act.Should()
            .BeNull();
    }
}
