using System;
using System.Net;
using PowerUtils.Net.Constants;
using PowerUtils.Validations.Exceptions;

namespace PowerUtils.GuardClauses.Validations.Tests;

public static class ExceptionValidation
{
    public static void Validate(this BaseValidationException exception, HttpStatusCode statusCode)
        => exception.Validate(statusCode, $"An error occurred with the status code '{statusCode}'");

    public static void Validate(this BaseValidationException exception, HttpStatusCode statusCode, string message)
    {
        exception.StatusCode.Should()
            .Be(statusCode);
        exception.HelpLink.Should()
            .Be(((int)statusCode).GetStatusCodeLink());

        exception.Message.Should()
            .Be(message);
        exception.InnerException.Should()
            .BeNull();
    }

    public static void Validate<TInnerException>(this BaseValidationException exception, HttpStatusCode statusCode, string message)
    {
        exception.StatusCode.Should()
            .Be(statusCode);
        exception.HelpLink.Should()
            .Be(((int)statusCode).GetStatusCodeLink());

        exception.Message.Should()
            .Be(message);
        exception.InnerException.Should()
            .BeOfType<TInnerException>();
    }

    public static void Validate(this BaseValidationException exception, HttpStatusCode statusCode, string property, string errorCode)
        => exception.Validate(statusCode, property, errorCode, $"An error occurred with the status code '{statusCode}'");

    public static void Validate(this BaseValidationException exception, HttpStatusCode statusCode, string property, string errorCode, string message)
    {
        exception.StatusCode.Should()
            .Be(statusCode);
        exception.HelpLink.Should()
            .Be(((int)statusCode).GetStatusCodeLink());

        exception.Message.Should()
            .Be(message);

        exception.InnerException.Should()
            .BeNull();

        exception.Errors.Should()
            .ContainKey(property);
        exception.Errors.Should()
            .ContainValue(errorCode);
    }

    public static void Validate<TException>(this Exception exception, HttpStatusCode statusCode, string property, string errorCode)
        where TException : BaseValidationException
        => exception.Validate<TException>(statusCode, property, errorCode, $"An error occurred with the status code 'BadRequest'");

    public static void Validate<TException>(this Exception exception, HttpStatusCode statusCode, string property, string errorCode, string message)
        where TException : BaseValidationException
    {
        exception.Should()
            .BeOfType<TException>();

        var propertyException = exception as TException;

        propertyException.StatusCode.Should()
            .Be(statusCode);
        propertyException.HelpLink.Should()
            .Be(((int)statusCode).GetStatusCodeLink());

        propertyException.Message.Should()
            .Be(message);

        propertyException.InnerException.Should()
            .BeNull();

        propertyException.Errors.Should()
            .ContainKey(property);
        propertyException.Errors.Should()
            .ContainValue(errorCode);
    }
}
