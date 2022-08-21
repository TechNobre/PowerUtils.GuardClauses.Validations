using System.Net;
using FluentAssertions;
using PowerUtils.Validations.Exceptions;
using PowerUtils.Validations.GuardClauses;
using Xunit;

namespace PowerUtils.GuardClauses.Validations.Tests.GuardClausesTests
{
    public class GuardValidationFloatExtensionsTests
    {
        [Fact]
        public void LargeNumber_IfGreaterThan_PropertyException()
        {
            // Arrange
            var quantity = 241f;


            // Act
            var act = Record.Exception(() => Guard.Validate.IfGreaterThan(quantity, 5f));


            // Assert
            act.Validate<PropertyException>(
                HttpStatusCode.BadRequest,
                nameof(quantity),
                "MAX:5"
            );
        }

        [Fact]
        public void NotLargeNumber_IfGreaterThan_Valid()
        {
            // Arrange
            var quantity = 4f;


            // Act
            var act = Guard.Validate.IfGreaterThan(quantity, 5f);


            // Assert
            act.Should()
                .Be(quantity);
        }

        [Fact]
        public void Null_IfGreaterThanNullable_Valid()
        {
            // Arrange
            float? quantity = null;


            // Act
            var act = Record.Exception(() => Guard.Validate.IfGreaterThan(quantity, 5f));


            // Assert
            act.Should()
                .Be(quantity);
        }

        [Fact]
        public void LargeNumber_IfGreaterThanNullable_PropertyException()
        {
            // Arrange
            float? quantity = 241;


            // Act
            var act = Record.Exception(() => Guard.Validate.IfGreaterThan(quantity, 5f));


            // Assert
            act.Validate<PropertyException>(
                HttpStatusCode.BadRequest,
                nameof(quantity),
                "MAX:5"
            );
        }

        [Fact]
        public void NotLargeNumber_IfGreaterThanNullable_Valid()
        {
            // Arrange
            float? quantity = 4;


            // Act
            var act = Guard.Validate.IfGreaterThan(quantity, 5f);


            // Assert
            act.Should()
                .Be(quantity);
        }

        [Fact]
        public void SmallNumber_IfLessThan_PropertyException()
        {
            // Arrange
            var quantity = 4f;


            // Act
            var act = Record.Exception(() => Guard.Validate.IfLessThan(quantity, 5f));


            // Assert
            act.Validate<PropertyException>(
                HttpStatusCode.BadRequest,
                nameof(quantity),
                "MIN:5"
            );
        }

        [Fact]
        public void NotSmallNumber_IfLessThan_Valid()
        {
            // Arrange
            var quantity = 14f;


            // Act
            var act = Guard.Validate.IfLessThan(quantity, 5f);


            // Assert
            act.Should()
                .Be(quantity);
        }

        [Fact]
        public void Null_IfLessThanNullable_Valid()
        {
            // Arrange
            float? quantity = null;


            // Act
            var act = Record.Exception(() => Guard.Validate.IfLessThan(quantity, 5f));


            // Assert
            act.Should()
                .Be(quantity);
        }

        [Fact]
        public void SmallNumber_IfLessThanNullable_PropertyException()
        {
            // Arrange
            float? quantity = 2;


            // Act
            var act = Record.Exception(() => Guard.Validate.IfLessThan(quantity, 5f));


            // Assert
            act.Validate<PropertyException>(
                HttpStatusCode.BadRequest,
                nameof(quantity),
                "MIN:5"
            );
        }

        [Fact]
        public void NotSmallNumber_IfLessThanNullable_Valid()
        {
            // Arrange
            float? quantity = 45;


            // Act
            var act = Guard.Validate.IfLessThan(quantity, 5f);


            // Assert
            act.Should()
                .Be(quantity);
        }


        [Fact]
        public void Equals_IfEquals_PropertyException()
        {
            // Arrange
            float quantity = 5;


            // Act
            var act = Record.Exception(() => Guard.Validate.IfEquals(quantity, 5));


            // Assert
            act.Validate<PropertyException>(
                HttpStatusCode.BadRequest,
                nameof(quantity),
                "INVALID"
            );
        }

