using System.Net;
using FluentAssertions;
using PowerUtils.Validations;
using PowerUtils.Validations.Exceptions;
using PowerUtils.Validations.GuardClauses;
using Xunit;

namespace PowerUtils.GuardClauses.Validations.Tests.GuardClausesTests
{
    public class GuardValidationGeolocationExtensionsTests
    {
        [Fact]
        public void SmallFloat_IfLatitudeOutOfRange_PropertyException()
        {
            // Arrange
            var degree = -90.1f;


            // Act
            var act = Record.Exception(() => Guard.Validate.IfLatitudeOutOfRange(degree));


            // Assert
            act.Validate<PropertyException>(
                HttpStatusCode.BadRequest,
                nameof(degree),
                ErrorCodes.MIN_LATITUDE
            );
        }

        [Fact]
        public void LargeFloat_IfLatitudeOutOfRange_PropertyException()
        {
            // Arrange
            var degree = 90.1f;


            // Act
            var act = Record.Exception(() => Guard.Validate.IfLatitudeOutOfRange(degree));


            // Assert
            act.Validate<PropertyException>(
                HttpStatusCode.BadRequest,
                nameof(degree),
                ErrorCodes.MAX_LATITUDE
            );
        }

        [Fact]
        public void ValidFloat_IfLatitudeOutOfRange_NotException()
        {
            // Arrange
            var degree = 18.1f;


            // Act
            var act = Guard.Validate.IfLatitudeOutOfRange(degree);


            // Assert
            act.Should()
                .Be(degree);
        }


        [Fact]
        public void SmallFloat_IfLongitudeOutOfRange_PropertyException()
        {
            // Arrange
            var degree = -180.1f;


            // Act
            var act = Record.Exception(() => Guard.Validate.IfLongitudeOutOfRange(degree));


            // Assert
            act.Validate<PropertyException>(
                HttpStatusCode.BadRequest,
                nameof(degree),
                ErrorCodes.MIN_LONGITUDE
            );
        }

        [Fact]
        public void LargeFloat_IfLongitudeOutOfRange_PropertyException()
        {
            // Arrange
            var degree = 180.1f;


            // Act
            var act = Record.Exception(() => Guard.Validate.IfLongitudeOutOfRange(degree));


            // Assert
            act.Validate<PropertyException>(
                HttpStatusCode.BadRequest,
                nameof(degree),
                ErrorCodes.MAX_LONGITUDE
            );
        }

        [Fact]
        public void ValidFloat_IfLongitudeOutOfRange_NotException()
        {
            // Arrange
            var degree = 18.1f;


            // Act
            var act = Guard.Validate.IfLongitudeOutOfRange(degree);


            // Assert
            act.Should()
                .Be(degree);
        }

        [Fact]
        public void NullFloat_IfLatitudeOutOfRange_NotException()
        {
            // Arrange
            float? degree = null;


            // Act
            var act = Record.Exception(() => Guard.Validate.IfLatitudeOutOfRange(degree));


            // Assert
            act.Should()
                .Be(degree);
        }

        [Fact]
        public void SmallFloatNullable_IfLatitudeOutOfRange_PropertyException()
        {
            // Arrange
            float? degree = -90.1f;


            // Act
            var act = Record.Exception(() => Guard.Validate.IfLatitudeOutOfRange(degree));


            // Assert
            act.Validate<PropertyException>(
                HttpStatusCode.BadRequest,
                nameof(degree),
                ErrorCodes.MIN_LATITUDE
            );
        }

        [Fact]
        public void LargeFloatNullable_IfLatitudeOutOfRange_PropertyException()
        {
            // Arrange
            float? degree = 90.1f;


            // Act
            var act = Record.Exception(() => Guard.Validate.IfLatitudeOutOfRange(degree));


            // Assert
            act.Validate<PropertyException>(
                HttpStatusCode.BadRequest,
                nameof(degree),
                ErrorCodes.MAX_LATITUDE
            );
        }

