﻿using System.Net;
using PowerUtils.Validations;
using PowerUtils.Validations.Exceptions;
using PowerUtils.Validations.GuardClauses;

namespace PowerUtils.GuardClauses.Validations.Tests.GuardClausesTests.Strings;

[Trait("Type", "Guards")]
public class GuardValidationEmailExtensionsTests
{
    [Fact]
    public void IfNotEmail_Null_Exception()
    {
        // Arrange
        string clientEmail = null;


        // Act
        var act = Record.Exception(() => Guard.Validate.IfNotEmail(clientEmail));


        // Assert
        act.Validate<PropertyException>(HttpStatusCode.BadRequest, nameof(clientEmail), "INVALID");
    }

    [Fact]
    public void IfNotEmail_Empty_Exception()
    {
        // Arrange
        var clientEmail = "";


        // Act
        var act = Record.Exception(() => Guard.Validate.IfNotEmail(clientEmail));


        // Assert
        act.Validate<PropertyException>(HttpStatusCode.BadRequest, nameof(clientEmail), "INVALID");
    }

    [Fact]
    public void IfNotEmail_WithSpace_Exception()
    {
        // Arrange
        var clientEmail = "    ";


        // Act
        var act = Record.Exception(() => Guard.Validate.IfNotEmail(clientEmail));


        // Assert
        act.Validate<PropertyException>(
            HttpStatusCode.BadRequest,
            nameof(clientEmail),
            "INVALID"
        );
    }

    [Fact]
    public void IfNotEmail_FakeText_Exception()
    {
        // Arrange
        var clientEmail = "fake";


        // Act
        var act = Record.Exception(() => Guard.Validate.IfNotEmail(clientEmail));


        // Assert
        act.Validate<PropertyException>(
            HttpStatusCode.BadRequest,
            nameof(clientEmail),
            "INVALID"
        );
    }

    [Fact]
    public void IfNotEmail_Email_Valid()
    {
        // Arrange
        var clientEmail = "fake@fake.tk";


        // Act
        var act = Guard.Validate.IfNotEmail(clientEmail);


        // Assert
        act.Should()
            .Be(clientEmail);
    }







    [Theory]
    [InlineData("fake@fake.com")]
    [InlineData("fake@fake.com.co")]
    [InlineData("nelson.nobre@fake.com")]
    [InlineData("nelson.nobre-@fake.com")]
    [InlineData("nelson.nobre@fake.com.br")]
    [InlineData("nelson.nobre@fake.c0")]
    [InlineData("nelson@fake.xn--6frz82g")]
    [InlineData("nelson@fake.pt6")]
    [InlineData("nelson@fake.6pt")]
    public void IfNotEmail_Validate(string email)
    {
        // Arrange & Act
        var act = Guard.Validate.IfNotEmail(email);


        // Assert
        act.Should()
            .Be(email);
    }


    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData("fake@fake..com")]
    [InlineData("fake@.com")]
    [InlineData("@fake.com")]
    [InlineData("nelson")]
    [InlineData("nelson.nobre")]
    [InlineData("nelson.nobre@")]
    [InlineData("nelson.nobre@.com")]
    [InlineData("nelson.nobre@..com")]
    [InlineData("nelson.nobre@fake..com")]
    [InlineData("nelson.nobre@@fake.com")]
    [InlineData("n,nobre@@fake.com")]
    [InlineData("nelson.nobre@fake.")]
    [InlineData("nelson.nobre@fake.com.")]
    [InlineData("´nelson@fake.com")]
    [InlineData("nelson@fake")]
    public void IfNotEmail_Invalidate(string email)
    {
        // Arrange & Act
        var act = Record.Exception(() => Guard.Validate.IfNotEmail(email));


        // Assert
        act.Validate<PropertyException>(
            HttpStatusCode.BadRequest,
            nameof(email),
            "INVALID"
        );
    }
}
