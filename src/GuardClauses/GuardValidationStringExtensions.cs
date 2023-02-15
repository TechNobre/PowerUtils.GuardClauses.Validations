using System;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using PowerUtils.Validations.Exceptions;

namespace PowerUtils.Validations.GuardClauses
{
    public static partial class GuardValidationStringExtensions
    {
        /// <summary>
        /// Throws an <see cref="PropertyException" /> if <paramref name="value"/> is null with the error code 'REQUIRED'
        /// </summary>
        /// <param name="_"></param>
        /// <param name="value">Value to validate</param>
        /// <param name="parameterName">If not defined, the name of the variable passed by the <paramref name="value"/> parameter will be used</param>
        /// <exception cref="PropertyException">Exception thrown when value is null</exception>
        public static string IfNull(
            this IGuardValidationClause _,
            string value,
            [CallerArgumentExpression("value")] string parameterName = null
        )
        {
            if(value == null)
            {
                throw new PropertyException(parameterName, ErrorCodes.REQUIRED);
            }

            return value;
        }

        /// <summary>
        /// Throws an <see cref="PropertyException" /> if <paramref name="value"/> is empty. Error code 'REQUIRED'
        /// </summary>
        /// <param name="_"></param>
        /// <param name="value">Value to validate</param>
        /// <param name="parameterName">If not defined, the name of the variable passed by the <paramref name="value"/> parameter will be used</param>
        /// <exception cref="PropertyException">Exception thrown when value is empty</exception>
        public static string IfEmpty(
            this IGuardValidationClause _,
            string value,
            [CallerArgumentExpression("value")] string parameterName = null
        )
        {
            if(value == null)
            {
                return value;
            }

            if(value == "")
            {
                throw new PropertyException(parameterName, ErrorCodes.REQUIRED);
            }

            return value;
        }

        /// <summary>
        /// Throws an <see cref="PropertyException" /> if <paramref name="value"/> is null or empty. Error code 'REQUIRED'
        /// </summary>
        /// <param name="_"></param>
        /// <param name="value">Value to validate</param>
        /// <param name="parameterName">If not defined, the name of the variable passed by the <paramref name="value"/> parameter will be used</param>
        /// <exception cref="PropertyException">Exception thrown when value is null or empty</exception>
        public static string IfNullOrEmpty(
            this IGuardValidationClause _,
            string value,
            [CallerArgumentExpression("value")] string parameterName = null
        )
        {
            if(string.IsNullOrEmpty(value))
            {
                throw new PropertyException(parameterName, ErrorCodes.REQUIRED);
            }

            return value;
        }

        /// <summary>
        /// Throws an <see cref="PropertyException" /> if <paramref name="value"/> is null or white space. Error code 'REQUIRED'
        /// </summary>
        /// <param name="_"></param>
        /// <param name="value">Value to validate</param>
        /// <param name="parameterName">If not defined, the name of the variable passed by the <paramref name="value"/> parameter will be used</param>
        /// <exception cref="PropertyException">Exception thrown when value is null or with space</exception>
        public static string IfNullOrWhiteSpace(
            this IGuardValidationClause _,
            string value,
            [CallerArgumentExpression("value")] string parameterName = null
        )
        {
            if(string.IsNullOrWhiteSpace(value))
            {
                throw new PropertyException(parameterName, ErrorCodes.REQUIRED);
            }

            return value;
        }

        /// <summary>
        /// Throws an <see cref="PropertyException" /> if <paramref name="value"/> is longer than. Error code 'MAX:{X}'
        /// </summary>
        /// <param name="_"></param>
        /// <param name="value">Value to validate</param>
        /// <param name="maxLength">Max length</param>
        /// <param name="parameterName">If not defined, the name of the variable passed by the <paramref name="value"/> parameter will be used</param>
        /// <exception cref="PropertyException">Exception thrown when the value is longer than</exception>
        public static string IfLongerThan(
            this IGuardValidationClause _,
            string value,
            int maxLength,
            [CallerArgumentExpression("value")] string parameterName = null
        )
        {
            if(value == null)
            {
                return value;
            }

            if(value.Length > maxLength)
            {
                throw new PropertyException(parameterName, ErrorCodes.GetMaxFormatted(maxLength));
            }

            return value;
        }

        /// <summary>
        /// Throws an <see cref="PropertyException" /> if <paramref name="value"/> is shorter than. Error code 'MIN:{X}'
        /// </summary>
        /// <param name="_"></param>
        /// <param name="value">Value to validate</param>
        /// <param name="minLength">Min length</param>
        /// <param name="parameterName">If not defined, the name of the variable passed by the <paramref name="value"/> parameter will be used</param>
        /// <exception cref="PropertyException">Exception thrown when the value is shorter than</exception>
        public static string IfShorterThan(
            this IGuardValidationClause _,
            string value,
            int minLength,
            [CallerArgumentExpression("value")] string parameterName = null
        )
        {
            if(value == null)
            {
                return value;
            }

            if(value.Length < minLength)
            {
                throw new PropertyException(parameterName, ErrorCodes.GetMinFormatted(minLength));
            }

            return value;
        }

        /// <summary>
        /// Throws an <see cref="PropertyException" /> if <paramref name="value"/> has a length equals to parameter. Error code 'INVALID'
        /// </summary>
        /// <param name="_"></param>
        /// <param name="value">Value to validate</param>
        /// <param name="length">Invalid length</param>
        /// <param name="parameterName">If not defined, the name of the variable passed by the <paramref name="value"/> parameter will be used</param>
        /// <exception cref="PropertyException">Exception thrown when the length of the value is equals to parameter</exception>
        public static string IfLengthEquals(
            this IGuardValidationClause _,
            string value,
            int length,
            [CallerArgumentExpression("value")] string parameterName = null
        )
        {
            if(value == null)
            {
                return value;
            }

            if(value.Length == length)
            {
                throw new PropertyException(parameterName, ErrorCodes.INVALID);
            }

            return value;
        }

