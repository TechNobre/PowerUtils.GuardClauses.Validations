using System.Runtime.CompilerServices;
using PowerUtils.Text;
using PowerUtils.Validations.Exceptions;

namespace PowerUtils.Validations.GuardClauses
{
    public static class GuardValidationStringExtensions
    {
        /// <summary>
        /// Throws an <see cref="PropertyException" /> if <paramref name="value"/> is null with the error code 'REQUIRED'
        /// </summary>
        /// <param name="_"></param>
        /// <param name="value">Value to validate</param>
        /// <param name="parameterName">If not defined, the name of the variable passed by the <paramref name="value"/> parameter will be used</param>
        /// <exception cref="PropertyException">Exception thrown when value is null</exception>
        public static void IfNull(
            this IGuardClause _,
            string value,
            [CallerArgumentExpression("value")] string parameterName = null
        )
        {
            if(value == null)
            {
                throw new PropertyException(parameterName, ErrorCodes.REQUIRED);
            }
        }

        /// <summary>
        /// Throws an <see cref="PropertyException" /> if <paramref name="value"/> is empty. Error code 'REQUIRED'
        /// </summary>
        /// <param name="_"></param>
        /// <param name="value">Value to validate</param>
        /// <param name="parameterName">If not defined, the name of the variable passed by the <paramref name="value"/> parameter will be used</param>
        /// <exception cref="PropertyException">Exception thrown when value is empty</exception>
        public static void IfEmpty(
            this IGuardClause _,
            string value,
            [CallerArgumentExpression("value")] string parameterName = null
        )
        {
            if(value == null)
            {
                return;
            }

            if(value == "")
            {
                throw new PropertyException(parameterName, ErrorCodes.REQUIRED);
            }
        }

        /// <summary>
        /// Throws an <see cref="PropertyException" /> if <paramref name="value"/> is null or empty. Error code 'REQUIRED'
        /// </summary>
        /// <param name="_"></param>
        /// <param name="value">Value to validate</param>
        /// <param name="parameterName">If not defined, the name of the variable passed by the <paramref name="value"/> parameter will be used</param>
        /// <exception cref="PropertyException">Exception thrown when value is null or empty</exception>
        public static void IfNullOrEmpty(
            this IGuardClause _,
            string value,
            [CallerArgumentExpression("value")] string parameterName = null
        )
        {
            if(string.IsNullOrEmpty(value))
            {
                throw new PropertyException(parameterName, ErrorCodes.REQUIRED);
            }
        }

        /// <summary>
        /// Throws an <see cref="PropertyException" /> if <paramref name="value"/> is null or white space. Error code 'REQUIRED'
        /// </summary>
        /// <param name="_"></param>
        /// <param name="value">Value to validate</param>
        /// <param name="parameterName">If not defined, the name of the variable passed by the <paramref name="value"/> parameter will be used</param>
        /// <exception cref="PropertyException">Exception thrown when value is null or with space</exception>
        public static void IfNullOrWhiteSpace(
            this IGuardClause _,
            string value,
            [CallerArgumentExpression("value")] string parameterName = null
        )
        {
            if(string.IsNullOrWhiteSpace(value))
            {
                throw new PropertyException(parameterName, ErrorCodes.REQUIRED);
            }
        }

        /// <summary>
        /// Throws an <see cref="PropertyException" /> if <paramref name="value"/> has a length greater than. Error code 'MAX:{X}'
        /// </summary>
        /// <param name="_"></param>
        /// <param name="value">Value to validate</param>
        /// <param name="maxLength">Max length</param>
        /// <param name="parameterName">If not defined, the name of the variable passed by the <paramref name="value"/> parameter will be used</param>
        /// <exception cref="PropertyException">Exception thrown when the length of the value is greater than</exception>
        public static void IfLengthGreaterThan(
            this IGuardClause _,
            string value,
            int maxLength,
            [CallerArgumentExpression("value")] string parameterName = null
        )
        {
            if(value == null)
            {
                return;
            }

            if(value.Length > maxLength)
            {
                throw new PropertyException(parameterName, ErrorCodes.GetMaxFormatted(maxLength));
            }
        }

