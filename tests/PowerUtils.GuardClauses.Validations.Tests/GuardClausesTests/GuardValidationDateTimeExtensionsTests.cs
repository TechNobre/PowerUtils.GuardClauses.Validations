﻿using System;
using System.Net;
using PowerUtils.Validations.Exceptions;
using PowerUtils.Validations.GuardClauses;

namespace PowerUtils.GuardClauses.Validations.Tests.GuardClausesTests;

[Trait("Type", "Guards")]
public class GuardValidationDateTimeExtensionsTests
{
    [Fact]
    public void IfGreaterThan_FutureDate_Exception()
    {
        // Arrange
        var dateOfBirth = new DateTime(2012, 12, 12);


        // Act
        var act = Record.Exception(() => Guard.Validate.IfGreaterThan(dateOfBirth, new DateTime(2000, 12, 31)));


        // Assert
        act.Validate<PropertyException>(HttpStatusCode.BadRequest, nameof(dateOfBirth), "MAX:2000-12-31");
    }

    [Fact]
    public void IfGreaterThan_PastDate_Valid()
    {
        // Arrange
        var dateOfBirth = new DateTime(1980, 12, 12);


        // Act
        var act = Record.Exception(() => Guard.Validate.IfGreaterThan(dateOfBirth, new DateTime(2000, 12, 31)));


        // Assert
        act.Should()
            .BeNull();
    }



    [Fact]
    public void IfGreaterThanNullable_Null_Valid()
    {
        // Arrange
        DateTime? dateOfBirth = null;


        // Act
        var act = Record.Exception(() => Guard.Validate.IfGreaterThan(dateOfBirth, new DateTime(2000, 12, 31)));


        // Assert
        act.Should()
            .BeNull();
    }


    [Fact]
    public void IfGreaterThanNullable_FutureDate_Exception()
    {
        // Arrange
        DateTime? dateOfBirth = new DateTime(2012, 12, 12);


        // Act
        var act = Record.Exception(() => Guard.Validate.IfGreaterThan(dateOfBirth, new DateTime(2000, 12, 31)));


        // Assert
        act.Validate<PropertyException>(HttpStatusCode.BadRequest, nameof(dateOfBirth), "MAX:2000-12-31");
    }

    [Fact]
    public void IfGreaterThanNullable_PastDate_Valid()
    {
        // Arrange
        DateTime? dateOfBirth = new DateTime(1980, 12, 12);


        // Act
        var act = Record.Exception(() => Guard.Validate.IfGreaterThan(dateOfBirth, new DateTime(2000, 12, 31)));


        // Assert
        act.Should()
            .BeNull();
    }



    [Fact]
    public void IfLessThan_PastDate_Exception()
    {
        // Arrange
        var dateOfBirth = new DateTime(1980, 12, 12);


        // Act
        var act = Record.Exception(() => Guard.Validate.IfLessThan(dateOfBirth, new DateTime(2000, 12, 31)));


        // Assert
        act.Validate<PropertyException>(HttpStatusCode.BadRequest, nameof(dateOfBirth), "MIN:2000-12-31");
    }

    [Fact]
    public void IfLessThan_FutureDate_Valid()
    {
        // Arrange
        var dateOfBirth = new DateTime(2012, 12, 12);


        // Act
        var act = Record.Exception(() => Guard.Validate.IfLessThan(dateOfBirth, new DateTime(2000, 12, 31)));


        // Assert
        act.Should()
            .BeNull();
    }



    [Fact]
    public void IfLessThanNullable_Null_Valid()
    {
        // Arrange
        DateTime? dateOfBirth = null;


        // Act
        var act = Record.Exception(() => Guard.Validate.IfLessThan(dateOfBirth, new DateTime(2000, 12, 31)));


        // Assert
        act.Should()
            .BeNull();
    }


    [Fact]
    public void IfLessThanNullable_PastDate_Exception()
    {
        // Arrange
        DateTime? dateOfBirth = new DateTime(1980, 12, 12);


        // Act
        var act = Record.Exception(() => Guard.Validate.IfLessThan(dateOfBirth, new DateTime(2000, 12, 31)));


        // Assert
        act.Validate<PropertyException>(HttpStatusCode.BadRequest, nameof(dateOfBirth), "MIN:2000-12-31");
    }

    [Fact]
    public void IfLessThanNullable_FutureDate_Valid()
    {
        // Arrange
        DateTime? dateOfBirth = new DateTime(2012, 12, 12);


        // Act
        var act = Record.Exception(() => Guard.Validate.IfLessThan(dateOfBirth, new DateTime(2000, 12, 31)));


        // Assert
        act.Should()
            .BeNull();
    }