        /// <summary>
        /// Throws an <see cref="PropertyException" /> if <paramref name="value"/> has a length different to parameter. Error code 'INVALID'
        /// </summary>
        /// <param name="_"></param>
        /// <param name="value">Value to validate</param>
        /// <param name="length">Valid length</param>
        /// <param name="parameterName">If not defined, the name of the variable passed by the <paramref name="value"/> parameter will be used</param>
        /// <exception cref="PropertyException">Exception thrown when the length of the value is different to parameter</exception>
        public static string IfLengthDifferent(
            this IGuardValidationClause _,
            string value,
            int length,
            [CallerArgumentExpression("value")] string parameterName = null
        )
        {
            if(value == null)
            {
                throw new PropertyException(parameterName, ErrorCodes.INVALID);
            }

            if(value.Length != length)
            {
                throw new PropertyException(parameterName, ErrorCodes.INVALID);
            }

            return value;
        }

#if NET7_0_OR_GREATER
        [GeneratedRegex(@"^[a-zA-Z0-9.!#$%&'*+\/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)+$", RegexOptions.Compiled)]
        private static partial Regex _emailRegex();
#else
        private static readonly Regex _emailRegex = new Regex(@"^[a-zA-Z0-9.!#$%&'*+\/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)+$", RegexOptions.Compiled, TimeSpan.FromMilliseconds(10));
#endif

        /// <summary>
        /// Throws an <see cref="PropertyException" /> if <paramref name="value"/> is not an email. Error code 'INVALID'
        /// </summary>
        /// <param name="_"></param>
        /// <param name="value">Value to validate</param>
        /// <param name="parameterName">If not defined, the name of the variable passed by the <paramref name="value"/> parameter will be used</param>
        /// <exception cref="PropertyException">Exception thrown when the value is not an email</exception>
        public static string IfNotEmail(
            this IGuardValidationClause _,
            string value,
            [CallerArgumentExpression("value")] string parameterName = null
        )
        {
            if(string.IsNullOrWhiteSpace(value))
            {
                throw new PropertyException(parameterName, ErrorCodes.INVALID);
            }
#if NET7_0_OR_GREATER
            if(!_emailRegex().IsMatch(value))
#else
            if(!_emailRegex.IsMatch(value))
#endif
            {
                throw new PropertyException(parameterName, ErrorCodes.INVALID);
            }

            return value;
        }

        /// <summary>
        /// Throws an <see cref="PropertyException" /> if <paramref name="value"/> is equals to other value. Error code 'INVALID'
        /// </summary>
        /// <param name="_"></param>
        /// <param name="value">Value to validate</param>
        /// <param name="otherValue">Reference value for comparison</param>
        /// <param name="parameterName">If not defined, the name of the variable passed by the <paramref name="value"/> parameter will be used</param>
        /// <exception cref="PropertyException">Exception thrown when value is equals to the other value</exception>
        public static string IfEquals(
            this IGuardValidationClause _,
            string value,
            string otherValue,
            [CallerArgumentExpression("value")] string parameterName = null
        )
        {
            if(value == otherValue)
            {
                throw new PropertyException(parameterName, ErrorCodes.INVALID);
            }

            return value;
        }


        /// <summary>
        /// Throws an <see cref="PropertyException" /> if <paramref name="value"/> is different to other value. Error code 'INVALID'
        /// </summary>
        /// <param name="_"></param>
        /// <param name="value">Value to validate</param>
        /// <param name="otherValue">Reference value for comparison</param>
        /// <param name="parameterName">If not defined, the name of the variable passed by the <paramref name="value"/> parameter will be used</param>
        /// <exception cref="PropertyException">Exception thrown when value is different to the other value</exception>
        public static string IfDifferent(
            this IGuardValidationClause _,
            string value,
            string otherValue,
            [CallerArgumentExpression("value")] string parameterName = null
        )
        {
            if(value != otherValue)
            {
                throw new PropertyException(parameterName, ErrorCodes.INVALID);
            }

            return value;
        }

        /// <summary>
        /// Throws an <see cref="PropertyException" /> if <paramref name="value"/> has a length out of range. Error code 'MIN:{X}' or 'MAX:{X}'
        /// </summary>
        /// <param name="_"></param>
        /// <param name="value">Value to validate</param>
        /// <param name="minLength">Min length</param>
        /// <param name="maxLength">Max length</param>
        /// <param name="parameterName">If not defined, the name of the variable passed by the <paramref name="value"/> parameter will be used</param>
        /// <exception cref="PropertyException">Exception thrown when the length of the value is out of range</exception>
        public static string IfLengthOutOfRange(
            this IGuardValidationClause _,
            string value,
            int minLength,
            int maxLength,
            [CallerArgumentExpression("value")] string parameterName = null
        )
        {
            if(value == null)
            {
                return value;
            }

            if(value.Length < minLength)
            {
                throw new PropertyException(parameterName, ErrorCodes.GetMinFormatted(minLength));
            }

            if(value.Length > maxLength)
            {
                throw new PropertyException(parameterName, ErrorCodes.GetMaxFormatted(maxLength));
            }

            return value;
        }
    }
}
