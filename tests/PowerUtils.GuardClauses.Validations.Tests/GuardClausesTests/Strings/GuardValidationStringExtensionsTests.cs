using System.Net;
using FluentAssertions;
using PowerUtils.Validations;
using PowerUtils.Validations.Exceptions;
using PowerUtils.Validations.GuardClauses;
using Xunit;

namespace PowerUtils.GuardClauses.Validations.Tests.GuardClausesTests.Strings
{
    public class GuardValidationStringExtensionsTests
    {
        [Fact]
        public void Null_IfNull_PropertyException()
        {
            // Arrange
            string client = null;


            // Act
            var act = Record.Exception(() => Guard.Validate.IfNull(client));


            // Assert
            act.Validate<PropertyException>(HttpStatusCode.BadRequest, nameof(client), ErrorCodes.REQUIRED);
        }

        [Fact]
        public void Empty_IfNull_Valid()
        {
            // Arrange
            var client = "";


            // Act
            var act = Guard.Validate.IfNull(client);


            // Assert
            act.Should()
                .Be(client);
        }

        [Fact]
        public void DirectValue_IfNull_Exception()
        {
            // Act
            var act = Record.Exception(() => Guard.Validate.IfNull(null));


            // Assert
            act.Validate<PropertyException>(HttpStatusCode.BadRequest, "null", ErrorCodes.REQUIRED);
        }

        [Fact]
        public void ParameterName_IfNull_PropertyExceptionWithParameterName()
        {
            // Act
            var act = Record.Exception(() => Guard.Validate.IfNull(null, "Product"));


            // Assert
            act.Validate<PropertyException>(HttpStatusCode.BadRequest, "Product", ErrorCodes.REQUIRED);
        }

        [Fact]
        public void NewNameParameterName_IfNullOrEmpty_NewParameterName()
        {
            // Arrange
            var client = "";

            // Act
            var act = Record.Exception(() => Guard.Validate.IfNullOrEmpty(client, "Product"));


            // Assert
            act.Validate<PropertyException>(HttpStatusCode.BadRequest, "Product", ErrorCodes.REQUIRED);
        }

        [Fact]
        public void Null_IfEmpty_Valid()
        {
            // Arrange
            string client = null;


            // Act
            var act = Record.Exception(() => Guard.Validate.IfEmpty(client));


            // Assert
            act.Should()
                .Be(client);
        }

        [Fact]
        public void Empty_IfEmpty_PropertyException()
        {
            // Arrange
            var client = "";


            // Act
            var act = Record.Exception(() => Guard.Validate.IfEmpty(client));


            // Assert
            act.Validate<PropertyException>(HttpStatusCode.BadRequest, nameof(client), ErrorCodes.REQUIRED);
        }



        [Fact]
        public void Withspaces_IfEmpty_Valid()
        {
            // Arrange
            var client = "    ";


            // Act
            var act = Guard.Validate.IfEmpty(client);


            // Assert
            act.Should()
                .Be(client);
        }



        [Fact]
        public void Word_IfEmpty_Valid()
        {
            // Arrange
            var client = "fake";


            // Act
            var act = Guard.Validate.IfEmpty(client);


            // Assert
            act.Should()
                .Be(client);
        }

        [Fact]
        public void Null_IfNullOrEmpty_PropertyException()
        {
            // Arrange
            string client = null;


            // Act
            var act = Record.Exception(() => Guard.Validate.IfNullOrEmpty(client));


            // Assert
            act.Validate<PropertyException>(HttpStatusCode.BadRequest, nameof(client), ErrorCodes.REQUIRED);
        }

        [Fact]
        public void Empty_IfNullOrEmpty_PropertyException()
        {
            // Arrange
            var client = "";


            // Act
            var act = Record.Exception(() => Guard.Validate.IfNullOrEmpty(client));


            // Assert
            act.Validate<PropertyException>(HttpStatusCode.BadRequest, nameof(client), ErrorCodes.REQUIRED);
        }

        [Fact]
        public void Value_IfNullOrEmpty_Valid()
        {
            // Arrange
            var client = "fake";


            // Act
            var act = Guard.Validate.IfNullOrEmpty(client);


            // Assert
            act.Should()
                .Be(client);
        }




