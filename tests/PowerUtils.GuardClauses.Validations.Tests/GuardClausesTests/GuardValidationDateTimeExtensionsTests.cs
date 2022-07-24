using System;
using System.Net;
using PowerUtils.Validations.Exceptions;
using PowerUtils.Validations.GuardClauses;

namespace PowerUtils.GuardClauses.Validations.Tests.GuardClausesTests;

public class GuardValidationDateTimeExtensionsTests
{
    [Fact]
    public void FutureDate_IfGreaterThan_PropertyException()
    {
        // Arrange
        var dateOfBirth = new DateTime(2012, 12, 12);


        // Act
        var act = Record.Exception(() => Guard.Validate.IfGreaterThan(dateOfBirth, new DateTime(2000, 12, 31)));


        // Assert
        act.Validate<PropertyException>(
            HttpStatusCode.BadRequest,
            nameof(dateOfBirth),
            "MAX:2000-12-31");
    }

    [Fact]
    public void PastDate_IfGreaterThan_Valid()
    {
        // Arrange
        var dateOfBirth = new DateTime(1980, 12, 12);


        // Act
        var act = Guard.Validate.IfGreaterThan(dateOfBirth, new DateTime(2000, 12, 31));


        // Assert
        act.Should()
            .Be(dateOfBirth);
    }



    [Fact]
    public void Null_IfGreaterThanNullable_Valid()
    {
        // Arrange
        DateTime? dateOfBirth = null;


        // Act
        var act = Record.Exception(() => Guard.Validate.IfGreaterThan(dateOfBirth, new DateTime(2000, 12, 31)));


        // Assert
        act.Should()
            .BeEquivalentTo(dateOfBirth);
    }


    [Fact]
    public void FutureDate_IfGreaterThanNullable_PropertyException()
    {
        // Arrange
        DateTime? dateOfBirth = new DateTime(2012, 12, 12);


        // Act
        var act = Record.Exception(() => Guard.Validate.IfGreaterThan(dateOfBirth, new DateTime(2000, 12, 31)));


        // Assert
        act.Validate<PropertyException>(
            HttpStatusCode.BadRequest,
            nameof(dateOfBirth),
            "MAX:2000-12-31"
        );
    }

    [Fact]
    public void PastDate_IfGreaterThanNullable_Valid()
    {
        // Arrange
        DateTime? dateOfBirth = new DateTime(1980, 12, 12);


        // Act
        var act = Guard.Validate.IfGreaterThan(dateOfBirth, new DateTime(2000, 12, 31));


        // Assert
        act.Should()
            .Be(dateOfBirth);
    }



    [Fact]
    public void PastDate_IfLessThan_PropertyException()
    {
        // Arrange
        var dateOfBirth = new DateTime(1980, 12, 12);


        // Act
        var act = Record.Exception(() => Guard.Validate.IfLessThan(dateOfBirth, new DateTime(2000, 12, 31)));


        // Assert
        act.Validate<PropertyException>(
            HttpStatusCode.BadRequest,
            nameof(dateOfBirth),
            "MIN:2000-12-31"
        );
    }

    [Fact]
    public void FutureDate_IfLessThan_Valid()
    {
        // Arrange
        var dateOfBirth = new DateTime(2012, 12, 12);


        // Act
        var act = Guard.Validate.IfLessThan(dateOfBirth, new DateTime(2000, 12, 31));


        // Assert
        act.Should()
            .Be(dateOfBirth);
    }

    [Fact]
    public void Null_IfLessThanNullable_Valid()
    {
        // Arrange
        DateTime? dateOfBirth = null;


        // Act
        var act = Record.Exception(() => Guard.Validate.IfLessThan(dateOfBirth, new DateTime(2000, 12, 31)));


        // Assert
        act.Should()
            .BeEquivalentTo(dateOfBirth);
    }


    [Fact]
    public void PastDate_IfLessThanNullable_PropertyException()
    {
        // Arrange
        DateTime? dateOfBirth = new DateTime(1980, 12, 12);


        // Act
        var act = Record.Exception(() => Guard.Validate.IfLessThan(dateOfBirth, new DateTime(2000, 12, 31)));


        // Assert
        act.Validate<PropertyException>(
            HttpStatusCode.BadRequest,
            nameof(dateOfBirth),
            "MIN:2000-12-31"
        );
    }