        [Fact]
        public void ValidNullableFloat_IfLatitudeOutOfRange_NotException()
        {
            // Arrange
            float? degree = 18.1f;


            // Act
            var act = Guard.Validate.IfLatitudeOutOfRange(degree);


            // Assert
            act.Should()
                .Be(degree);
        }

        [Fact]
        public void NullableNullFloat_IfLongitudeOutOfRange_NotException()
        {
            // Arrange
            float? degree = null;


            // Act
            var act = Record.Exception(() => Guard.Validate.IfLongitudeOutOfRange(degree));


            // Assert
            act.Should()
                .Be(degree);
        }

        [Fact]
        public void SmallNullable_IfLongitudeOutOfRange_PropertyException()
        {
            // Arrange
            float? degree = -180.1f;


            // Act
            var act = Record.Exception(() => Guard.Validate.IfLongitudeOutOfRange(degree));


            // Assert
            act.Validate<PropertyException>(HttpStatusCode.BadRequest, nameof(degree), ErrorCodes.MIN_LONGITUDE);
        }

        [Fact]
        public void LargeNullableFloat_IfLongitudeOutOfRange_PropertyException()
        {
            // Arrange
            float? degree = 180.1f;


            // Act
            var act = Record.Exception(() => Guard.Validate.IfLongitudeOutOfRange(degree));


            // Assert
            act.Validate<PropertyException>(HttpStatusCode.BadRequest, nameof(degree), ErrorCodes.MAX_LONGITUDE);
        }

        [Fact]
        public void ValidNullableFloat_IfLongitudeOutOfRange_NotException()
        {
            // Arrange
            float? degree = 18.1f;


            // Act
            var act = Guard.Validate.IfLongitudeOutOfRange(degree);


            // Assert
            act.Should()
                .Be(degree);
        }

        [Fact]
        public void SmallDouble_IfLatitudeOutOfRange_PropertyException()
        {
            // Arrange
            var degree = -90.1;


            // Act
            var act = Record.Exception(() => Guard.Validate.IfLatitudeOutOfRange(degree));


            // Assert
            act.Validate<PropertyException>(HttpStatusCode.BadRequest, nameof(degree), ErrorCodes.MIN_LATITUDE);
        }

        [Fact]
        public void LargeDouble_IfLatitudeOutOfRange_PropertyException()
        {
            // Arrange
            var degree = 90.1;


            // Act
            var act = Record.Exception(() => Guard.Validate.IfLatitudeOutOfRange(degree));


            // Assert
            act.Validate<PropertyException>(HttpStatusCode.BadRequest, nameof(degree), ErrorCodes.MAX_LATITUDE);
        }

        [Fact]
        public void ValidDouble_IfLatitudeOutOfRange_NotException()
        {
            // Arrange
            var degree = 18.1;


            // Act
            var act = Guard.Validate.IfLatitudeOutOfRange(degree);


            // Assert
            act.Should()
                .Be(degree);
        }


        [Fact]
        public void SmallDouble_IfLongitudeOutOfRange_PropertyException()
        {
            // Arrange
            var degree = -180.1;


            // Act
            var act = Record.Exception(() => Guard.Validate.IfLongitudeOutOfRange(degree));


            // Assert
            act.Validate<PropertyException>(HttpStatusCode.BadRequest, nameof(degree), ErrorCodes.MIN_LONGITUDE);
        }

        [Fact]
        public void LargeDouble_IfLongitudeOutOfRange_PropertyException()
        {
            // Arrange
            var degree = 180.1;


            // Act
            var act = Record.Exception(() => Guard.Validate.IfLongitudeOutOfRange(degree));


            // Assert
            act.Validate<PropertyException>(HttpStatusCode.BadRequest, nameof(degree), ErrorCodes.MAX_LONGITUDE);
        }

        [Fact]
        public void ValidDouble_IfLongitudeOutOfRange_NotException()
        {
            // Arrange
            var degree = 18.1;


            // Act
            var act = Guard.Validate.IfLongitudeOutOfRange(degree);


            // Assert
            act.Should()
                .Be(degree);
        }

        [Fact]
        public void NullDoubleNullable_IfLatitudeOutOfRange_NotException()
        {
            // Arrange
            double? degree = null;


            // Act
            var act = Record.Exception(() => Guard.Validate.IfLatitudeOutOfRange(degree));


            // Assert
            act.Should()
                .Be(degree);
        }