        /// <summary>
        /// Throws an <see cref="PropertyException" /> if <paramref name="value"/> has a length less than. Error code 'MIN:{X}'
        /// </summary>
        /// <param name="_"></param>
        /// <param name="value">Value to validate</param>
        /// <param name="minLength">Max length</param>
        /// <param name="parameterName">If not defined, the name of the variable passed by the <paramref name="value"/> parameter will be used</param>
        /// <exception cref="PropertyException">Exception thrown when the length of the value is less than</exception>
        public static void IfLengthLessThan(
            this IGuardClause _,
            string value,
            int minLength,
            [CallerArgumentExpression("value")] string parameterName = null
        )
        {
            if(value == null)
            {
                return;
            }

            if(value.Length < minLength)
            {
                throw new PropertyException(parameterName, ErrorCodes.GetMinFormatted(minLength));
            }
        }

        /// <summary>
        /// Throws an <see cref="PropertyException" /> if <paramref name="value"/> has a length equals zero. Error code 'MIN:0'
        /// </summary>
        /// <param name="_"></param>
        /// <param name="value">Value to validate</param>
        /// <param name="parameterName">If not defined, the name of the variable passed by the <paramref name="value"/> parameter will be used</param>
        /// <exception cref="PropertyException">Exception thrown when the length of the value is zero</exception>
        [System.Obsolete("This method is deprecated. It will be removed on 2022/09/30. Use the new method 'string.IfEmpty'")]
        public static void IfLengthZero(
            this IGuardClause _,
            string value,
            [CallerArgumentExpression("value")] string parameterName = null
        )
        {
            if(value == null)
            {
                return;
            }

            if(value.Length == 0)
            {
                throw new PropertyException(parameterName, ErrorCodes.GetMinFormatted(0));
            }
        }

        /// <summary>
        /// Throws an <see cref="PropertyException" /> if <paramref name="value"/> has a length equals to parameter. Error code 'INVALID'
        /// </summary>
        /// <param name="_"></param>
        /// <param name="value">Value to validate</param>
        /// <param name="length">Invalid length</param>
        /// <param name="parameterName">If not defined, the name of the variable passed by the <paramref name="value"/> parameter will be used</param>
        /// <exception cref="PropertyException">Exception thrown when the length of the value is equals to parameter</exception>
        public static void IfLengthEquals(
            this IGuardClause _,
            string value,
            int length,
            [CallerArgumentExpression("value")] string parameterName = null
        )
        {
            if(value == null)
            {
                return;
            }

            if(value.Length == length)
            {
                throw new PropertyException(parameterName, ErrorCodes.INVALID);
            }
        }

        /// <summary>
        /// Throws an <see cref="PropertyException" /> if <paramref name="value"/> has a length difference to parameter. Error code 'INVALID'
        /// </summary>
        /// <param name="_"></param>
        /// <param name="value">Value to validate</param>
        /// <param name="length">Valid length</param>
        /// <param name="parameterName">If not defined, the name of the variable passed by the <paramref name="value"/> parameter will be used</param>
        /// <exception cref="PropertyException">Exception thrown when the length of the value is difference to parameter</exception>
        [System.Obsolete("This method is deprecated. It will be removed on 2022/09/30. Use the new method 'string.IfLengthDifferent'")]
        public static void IfLengthDifference(
            this IGuardClause _,
            string value,
            int length,
            [CallerArgumentExpression("value")] string parameterName = null
        ) => Guard.Validate.IfLengthDifferent(value, length, parameterName);

        /// <summary>
        /// Throws an <see cref="PropertyException" /> if <paramref name="value"/> has a length different to parameter. Error code 'INVALID'
        /// </summary>
        /// <param name="_"></param>
        /// <param name="value">Value to validate</param>
        /// <param name="length">Valid length</param>
        /// <param name="parameterName">If not defined, the name of the variable passed by the <paramref name="value"/> parameter will be used</param>
        /// <exception cref="PropertyException">Exception thrown when the length of the value is different to parameter</exception>
        public static void IfLengthDifferent(
            this IGuardClause _,
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
        }

        /// <summary>
        /// Throws an <see cref="PropertyException" /> if <paramref name="value"/> is not an email. Error code 'INVALID'
        /// </summary>
        /// <param name="_"></param>
        /// <param name="value">Value to validate</param>
        /// <param name="parameterName">If not defined, the name of the variable passed by the <paramref name="value"/> parameter will be used</param>
        /// <exception cref="PropertyException">Exception thrown when the value is not an email</exception>
        public static void NotEmail(
            this IGuardClause _,
            string value,
            [CallerArgumentExpression("value")] string parameterName = null
        )
        {
            if(!value.IsEmail())
            {
                throw new PropertyException(parameterName, ErrorCodes.INVALID);
            }
        }
    }
}