    [Fact]
    public void FutureDate_IfLessThanNullable_Valid()
    {
        // Arrange
        DateTime? dateOfBirth = new DateTime(2012, 12, 12);


        // Act
        var act = Guard.Validate.IfLessThan(dateOfBirth, new DateTime(2000, 12, 31));


        // Assert
        act.Should()
            .Be(dateOfBirth);
    }

    [Fact]
    public void FutureDate_IfGreaterThanUtcNow_PropertyException()
    {
        // Arrange
        var dateOfBirth = DateTime.UtcNow.AddDays(9);


        // Act
        var act = Record.Exception(() => Guard.Validate.IfGreaterThanUtcNow(dateOfBirth));


        // Assert
        act.Validate<PropertyException>(
            HttpStatusCode.BadRequest,
            nameof(dateOfBirth),
            "MAX:DATETIME_UTCNOW"
        );
    }

    [Fact]
    public void PastDate_IfGreaterThanUtcNow_Valid()
    {
        // Arrange
        var dateOfBirth = DateTime.UtcNow.AddDays(-9);


        // Act
        var act = Guard.Validate.IfGreaterThanUtcNow(dateOfBirth);


        // Assert
        act.Should()
            .Be(dateOfBirth);
    }

    [Fact]
    public void Null_IfGreaterThanUtcNowNullable_Valid()
    {
        // Arrange
        DateTime? dateOfBirth = null;


        // Act
        var act = Record.Exception(() => Guard.Validate.IfGreaterThanUtcNow(dateOfBirth));


        // Assert
        act.Should()
            .BeEquivalentTo(dateOfBirth);
    }


    [Fact]
    public void FutureDate_IfGreaterThanUtcNowNullable_PropertyException()
    {
        // Arrange
        DateTime? dateOfBirth = DateTime.UtcNow.AddDays(9);


        // Act
        var act = Record.Exception(() => Guard.Validate.IfGreaterThanUtcNow(dateOfBirth));


        // Assert
        act.Validate<PropertyException>(
            HttpStatusCode.BadRequest,
            nameof(dateOfBirth),
            "MAX:DATETIME_UTCNOW"
        );
    }

    [Fact]
    public void PastDate_IfGreaterThanUtcNowNullable_Valid()
    {
        // Arrange
        DateTime? dateOfBirth = DateTime.UtcNow.AddDays(-9);


        // Act
        var act = Guard.Validate.IfGreaterThanUtcNow(dateOfBirth);


        // Assert
        act.Should()
            .Be(dateOfBirth);
    }



    [Fact]
    public void PastDate_IfLessThanUtcNow_PropertyException()
    {
        // Arrange
        var dateOfBirth = DateTime.UtcNow.AddDays(-9);


        // Act
        var act = Record.Exception(() => Guard.Validate.IfLessThanUtcNow(dateOfBirth));


        // Assert
        act.Validate<PropertyException>(
            HttpStatusCode.BadRequest,
            nameof(dateOfBirth),
            "MIN:DATETIME_UTCNOW"
        );
    }

    [Fact]
    public void FutureDate_IfLessThanUtcNow_Valid()
    {
        // Arrange
        var dateOfBirth = DateTime.UtcNow.AddDays(9);


        // Act
        var act = Guard.Validate.IfLessThanUtcNow(dateOfBirth);


        // Assert
        act.Should()
            .Be(dateOfBirth);
    }

    [Fact]
    public void Null_IfLessThanUtcNowNullable_Valid()
    {
        // Arrange
        DateTime? dateOfBirth = null;


        // Act
        var act = Guard.Validate.IfLessThanUtcNow(dateOfBirth);


        // Assert
        act.Should()
            .Be(dateOfBirth);
    }


    [Fact]
    public void PastDate_IfLessThanUtcNowNullable_PropertyException()
    {
        // Arrange
        DateTime? dateOfBirth = DateTime.UtcNow.AddDays(-9);


        // Act
        var act = Record.Exception(() => Guard.Validate.IfLessThanUtcNow(dateOfBirth));


        // Assert
        act.Validate<PropertyException>(HttpStatusCode.BadRequest, nameof(dateOfBirth), "MIN:DATETIME_UTCNOW");
    }