    [Fact]
    public void IfGreaterThanUtcNow_FutureDate_Exception()
    {
        // Arrange
        var dateOfBirth = DateTime.UtcNow.AddDays(9);


        // Act
        var act = Record.Exception(() => Guard.Validate.IfGreaterThanUtcNow(dateOfBirth));


        // Assert
        act.Validate<PropertyException>(HttpStatusCode.BadRequest, nameof(dateOfBirth), "MAX:DATETIME_UTCNOW");
    }

    [Fact]
    public void IfGreaterThanUtcNow_PastDate_Valid()
    {
        // Arrange
        var dateOfBirth = DateTime.UtcNow.AddDays(-9);


        // Act
        var act = Record.Exception(() => Guard.Validate.IfGreaterThanUtcNow(dateOfBirth));


        // Assert
        act.Should()
            .BeNull();
    }



    [Fact]
    public void IfGreaterThanUtcNowNullable_Null_Valid()
    {
        // Arrange
        DateTime? dateOfBirth = null;


        // Act
        var act = Record.Exception(() => Guard.Validate.IfGreaterThanUtcNow(dateOfBirth));


        // Assert
        act.Should()
            .BeNull();
    }


    [Fact]
    public void IfGreaterThanUtcNowNullable_FutureDate_Exception()
    {
        // Arrange
        DateTime? dateOfBirth = DateTime.UtcNow.AddDays(9);


        // Act
        var act = Record.Exception(() => Guard.Validate.IfGreaterThanUtcNow(dateOfBirth));


        // Assert
        act.Validate<PropertyException>(HttpStatusCode.BadRequest, nameof(dateOfBirth), "MAX:DATETIME_UTCNOW");
    }

    [Fact]
    public void IfGreaterThanUtcNowNullable_PastDate_Valid()
    {
        // Arrange
        DateTime? dateOfBirth = DateTime.UtcNow.AddDays(-9);


        // Act
        var act = Record.Exception(() => Guard.Validate.IfGreaterThanUtcNow(dateOfBirth));


        // Assert
        act.Should()
            .BeNull();
    }



    [Fact]
    public void IfLessThanUtcNow_PastDate_Exception()
    {
        // Arrange
        var dateOfBirth = DateTime.UtcNow.AddDays(-9);


        // Act
        var act = Record.Exception(() => Guard.Validate.IfLessThanUtcNow(dateOfBirth));


        // Assert
        act.Validate<PropertyException>(HttpStatusCode.BadRequest, nameof(dateOfBirth), "MIN:DATETIME_UTCNOW");
    }

    [Fact]
    public void IfLessThanUtcNow_FutureDate_Valid()
    {
        // Arrange
        var dateOfBirth = DateTime.UtcNow.AddDays(9);


        // Act
        var act = Record.Exception(() => Guard.Validate.IfLessThanUtcNow(dateOfBirth));


        // Assert
        act.Should()
            .BeNull();
    }



    [Fact]
    public void IfLessThanUtcNowNullable_Null_Valid()
    {
        // Arrange
        DateTime? dateOfBirth = null;


        // Act
        var act = Record.Exception(() => Guard.Validate.IfLessThanUtcNow(dateOfBirth));


        // Assert
        act.Should()
            .BeNull();
    }


    [Fact]
    public void IfLessThanUtcNowNullable_PastDate_Exception()
    {
        // Arrange
        DateTime? dateOfBirth = DateTime.UtcNow.AddDays(-9);


        // Act
        var act = Record.Exception(() => Guard.Validate.IfLessThanUtcNow(dateOfBirth));


        // Assert
        act.Validate<PropertyException>(HttpStatusCode.BadRequest, nameof(dateOfBirth), "MIN:DATETIME_UTCNOW");
    }

    [Fact]
    public void IfLessThanUtcNowNullable_FutureDate_Valid()
    {
        // Arrange
        DateTime? dateOfBirth = DateTime.UtcNow.AddDays(9);


        // Act
        var act = Record.Exception(() => Guard.Validate.IfLessThanUtcNow(dateOfBirth));


        // Assert
        act.Should()
            .BeNull();
    }



    [Fact]
    public void IfEquals_Equals_Exception()
    {
        // Arrange
        var dateOfBirth = new DateTime(2000, 12, 31);


        // Act
        var act = Record.Exception(() => Guard.Validate.IfEquals(dateOfBirth, new DateTime(2000, 12, 31)));


        // Assert
        act.Validate<PropertyException>(HttpStatusCode.BadRequest, nameof(dateOfBirth), "INVALID");
    }

