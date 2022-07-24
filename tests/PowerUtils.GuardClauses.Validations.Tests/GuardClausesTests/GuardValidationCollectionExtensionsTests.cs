using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using PowerUtils.Validations;
using PowerUtils.Validations.Exceptions;
using PowerUtils.Validations.GuardClauses;

namespace PowerUtils.GuardClauses.Validations.Tests.GuardClausesTests;

public class GuardValidationCollectionExtensionsTests
{
    [Fact]
    public void NullEnumerable_IfNull_PropertyException()
    {
        // Arrange
        IEnumerable<string> prodList = null;


        // Act
        var act = Record.Exception(() => Guard.Validate.IfNull(prodList));


        // Assert
        act.Validate<PropertyException>(
            HttpStatusCode.BadRequest,
            nameof(prodList),
            ErrorCodes.REQUIRED
        );
    }

    [Fact]
    public void EmptyEnumerable_IfNull_Valid()
    {
        // Arrange
        IEnumerable<string> prodList = new List<string>();


        // Act
        var act = Guard.Validate.IfNull(prodList);


        // Assert
        act.Should()
            .BeEquivalentTo(prodList);
    }



    [Fact]
    public void NullCollection_IfEmpty_Valid()
    {
        // Arrange
        ICollection<string> prodList = null;


        // Act
        var act = Record.Exception(() => Guard.Validate.IfEmpty(prodList));


        // Assert
        act.Should()
            .BeEquivalentTo(prodList);
    }

    [Fact]
    public void EmptyCollection_IfEmpty_PropertyException()
    {
        // Arrange
        ICollection<string> prodList = new List<string>();


        // Act
        var act = Record.Exception(() => Guard.Validate.IfEmpty(prodList));


        // Assert
        act.Validate<PropertyException>(
            HttpStatusCode.BadRequest,
            nameof(prodList),
            ErrorCodes.REQUIRED
        );
    }

    [Fact]
    public void WithItemsCollection_IfEmpty_Valid()
    {
        // Arrange
        ICollection<string> prodList = new List<string> { "fake", "fake2" };


        // Act
        var act = Guard.Validate.IfEmpty(prodList);


        // Assert
        act.Should()
            .BeEquivalentTo(prodList);
    }


    [Fact]
    public void NullArray_IfNullOrEmpty_PropertyException()
    {
        // Arrange
        string[] prodList = null;


        // Act
        var act = Record.Exception(() => Guard.Validate.IfNullOrEmpty(prodList));


        // Assert
        act.Validate<PropertyException>(
            HttpStatusCode.BadRequest,
            nameof(prodList),
            ErrorCodes.REQUIRED
        );
    }

    [Fact]
    public void EmptyArray_IfNullOrEmpty_PropertyException()
    {
        // Arrange
        var prodList = Array.Empty<string>();


        // Act
        var act = Record.Exception(() => Guard.Validate.IfNullOrEmpty(prodList));


        // Assert
        act.Validate<PropertyException>(
            HttpStatusCode.BadRequest,
            nameof(prodList),
            ErrorCodes.REQUIRED
        );
    }

    [Fact]
    public void WithItemsArray_IfNullOrEmpty_Valid()
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
    public void NullEnumerable_IfCountGreaterThan_Valid()
    {
        // Arrange
        IEnumerable<string> prodList = null;


        // Act
        var act = Record.Exception(() => Guard.Validate.IfCountGreaterThan(prodList, 3));


        // Assert
        act.Should()
            .BeEquivalentTo(prodList);
    }

    [Fact]
    public void FewItems_IfCountGreaterThan_Valid()
    {
        // Arrange
        IEnumerable<string> prodList = new string[] { "fake", "fake2" };


        // Act
        var act = Guard.Validate.IfCountGreaterThan(prodList, 3);


        // Assert
        act.Should()
            .BeEquivalentTo(prodList);
    }

    [Fact]
    public void ManyItems_IfCountGreaterThan_PropertyException()
    {
        // Arrange
        IEnumerable<string> prodList = new string[] { "fake", "fake2", "fake3", "fake4" };


        // Act
        var act = Record.Exception(() => Guard.Validate.IfCountGreaterThan(prodList, 3));


        // Assert
        act.Validate<PropertyException>(
            HttpStatusCode.BadRequest,
            nameof(prodList),
            "MAX:3"
        );
    }

    [Fact]
    public void NullEnumerable_IfCountLessThan_PropertyException()
    {
        // Arrange
        IEnumerable<string> prodList = null;


        // Act
        var act = Record.Exception(() => Guard.Validate.IfCountLessThan(prodList, 3));


        // Assert
        act.Validate<PropertyException>(
            HttpStatusCode.BadRequest,
            nameof(prodList),
            "MIN:3"
        );
    }

    [Fact]
    public void FewItems_IfCountLessThan_PropertyException()
    {
        // Arrange
        var prodList = new List<string> { "fake", "fake2", "moq1", "moq2" };
        var enumerable = prodList.Where(w => w.Contains("fake"));


        // Act
        var act = Record.Exception(() => Guard.Validate.IfCountLessThan(enumerable, 3));


        // Assert
        act.Validate<PropertyException>(
            HttpStatusCode.BadRequest,
            nameof(enumerable),
            "MIN:3"
        );
    }

    [Fact]
    public void ManyItems_IfCountLessThan_Valid()
    {
        // Arrange
        IEnumerable<string> prodList = new string[] { "fake", "fake2", "fake3", "fake4" };


        // Act
        var act = Guard.Validate.IfCountLessThan(prodList, 3);


        // Assert
        act.Should()
            .BeEquivalentTo(prodList);
    }
}