    [Fact]
    public void FutureDate_IfLessThanUtcNowNullable_Valid()
    {
        // Arrange
        DateTime? dateOfBirth = DateTime.UtcNow.AddDays(9);


        // Act
        var act = Guard.Validate.IfLessThanUtcNow(dateOfBirth);


        // Assert
        act.Should()
            .Be(dateOfBirth);
    }

    [Fact]
    public void EqualsDateTime_IfEquals_PropertyException()
    {
        // Arrange
        var dateOfBirth = new DateTime(2000, 12, 31);


        // Act
        var act = Record.Exception(() => Guard.Validate.IfEquals(dateOfBirth, new DateTime(2000, 12, 31)));


        // Assert
        act.Validate<PropertyException>(
            HttpStatusCode.BadRequest,
            nameof(dateOfBirth),
            "INVALID"
        );
    }

    [Fact]
    public void DifferentDateTime_IfEquals_Valid()
    {
        // Arrange
        var dateOfBirth = new DateTime(2021, 1, 1);


        // Act
        var act = Guard.Validate.IfEquals(dateOfBirth, new DateTime(2000, 12, 31));


        // Assert
        act.Should()
            .Be(dateOfBirth);
    }


    [Fact]
    public void Null_IfEqualsNullable_Valid()
    {
        // Arrange
        DateTime? dateOfBirth = null;


        // Act
        var act = Guard.Validate.IfEquals(dateOfBirth, new DateTime(2000, 12, 31));


        // Assert
        act.Should()
            .Be(dateOfBirth);
    }

    [Fact]
    public void BothNull_IfEqualsNullable_PropertyException()
    {
        // Arrange
        DateTime? dateOfBirth = null;


        // Act
        var act = Record.Exception(() => Guard.Validate.IfEquals(dateOfBirth, null));


        // Assert
        act.Validate<PropertyException>(
            HttpStatusCode.BadRequest,
            nameof(dateOfBirth),
            "INVALID"
        );
    }

    [Fact]
    public void EqualsDateTime_IfEqualsNullable_PropertyException()
    {
        // Arrange
        DateTime? dateOfBirth = new DateTime(2000, 12, 31);


        // Act
        var act = Record.Exception(() => Guard.Validate.IfEquals(dateOfBirth, new DateTime(2000, 12, 31)));


        // Assert
        act.Validate<PropertyException>(
            HttpStatusCode.BadRequest,
            nameof(dateOfBirth),
            "INVALID"
        );
    }

    [Fact]
    public void DifferentDateTime_IfEqualsNullable_Valid()
    {
        // Arrange
        DateTime? dateOfBirth = new DateTime(2021, 1, 1);


        // Act
        var act = Guard.Validate.IfEquals(dateOfBirth, new DateTime(2000, 12, 31));


        // Assert
        act.Should()
            .Be(dateOfBirth);
    }


    [Fact]
    public void EqualsDateTime_IfDifferent_Valid()
    {
        // Arrange
        var dateOfBirth = new DateTime(2000, 12, 31);


        // Act
        var act = Guard.Validate.IfDifferent(dateOfBirth, new DateTime(2000, 12, 31));


        // Assert
        act.Should()
            .Be(dateOfBirth);
    }

    [Fact]
    public void DifferentDateTime_IfDifferent_PropertyException()
    {
        // Arrange
        var dateOfBirth = new DateTime(2021, 1, 1);


        // Act
        var act = Record.Exception(() => Guard.Validate.IfDifferent(dateOfBirth, new DateTime(2000, 12, 31)));


        // Assert
        act.Validate<PropertyException>(
            HttpStatusCode.BadRequest,
            nameof(dateOfBirth),
            "INVALID"
        );
    }

    [Fact]
    public void Null_IfDifferentNullable_PropertyException()
    {
        // Arrange
        DateTime? dateOfBirth = null;


        // Act
        var act = Record.Exception(() => Guard.Validate.IfDifferent(dateOfBirth, new DateTime(2000, 12, 31)));


        // Assert
        act.Validate<PropertyException>(
            HttpStatusCode.BadRequest,
            nameof(dateOfBirth),
            "INVALID"
        );
    }

    [Fact]
    public void EqualsDateTime_IfDifferentNullable_Valid()
    {
        // Arrange
        DateTime? dateOfBirth = new DateTime(2000, 12, 31);


        // Act
        var act = Guard.Validate.IfDifferent(dateOfBirth, new DateTime(2000, 12, 31));


        // Assert
        act.Should()
            .Be(dateOfBirth);
    }