        [Fact]
        public void Null_IfNullOrWhiteSpace_PropertyException()
        {
            // Arrange
            string client = null;


            // Act
            var act = Record.Exception(() => Guard.Validate.IfNullOrEmpty(client));


            // Assert
            act.Validate<PropertyException>(HttpStatusCode.BadRequest, nameof(client), ErrorCodes.REQUIRED);
        }

        [Fact]
        public void Empty_IfNullOrWhiteSpace_PropertyException()
        {
            // Arrange
            var client = "";


            // Act
            var act = Record.Exception(() => Guard.Validate.IfNullOrWhiteSpace(client));


            // Assert
            act.Validate<PropertyException>(HttpStatusCode.BadRequest, nameof(client), ErrorCodes.REQUIRED);
        }

        [Fact]
        public void WithSpace_IfNullOrWhiteSpace_PropertyException()
        {
            // Arrange
            var client = "      ";


            // Act
            var act = Record.Exception(() => Guard.Validate.IfNullOrWhiteSpace(client));


            // Assert
            act.Validate<PropertyException>(HttpStatusCode.BadRequest, nameof(client), ErrorCodes.REQUIRED);
        }

        [Fact]
        public void Value_IfNullOrWhiteSpace_Valid()
        {
            // Arrange
            var client = "fake";


            // Act
            var act = Guard.Validate.IfNullOrWhiteSpace(client);


            // Assert
            act.Should()
                .Be(client);
        }


        [Fact]
        public void Null_IfLengthZero_Valid()
        {
            // Arrange
            string client = null;


            // Act
#pragma warning disable CS0618 // Type or member is obsolete
            var act = Record.Exception(() => Guard.Validate.IfLengthZero(client));
#pragma warning restore CS0618 // Type or member is obsolete


            // Assert
            act.Should()
                .Be(client);
        }

        [Fact]
        public void ZeroLength_IfLengthZero_PropertyException()
        {
            // Arrange
            var client = "";


            // Act
#pragma warning disable CS0618 // Type or member is obsolete
            var act = Record.Exception(() => Guard.Validate.IfLengthZero(client));
#pragma warning restore CS0618 // Type or member is obsolete


            // Assert
            act.Validate<PropertyException>(HttpStatusCode.BadRequest, nameof(client), "MIN:0");
        }

        [Fact]
        public void WithSpace_IfLengthZero_Valid()
        {
            // Arrange
            var client = "Fake";


            // Act
#pragma warning disable CS0618 // Type or member is obsolete
            var act = Guard.Validate.IfLengthZero(client);
#pragma warning restore CS0618 // Type or member is obsolete


            // Assert
            act.Should()
                .Be(client);
        }

        [Fact]
        public void Null_NotEmail_PropertyException()
        {
            // Arrange
            string clientEmail = null;


            // Act
#pragma warning disable CS0618 // Type or member is obsolete
            var act = Record.Exception(() => Guard.Validate.NotEmail(clientEmail));
#pragma warning restore CS0618 // Type or member is obsolete


            // Assert
            act.Validate<PropertyException>(HttpStatusCode.BadRequest, nameof(clientEmail), "INVALID");
        }

        [Fact]
        public void Empty_NotEmail_PropertyException()
        {
            // Arrange
            var clientEmail = "";


            // Act
#pragma warning disable CS0618 // Type or member is obsolete
            var act = Record.Exception(() => Guard.Validate.NotEmail(clientEmail));
#pragma warning restore CS0618 // Type or member is obsolete


            // Assert
            act.Validate<PropertyException>(HttpStatusCode.BadRequest, nameof(clientEmail), "INVALID");
        }

        [Fact]
        public void WithSpace_NotEmail_PropertyException()
        {
            // Arrange
            var clientEmail = "    ";


            // Act
#pragma warning disable CS0618 // Type or member is obsolete
            var act = Record.Exception(() => Guard.Validate.NotEmail(clientEmail));
#pragma warning restore CS0618 // Type or member is obsolete


            // Assert
            act.Validate<PropertyException>(HttpStatusCode.BadRequest, nameof(clientEmail), "INVALID");
        }

        [Fact]
        public void FakeText_NotEmail_PropertyException()
        {
            // Arrange
            var clientEmail = "fake";


            // Act
#pragma warning disable CS0618 // Type or member is obsolete
            var act = Record.Exception(() => Guard.Validate.NotEmail(clientEmail));
#pragma warning restore CS0618 // Type or member is obsolete


            // Assert
            act.Validate<PropertyException>(HttpStatusCode.BadRequest, nameof(clientEmail), "INVALID");
        }