        [Fact]
        public void SmallDoubleNullable_IfLatitudeOutOfRange_PropertyException()
        {
            // Arrange
            double? degree = -90.1;


            // Act
            var act = Record.Exception(() => Guard.Validate.IfLatitudeOutOfRange(degree));


            // Assert
            act.Validate<PropertyException>(HttpStatusCode.BadRequest, nameof(degree), ErrorCodes.MIN_LATITUDE);
        }

        [Fact]
        public void LargeDoubleNullable_IfLatitudeOutOfRange_PropertyException()
        {
            // Arrange
            double? degree = 90.1;


            // Act
            var act = Record.Exception(() => Guard.Validate.IfLatitudeOutOfRange(degree));


            // Assert
            act.Validate<PropertyException>(HttpStatusCode.BadRequest, nameof(degree), ErrorCodes.MAX_LATITUDE);
        }

        [Fact]
        public void ValidDoubleNullable_IfLatitudeOutOfRange_NotException()
        {
            // Arrange
            double? degree = 18.1;


            // Act
            var act = Guard.Validate.IfLatitudeOutOfRange(degree);


            // Assert
            act.Should()
                .Be(degree);
        }

        [Fact]
        public void NullDoubleNullable_IfLongitudeOutOfRange_NotException()
        {
            // Arrange
            double? degree = null;


            // Act
            var act = Record.Exception(() => Guard.Validate.IfLongitudeOutOfRange(degree));


            // Assert
            act.Should()
                .Be(degree);
        }

        [Fact]
        public void SmallDoubleNullable_IfLongitudeOutOfRange_PropertyException()
        {
            // Arrange
            double? degree = -180.1;


            // Act
            var act = Record.Exception(() => Guard.Validate.IfLongitudeOutOfRange(degree));


            // Assert
            act.Validate<PropertyException>(HttpStatusCode.BadRequest, nameof(degree), ErrorCodes.MIN_LONGITUDE);
        }

        [Fact]
        public void LargeDoubleNullable_IfLongitudeOutOfRange_PropertyException()
        {
            // Arrange
            double? degree = 180.1;


            // Act
            var act = Record.Exception(() => Guard.Validate.IfLongitudeOutOfRange(degree));


            // Assert
            act.Validate<PropertyException>(HttpStatusCode.BadRequest, nameof(degree), ErrorCodes.MAX_LONGITUDE);
        }

        [Fact]
        public void ValidDoubleNullable_IfLongitudeOutOfRange_NotException()
        {
            // Arrange
            double? degree = 18.1;


            // Act
            var act = Guard.Validate.IfLongitudeOutOfRange(degree);


            // Assert
            act.Should()
                .Be(degree);
        }

        [Fact]
        public void SmallDecimal_IfLatitudeOutOfRange_PropertyException()
        {
            // Arrange
            var degree = -90.1m;


            // Act
            var act = Record.Exception(() => Guard.Validate.IfLatitudeOutOfRange(degree));


            // Assert
            act.Validate<PropertyException>(HttpStatusCode.BadRequest, nameof(degree), ErrorCodes.MIN_LATITUDE);
        }

        [Fact]
        public void LargeDecimal_IfLatitudeOutOfRange_PropertyException()
        {
            // Arrange
            var degree = 90.1m;


            // Act
            var act = Record.Exception(() => Guard.Validate.IfLatitudeOutOfRange(degree));


            // Assert
            act.Validate<PropertyException>(HttpStatusCode.BadRequest, nameof(degree), ErrorCodes.MAX_LATITUDE);
        }

        [Fact]
        public void ValidDecimal_IfLatitudeOutOfRange_NotException()
        {
            // Arrange
            var degree = 18.1m;


            // Act
            var act = Guard.Validate.IfLatitudeOutOfRange(degree);


            // Assert
            act.Should()
                .Be(degree);
        }