    [Fact]
    public void DifferentDateTime_IfDifferentNullable_PropertyException()
    {
        // Arrange
        DateTime? dateOfBirth = new DateTime(2021, 1, 1);


        // Act
        var act = Record.Exception(() => Guard.Validate.IfDifferent(dateOfBirth, new DateTime(2000, 12, 31)));


        // Assert
        act.Validate<PropertyException>(
            HttpStatusCode.BadRequest,
            nameof(dateOfBirth),
            "INVALID"
        );
    }

    [Fact]
    public void BothNull_IfDifferentNullable_Valid()
    {
        // Arrange
        DateTime? dateOfBirth = null;


        // Act
        var act = Guard.Validate.IfDifferent(dateOfBirth, null);


        // Assert
        act.Should()
            .Be(dateOfBirth);
    }

    [Fact]
    public void InRange_IfOutOfRange_Valid()
    {
        // Arrange
        var dateOfBirth = new DateTime(2021, 1, 1);


        // Act
        var act = Guard.Validate.IfOutOfRange(dateOfBirth, new DateTime(2000, 12, 31), new DateTime(2021, 1, 2));


        // Assert
        act.Should()
            .Be(dateOfBirth);
    }

    [Fact]
    public void Past_IfOutOfRange_PropertyException()
    {
        // Arrange
        var dateOfBirth = new DateTime(1999, 1, 1);


        // Act
        var act = Record.Exception(() => Guard.Validate.IfOutOfRange(dateOfBirth, new DateTime(2000, 12, 31), new DateTime(2021, 1, 2)));


        // Assert
        act.Validate<PropertyException>(
            HttpStatusCode.BadRequest,
            nameof(dateOfBirth),
            "MIN:2000-12-31"
        );
    }

    [Fact]
    public void Future_IfOutOfRange_PropertyException()
    {
        // Arrange
        var dateOfBirth = new DateTime(2022, 1, 1);


        // Act
        var act = Record.Exception(() => Guard.Validate.IfOutOfRange(dateOfBirth, new DateTime(2000, 12, 31), new DateTime(2021, 1, 2)));


        // Assert
        act.Validate<PropertyException>(
            HttpStatusCode.BadRequest,
            nameof(dateOfBirth),
            "MAX:2021-01-02"
        );
    }

    [Fact]
    public void NULL_IfOutOfRangeNullable_Valid()
    {
        // Arrange
        DateTime? dateOfBirth = null;


        // Act
        var act = Guard.Validate.IfOutOfRange(dateOfBirth, new DateTime(2000, 12, 31), new DateTime(2021, 1, 2));


        // Assert
        act.Should()
            .Be(dateOfBirth);
    }

    [Fact]
    public void InRange_IfOutOfRangeNullable_Valid()
    {
        // Arrange
        DateTime? dateOfBirth = new DateTime(2021, 1, 1);


        // Act
        var act = Guard.Validate.IfOutOfRange(dateOfBirth, new DateTime(2000, 12, 31), new DateTime(2021, 1, 2));


        // Assert
        act.Should()
            .Be(dateOfBirth);
    }

    [Fact]
    public void Past_IfOutOfRangeNullable_PropertyException()
    {
        // Arrange
        DateTime? dateOfBirth = new DateTime(1999, 1, 1);


        // Act
        var act = Record.Exception(() => Guard.Validate.IfOutOfRange(dateOfBirth, new DateTime(2000, 12, 31), new DateTime(2021, 1, 2)));


        // Assert
        act.Validate<PropertyException>(
            HttpStatusCode.BadRequest,
            nameof(dateOfBirth),
            "MIN:2000-12-31"
        );
    }

    [Fact]
    public void Future_IfOutOfRangeNullable_PropertyException()
    {
        // Arrange
        DateTime? dateOfBirth = new DateTime(2022, 1, 1);


        // Act
        var act = Record.Exception(() => Guard.Validate.IfOutOfRange(dateOfBirth, new DateTime(2000, 12, 31), new DateTime(2021, 1, 2)));


        // Assert
        act.Validate<PropertyException>(
            HttpStatusCode.BadRequest,
            nameof(dateOfBirth),
            "MAX:2021-01-02"
        );
    }
}