        [Fact]
        public void Different_IfEquals_Valid()
        {
            // Arrange
            float quantity = 5;


            // Act
            var act = Guard.Validate.IfEquals(quantity, 6);


            // Assert
            act.Should()
                .Be(quantity);
        }

        [Fact]
        public void Null_IfEqualsNullable_Valid()
        {
            // Arrange
            float? quantity = null;


            // Act
            var act = Record.Exception(() => Guard.Validate.IfEquals(quantity, 5));


            // Assert
            act.Should()
                .Be(quantity);
        }

        [Fact]
        public void Equals_IfEqualsNullable_PropertyException()
        {
            // Arrange
            float? quantity = 4;


            // Act
            var act = Record.Exception(() => Guard.Validate.IfEquals(quantity, 4));


            // Assert
            act.Validate<PropertyException>(
                HttpStatusCode.BadRequest,
                nameof(quantity),
                "INVALID"
            );
        }

        [Fact]
        public void Different_IfEqualsNullable_Valid()
        {
            // Arrange
            float? quantity = 5;


            // Act
            var act = Guard.Validate.IfEquals(quantity, 4);


            // Assert
            act.Should()
                .Be(quantity);
        }

        [Fact]
        public void Equals_IfDifferent_Valid()
        {
            // Arrange
            float quantity = 22;


            // Act
            var act = Guard.Validate.IfDifferent(quantity, 22);


            // Assert
            act.Should()
                .Be(quantity);
        }

        [Fact]
        public void Different_IfDifferent_PropertyException()
        {
            // Arrange
            float quantity = 51;


            // Act
            var act = Record.Exception(() => Guard.Validate.IfDifferent(quantity, 12));


            // Assert
            act.Validate<PropertyException>(
                HttpStatusCode.BadRequest,
                nameof(quantity),
                "INVALID"
            );
        }


        [Fact]
        public void Null_IfDifferentNullable_PropertyException()
        {
            // Arrange
            float? quantity = null;


            // Act
            var act = Record.Exception(() => Guard.Validate.IfDifferent(quantity, 74));


            // Assert
            act.Validate<PropertyException>(
                HttpStatusCode.BadRequest,
                nameof(quantity),
                "INVALID"
            );
        }

        [Fact]
        public void Equals_IfDifferentNullable_Valid()
        {
            // Arrange
            float? quantity = 78;


            // Act
            var act = Guard.Validate.IfDifferent(quantity, 78);


            // Assert
            act.Should()
                .Be(quantity);
        }

        [Fact]
        public void Different_IfDifferentNullable_PropertyException()
        {
            // Arrange
            float? quantity = 45;


            // Act
            var act = Record.Exception(() => Guard.Validate.IfDifferent(quantity, 321));


            // Assert
            act.Validate<PropertyException>(
                HttpStatusCode.BadRequest,
                nameof(quantity),
                "INVALID"
            );
        }

        [Fact]
        public void InRange_IfOutOfRange_Valid()
        {
            // Arrange
            var quantity = 45.45741f;


            // Act
            var act = Guard.Validate.IfOutOfRange(quantity, 10, 50);


            // Assert
            act.Should()
                .Be(quantity);
        }

        [Fact]
        public void SmallNumber_IfOutOfRange_PropertyException()
        {
            // Arrange
            var quantity = 5.45741f;


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
        public void BigNumber_IfOutOfRange_PropertyException()
        {
            // Arrange
            var quantity = 55.45741f;


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
        public void NULL_IfOutOfRangeNullable_Valid()
        {
            // Arrange
            float? quantity = null;


            // Act
            var act = Guard.Validate.IfOutOfRange(quantity, 10, 50);


            // Assert
            act.Should()
                .Be(quantity);
        }

        [Fact]
        public void InRange_IfOutOfRangeNullable_Valid()
        {
            // Arrange
            float? quantity = 45.45741f;


            // Act
            var act = Guard.Validate.IfOutOfRange(quantity, 10, 50);


            // Assert
            act.Should()
                .Be(quantity);
        }

        [Fact]
        public void SmallNumber_IfOutOfRangeNullable_PropertyException()
        {
            // Arrange
            float? quantity = 5.45741f;


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
        public void BigNumber_IfOutOfRangeNullable_PropertyException()
        {
            // Arrange
            float? quantity = 55.45741f;


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
}