        [Fact]
        public void Email_NotEmail_Valid()
        {
            // Arrange
            var clientEmail = "fake@fake.tk";


            // Act
#pragma warning disable CS0618 // Type or member is obsolete
            var act = Guard.Validate.NotEmail(clientEmail);
#pragma warning restore CS0618 // Type or member is obsolete


            // Assert
            act.Should()
                .Be(clientEmail);
        }

        [Fact]
        public void Null_IfLengthEquals_Valid()
        {
            // Arrange
            string client = null;


            // Act
            var act = Record.Exception(() => Guard.Validate.IfLengthEquals(client, 5));


            // Assert
            act.Should()
                .Be(client);
        }

        [Fact]
        public void Empty_IfLengthEquals_Valid()
        {
            // Arrange
            var client = "";


            // Act
            var act = Guard.Validate.IfLengthEquals(client, 5);


            // Assert
            act.Should()
                .Be(client);
        }

        [Fact]
        public void FourLength_IfLengthEquals_Valid()
        {
            // Arrange
            var client = "fake";


            // Act
            var act = Guard.Validate.IfLengthEquals(client, 5);


            // Assert
            act.Should()
                .Be(client);
        }

        [Fact]
        public void SixLength_IfLengthEquals_Valid()
        {
            // Arrange
            var client = "fake";


            // Act
            var act = Guard.Validate.IfLengthEquals(client, 6);


            // Assert
            act.Should()
                .Be(client);
        }

        [Fact]
        public void FiveLength_IfLengthEquals_PropertyException()
        {
            // Arrange
            var client = "fakes";


            // Act
            var act = Record.Exception(() => Guard.Validate.IfLengthEquals(client, 5));


            // Assert
            act.Validate<PropertyException>(HttpStatusCode.BadRequest, nameof(client), "INVALID");
        }

        [Fact]
        public void Null_IfLengthDifferent_PropertyException()
        {
            // Arrange
            string client = null;


            // Act
            var act = Record.Exception(() => Guard.Validate.IfLengthDifferent(client, 5));


            // Assert
            act.Validate<PropertyException>(HttpStatusCode.BadRequest, nameof(client), "INVALID");
        }

        [Fact]
        public void Empty_IfLengthDifferent_PropertyException()
        {
            // Arrange
            var client = "";


            // Act
            var act = Record.Exception(() => Guard.Validate.IfLengthDifferent(client, 5));


            // Assert
            act.Validate<PropertyException>(HttpStatusCode.BadRequest, nameof(client), "INVALID");
        }

        [Fact]
        public void FiveLength_IfLengthDifferent_PropertyException()
        {
            // Arrange
            var client = "fake";


            // Act
            var act = Record.Exception(() => Guard.Validate.IfLengthDifferent(client, 5));


            // Assert
            act.Validate<PropertyException>(HttpStatusCode.BadRequest, nameof(client), "INVALID");
        }

        [Fact]
        public void SixLength_IfLengthDifferent_PropertyException()
        {
            // Arrange
            var client = "fake";


            // Act
            var act = Record.Exception(() => Guard.Validate.IfLengthDifferent(client, 6));


            // Assert
            act.Validate<PropertyException>(HttpStatusCode.BadRequest, nameof(client), "INVALID");
        }

        [Fact]
        public void FiveLength_IfLengthDifferent_Valid()
        {
            // Arrange
            var client = "fakes";


            // Act
            var act = Guard.Validate.IfLengthDifferent(client, 5);


            // Assert
            act.Should()
                .Be(client);
        }

        [Fact]
        public void Null_IfLongerThan_Valid()
        {
            // Arrange
            string client = null;


            // Act
            var act = Record.Exception(() => Guard.Validate.IfLongerThan(client, 1));


            // Assert
            act.Should()
                .Be(client);
        }

        [Fact]
        public void BigText_IfLongerThan_PropertyException()
        {
            // Arrange
            var client = "Fake fake fake";


            // Act
            var act = Record.Exception(() => Guard.Validate.IfLongerThan(client, 5));


            // Assert
            act.Validate<PropertyException>(HttpStatusCode.BadRequest, nameof(client), "MAX:5");
        }

        [Fact]
        public void ShortText_IfLongerThan_Valid()
        {
            // Arrange
            var client = "Fake";


            // Act
            var act = Guard.Validate.IfLongerThan(client, 5);


            // Assert
            act.Should()
                .Be(client);
        }

