using System;
using System.Runtime.CompilerServices;
using PowerUtils.Validations.Exceptions;

namespace PowerUtils.Validations.GuardClauses
{
    public static class GuardValidationDateTimeExtensions
    {
        /// <summary>
        /// Throws an <see cref="PropertyException" /> if <paramref name="value"/> is greater than. Error code 'MAX:{yyyy-MM-dd}'
        /// </summary>
        /// <param name="_"></param>
        /// <param name="value">Value to validate</param>
        /// <param name="max">Max value</param>
        /// <param name="parameterName">If not defined, the name of the variable passed by the <paramref name="value"/> parameter will be used</param>
        /// <exception cref="PropertyException">Exception thrown when the value is greater than</exception>
        public static void IfGreaterThan(
            this IGuardValidationClause _,
            DateTime value,
            DateTime max,
            [CallerArgumentExpression("value")] string parameterName = null
        )
        {
            if(value > max)
            {
                throw new PropertyException(parameterName, ErrorCodes.GetMaxFormatted(max));
            }
        }

        /// <summary>
        /// Throws an <see cref="PropertyException" /> if <paramref name="value"/> is greater than. Error code 'MAX:{yyyy-MM-dd}'
        /// </summary>
        /// <param name="_"></param>
        /// <param name="value">Value to validate</param>
        /// <param name="max">Max value</param>
        /// <param name="parameterName">If not defined, the name of the variable passed by the <paramref name="value"/> parameter will be used</param>
        /// <exception cref="PropertyException">Exception thrown when the value is greater than</exception>
        public static void IfGreaterThan(
            this IGuardValidationClause _,
            DateTime? value,
            DateTime max,
            [CallerArgumentExpression("value")] string parameterName = null
        )
        {
            if(value > max)
            {
                throw new PropertyException(parameterName, ErrorCodes.GetMaxFormatted(max));
            }
        }



        /// <summary>
        /// Throws an <see cref="PropertyException" /> if <paramref name="value"/> is less than. Error code 'MIN:{yyyy-MM-dd}'
        /// </summary>
        /// <param name="_"></param>
        /// <param name="value">Value to validate</param>
        /// <param name="min">Min value</param>
        /// <param name="parameterName">If not defined, the name of the variable passed by the <paramref name="value"/> parameter will be used</param>
        /// <exception cref="PropertyException">Exception thrown when value is less than</exception>
        public static void IfLessThan(
            this IGuardValidationClause _,
            DateTime value,
            DateTime min,
            [CallerArgumentExpression("value")] string parameterName = null
        )
        {
            if(value < min)
            {
                throw new PropertyException(parameterName, ErrorCodes.GetMinFormatted(min));
            }
        }

        /// <summary>
        /// Throws an <see cref="PropertyException" /> if <paramref name="value"/> is less than. Error code 'MIN:{yyyy-MM-dd}'
        /// </summary>
        /// <param name="_"></param>
        /// <param name="value">Value to validate</param>
        /// <param name="min">Min value</param>
        /// <param name="parameterName">If not defined, the name of the variable passed by the <paramref name="value"/> parameter will be used</param>
        /// <exception cref="PropertyException">Exception thrown when value is less than</exception>
        public static void IfLessThan(
            this IGuardValidationClause _,
            DateTime? value,
            DateTime min,
            [CallerArgumentExpression("value")] string parameterName = null
        )
        {
            if(value < min)
            {
                throw new PropertyException(parameterName, ErrorCodes.GetMinFormatted(min));
            }
        }



        /// <summary>
        /// Throws an <see cref="PropertyException" /> if <paramref name="value"/> is greater than utc now. Error code 'MAX:DATETIME_UTCNOW'
        /// </summary>
        /// <param name="_"></param>
        /// <param name="value">Value to validate</param>
        /// <param name="parameterName">If not defined, the name of the variable passed by the <paramref name="value"/> parameter will be used</param>
        /// <exception cref="PropertyException">Exception thrown when the value is greater than utc now</exception>
        public static void IfGreaterThanUtcNow(
            this IGuardValidationClause _,
            DateTime value,
            [CallerArgumentExpression("value")] string parameterName = null
        )
        {
            if(value > DateTime.UtcNow)
            {
                throw new PropertyException(parameterName, ErrorCodes.MAX_DATETIME_UTCNOW);
            }
        }