        [Fact]
        public void SmallDecimal_IfLongitudeOutOfRange_PropertyException()
        {
            // Arrange
            var degree = -180.1m;


            // Act
            var act = Record.Exception(() => Guard.Validate.IfLongitudeOutOfRange(degree));


            // Assert
            act.Validate<PropertyException>(HttpStatusCode.BadRequest, nameof(degree), ErrorCodes.MIN_LONGITUDE);
        }

        [Fact]
        public void LargeDecimal_PropertyException_PropertyException()
        {
            // Arrange
            var degree = 180.1m;


            // Act
            var act = Record.Exception(() => Guard.Validate.IfLongitudeOutOfRange(degree));


            // Assert
            act.Validate<PropertyException>(HttpStatusCode.BadRequest, nameof(degree), ErrorCodes.MAX_LONGITUDE);
        }

        [Fact]
        public void ValidDecimal_IfLongitudeOutOfRange_NotException()
        {
            // Arrange
            var degree = 18.1m;


            // Act
            var act = Guard.Validate.IfLongitudeOutOfRange(degree);


            // Assert
            act.Should()
                .Be(degree);
        }

        [Fact]
        public void NullDecimalNullable_IfLatitudeOutOfRange_NotException()
        {
            // Arrange
            decimal? degree = null;


            // Act
            var act = Record.Exception(() => Guard.Validate.IfLatitudeOutOfRange(degree));


            // Assert
            act.Should()
                .Be(degree);
        }

        [Fact]
        public void SmallDecimalNullable_IfLatitudeOutOfRange_PropertyException()
        {
            // Arrange
            decimal? degree = -90.1m;


            // Act
            var act = Record.Exception(() => Guard.Validate.IfLatitudeOutOfRange(degree));


            // Assert
            act.Validate<PropertyException>(HttpStatusCode.BadRequest, nameof(degree), ErrorCodes.MIN_LATITUDE);
        }

        [Fact]
        public void LargeDecimalNullable_IfLatitudeOutOfRange_PropertyException()
        {
            // Arrange
            decimal? degree = 90.1m;


            // Act
            var act = Record.Exception(() => Guard.Validate.IfLatitudeOutOfRange(degree));


            // Assert
            act.Validate<PropertyException>(HttpStatusCode.BadRequest, nameof(degree), ErrorCodes.MAX_LATITUDE);
        }

        [Fact]
        public void ValidDecimalNullable_IfLatitudeOutOfRange_NotException()
        {
            // Arrange
            decimal? degree = 18.1m;


            // Act
            var act = Guard.Validate.IfLatitudeOutOfRange(degree);


            // Assert
            act.Should()
                .Be(degree);
        }

        [Fact]
        public void NullDecimalNullable_IfLongitudeOutOfRange_NotException()
        {
            // Arrange
            decimal? degree = null;


            // Act
            var act = Record.Exception(() => Guard.Validate.IfLongitudeOutOfRange(degree));


            // Assert
            act.Should()
                .Be(degree);
        }

        [Fact]
        public void SmallDecimalNullable_IfLongitudeOutOfRange_PropertyException()
        {
            // Arrange
            decimal? degree = -180.1m;


            // Act
            var act = Record.Exception(() => Guard.Validate.IfLongitudeOutOfRange(degree));


            // Assert
            act.Validate<PropertyException>(HttpStatusCode.BadRequest, nameof(degree), ErrorCodes.MIN_LONGITUDE);
        }

        [Fact]
        public void LargeDecimalNullable_IfLongitudeOutOfRange_PropertyException()
        {
            // Arrange
            decimal? degree = 180.1m;


            // Act
            var act = Record.Exception(() => Guard.Validate.IfLongitudeOutOfRange(degree));


            // Assert
            act.Validate<PropertyException>(HttpStatusCode.BadRequest, nameof(degree), ErrorCodes.MAX_LONGITUDE);
        }

        [Fact]
        public void ValidDecimalNullable_IfLongitudeOutOfRange_NotException()
        {
            // Arrange
            decimal? degree = 18.1m;


            // Act
            var act = Guard.Validate.IfLongitudeOutOfRange(degree);


            // Assert
            act.Should()
                .Be(degree);
        }
    }
}