        [Fact]
        public void Null_IfShorterThan_Valid()
        {
            // Arrange
            string client = null;


            // Act
            var act = Record.Exception(() => Guard.Validate.IfShorterThan(client, 1));


            // Assert
            act.Should()
                .Be(client);
        }

        [Fact]
        public void BigText_IfShorterThan_Valid()
        {
            // Arrange
            var client = "Fake fake fake";


            // Act
            var act = Guard.Validate.IfShorterThan(client, 5);


            // Assert
            act.Should()
                .Be(client);
        }

        [Fact]
        public void ShortText_IfShorterThan_PropertyException()
        {
            // Arrange
            var client = "Fake";


            // Act
            var act = Record.Exception(() => Guard.Validate.IfShorterThan(client, 5));


            // Assert
            act.Validate<PropertyException>(HttpStatusCode.BadRequest, nameof(client), "MIN:5");
        }


        [Fact]
        public void Equals_IfEquals_PropertyException()
        {
            // Arrange
            var client = "Fake";


            // Act
            var act = Record.Exception(() => Guard.Validate.IfEquals(client, "Fake"));


            // Assert
            act.Validate<PropertyException>(HttpStatusCode.BadRequest, nameof(client), "INVALID");
        }

        [Fact]
        public void DifferentText_IfEquals_Valid()
        {
            // Arrange
            var client = "Fake";


            // Act
            var act = Guard.Validate.IfEquals(client, "fake fake");


            // Assert
            act.Should()
                .Be(client);
        }


        [Fact]
        public void Null_IfEquals_Valid()
        {
            // Arrange
            string client = null;


            // Act
            var act = Record.Exception(() => Guard.Validate.IfEquals(client, "fake fake"));


            // Assert
            act.Should()
                .Be(client);
        }


        [Fact]
        public void EqualsText_IfDifferent_Valid()
        {
            // Arrange
            var client = "fake";


            // Act
            var act = Guard.Validate.IfDifferent(client, "fake");


            // Assert
            act.Should()
                .Be(client);
        }

        [Fact]
        public void DifferentText_IfDifferent_PropertyException()
        {
            // Arrange
            var client = "fake";


            // Act
            var act = Record.Exception(() => Guard.Validate.IfDifferent(client, "fake fake"));


            // Assert
            act.Validate<PropertyException>(HttpStatusCode.BadRequest, nameof(client), "INVALID");
        }


        [Fact]
        public void Null_IfDifferent_PropertyException()
        {
            // Arrange
            string client = null;


            // Act
            var act = Record.Exception(() => Guard.Validate.IfDifferent(client, "fake"));


            // Assert
            act.Validate<PropertyException>(HttpStatusCode.BadRequest, nameof(client), "INVALID");
        }



        [Fact]
        public void Null_IfLengthOutOfRange_Valid()
        {
            // Arrange
            string name = null;


            // Act
            var act = Record.Exception(() => Guard.Validate.IfLengthOutOfRange(name, 4, 7));


            // Assert
            act.Should()
                .Be(name);
        }

        [Fact]
        public void Short_IfLengthOutOfRange_PropertyException()
        {
            // Arrange
            var name = "ola";


            // Act
            var act = Record.Exception(() => Guard.Validate.IfLengthOutOfRange(name, 4, 7));


            // Assert
            act.Validate<PropertyException>(
                HttpStatusCode.BadRequest,
                nameof(name),
                ErrorCodes.GetMinFormatted(4)
            );
        }

        [Fact]
        public void Longer_IfLengthOutOfRange_PropertyException()
        {
            // Arrange
            var name = "Vel ut gubergren est ut sed blandit ipsum";


            // Act
            var act = Record.Exception(() => Guard.Validate.IfLengthOutOfRange(name, 4, 7));


            // Assert
            act.Validate<PropertyException>(
                HttpStatusCode.BadRequest,
                nameof(name),
                ErrorCodes.GetMaxFormatted(7)
            );
        }

        [Fact]
        public void ValidText_IfLengthOutOfRange_SameValue()
        {
            // Arrange
            var name = "Power";


            // Act
            var act = Guard.Validate.IfLengthOutOfRange(name, 4, 7);


            // Assert
            act.Should()
                .Be(name);
        }
    }
}