    [Fact]
    public void IfEquals_Different_Valid()
    {
        // Arrange
        var dateOfBirth = new DateTime(2021, 1, 1);


        // Act
        var act = Record.Exception(() => Guard.Validate.IfEquals(dateOfBirth, new DateTime(2000, 12, 31)));


        // Assert
        act.Should()
            .BeNull();
    }


    [Fact]
    public void IfEqualsNullable_Null_Valid()
    {
        // Arrange
        DateTime? dateOfBirth = null;


        // Act
        var act = Record.Exception(() => Guard.Validate.IfEquals(dateOfBirth, new DateTime(2000, 12, 31)));


        // Assert
        act.Should()
            .BeNull();
    }

    [Fact]
    public void IfEqualsNullable_BothNull_Exception()
    {
        // Arrange
        DateTime? dateOfBirth = null;


        // Act
        var act = Record.Exception(() => Guard.Validate.IfEquals(dateOfBirth, null));


        // Assert
        act.Validate<PropertyException>(HttpStatusCode.BadRequest, nameof(dateOfBirth), "INVALID");
    }

    [Fact]
    public void IfEqualsNullable_Equals_Exception()
    {
        // Arrange
        DateTime? dateOfBirth = new DateTime(2000, 12, 31);


        // Act
        var act = Record.Exception(() => Guard.Validate.IfEquals(dateOfBirth, new DateTime(2000, 12, 31)));


        // Assert
        act.Validate<PropertyException>(HttpStatusCode.BadRequest, nameof(dateOfBirth), "INVALID");
    }

    [Fact]
    public void IfEqualsNullable_Different_Valid()
    {
        // Arrange
        DateTime? dateOfBirth = new DateTime(2021, 1, 1);


        // Act
        var act = Record.Exception(() => Guard.Validate.IfEquals(dateOfBirth, new DateTime(2000, 12, 31)));


        // Assert
        act.Should()
            .BeNull();
    }


    [Fact]
    public void IfDifferent_Equals_Valid()
    {
        // Arrange
        var dateOfBirth = new DateTime(2000, 12, 31);


        // Act
        var act = Record.Exception(() => Guard.Validate.IfDifferent(dateOfBirth, new DateTime(2000, 12, 31)));


        // Assert
        act.Should()
            .BeNull();
    }

    [Fact]
    public void IfDifferent_Different_Exception()
    {
        // Arrange
        var dateOfBirth = new DateTime(2021, 1, 1);


        // Act
        var act = Record.Exception(() => Guard.Validate.IfDifferent(dateOfBirth, new DateTime(2000, 12, 31)));


        // Assert
        act.Validate<PropertyException>(HttpStatusCode.BadRequest, nameof(dateOfBirth), "INVALID");
    }


    [Fact]
    public void IfDifferentNullable_Null_Exception()
    {
        // Arrange
        DateTime? dateOfBirth = null;


        // Act
        var act = Record.Exception(() => Guard.Validate.IfDifferent(dateOfBirth, new DateTime(2000, 12, 31)));


        // Assert
        act.Validate<PropertyException>(HttpStatusCode.BadRequest, nameof(dateOfBirth), "INVALID");
    }

    [Fact]
    public void IfDifferentNullable_Equals_Valid()
    {
        // Arrange
        DateTime? dateOfBirth = new DateTime(2000, 12, 31);


        // Act
        var act = Record.Exception(() => Guard.Validate.IfDifferent(dateOfBirth, new DateTime(2000, 12, 31)));


        // Assert
        act.Should()
            .BeNull();
    }

    [Fact]
    public void IfDifferentNullable_Different_Exception()
    {
        // Arrange
        DateTime? dateOfBirth = new DateTime(2021, 1, 1);


        // Act
        var act = Record.Exception(() => Guard.Validate.IfDifferent(dateOfBirth, new DateTime(2000, 12, 31)));


        // Assert
        act.Validate<PropertyException>(HttpStatusCode.BadRequest, nameof(dateOfBirth), "INVALID");
    }

    [Fact]
    public void IfDifferentNullable_BothNull_Valid()
    {
        // Arrange
        DateTime? dateOfBirth = null;


        // Act
        var act = Record.Exception(() => Guard.Validate.IfDifferent(dateOfBirth, null));


        // Assert
        act.Should()
            .BeNull();
    }
}