        /// <summary>
        /// Throws an <see cref="PropertyException" /> if <paramref name="value"/> is greater than utc now. Error code 'MAX:DATETIME_UTCNOW'
        /// </summary>
        /// <param name="_"></param>
        /// <param name="value">Value to validate</param>
        /// <param name="parameterName">If not defined, the name of the variable passed by the <paramref name="value"/> parameter will be used</param>
        /// <exception cref="PropertyException">Exception thrown when the value is greater than utc now</exception>
        public static void IfGreaterThanUtcNow(
            this IGuardValidationClause _,
            DateTime? value,
            [CallerArgumentExpression("value")] string parameterName = null
        )
        {
            if(value > DateTime.UtcNow)
            {
                throw new PropertyException(parameterName, ErrorCodes.MAX_DATETIME_UTCNOW);
            }
        }



        /// <summary>
        /// Throws an <see cref="PropertyException" /> if <paramref name="value"/> is less than utc now. Error code 'MIN:DATETIME_UTCNOW'
        /// </summary>
        /// <param name="_"></param>
        /// <param name="value">Value to validate</param>
        /// <param name="parameterName">If not defined, the name of the variable passed by the <paramref name="value"/> parameter will be used</param>
        /// <exception cref="PropertyException">Exception thrown when value is less than utc now</exception>
        public static void IfLessThanUtcNow(
            this IGuardValidationClause _,
            DateTime value,
            [CallerArgumentExpression("value")] string parameterName = null
        )
        {
            if(value < DateTime.UtcNow)
            {
                throw new PropertyException(parameterName, ErrorCodes.MIN_DATETIME_UTCNOW);
            }
        }

        /// <summary>
        /// Throws an <see cref="PropertyException" /> if <paramref name="value"/> is less than utc now. Error code 'MIN:DATETIME_UTCNOW'
        /// </summary>
        /// <param name="_"></param>
        /// <param name="value">Value to validate</param>
        /// <param name="parameterName">If not defined, the name of the variable passed by the <paramref name="value"/> parameter will be used</param>
        /// <exception cref="PropertyException">Exception thrown when value is less than utc now</exception>
        public static void IfLessThanUtcNow(
            this IGuardValidationClause _,
            DateTime? value,
            [CallerArgumentExpression("value")] string parameterName = null
        )
        {
            if(value < DateTime.UtcNow)
            {
                throw new PropertyException(parameterName, ErrorCodes.MIN_DATETIME_UTCNOW);
            }
        }

        /// <summary>
        /// Throws an <see cref="PropertyException" /> if <paramref name="value"/> is equals to other value. Error code 'INVALID'
        /// </summary>
        /// <param name="_"></param>
        /// <param name="value">Value to validate</param>
        /// <param name="otherValue">Reference value for comparison</param>
        /// <param name="parameterName">If not defined, the name of the variable passed by the <paramref name="value"/> parameter will be used</param>
        /// <exception cref="PropertyException">Exception thrown when value is equals to the other value</exception>
        public static void IfEquals(
            this IGuardValidationClause _,
            DateTime? value,
            DateTime? otherValue,
            [CallerArgumentExpression("value")] string parameterName = null
        )
        {
            if(value == otherValue)
            {
                throw new PropertyException(parameterName, ErrorCodes.INVALID);
            }
        }


        /// <summary>
        /// Throws an <see cref="PropertyException" /> if <paramref name="value"/> is different to other value. Error code 'INVALID'
        /// </summary>
        /// <param name="_"></param>
        /// <param name="value">Value to validate</param>
        /// <param name="otherValue">Reference value for comparison</param>
        /// <param name="parameterName">If not defined, the name of the variable passed by the <paramref name="value"/> parameter will be used</param>
        /// <exception cref="PropertyException">Exception thrown when value is different to the other value</exception>
        public static void IfDifferent(
            this IGuardValidationClause _,
            DateTime? value,
            DateTime? otherValue,
            [CallerArgumentExpression("value")] string parameterName = null
        )
        {
            if(value != otherValue)
            {
                throw new PropertyException(parameterName, ErrorCodes.INVALID);
            }
        }
    }
}
