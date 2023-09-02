using System;
using System.Runtime.CompilerServices;
using PowerUtils.Validations.Exceptions;

namespace PowerUtils.Validations.GuardClauses
{
    [Obsolete("This package has been discontinued because it never evolved, and the code present in this package does not justify its continuation. It is preferable to implement this code directly in the project if necessary. The package will be completely removed after 2024/02/03.")]
    public static class GuardValidationFloatExtensions
    {
        /// <summary>
        /// Throws an <see cref="PropertyException" /> if <paramref name="value"/> is greater than. Error code 'MAX:{X}'
        /// </summary>
        /// <param name="_"></param>
        /// <param name="value">Value to validate</param>
        /// <param name="max">Max value</param>
        /// <param name="parameterName">If not defined, the name of the variable passed by the <paramref name="value"/> parameter will be used</param>
        /// <exception cref="PropertyException">Exception thrown when the value is greater than</exception>
        public static float IfGreaterThan(
            this IGuardValidationClause _,
            float value,
            float max,
            [CallerArgumentExpression("value")] string parameterName = null
        )
        {
            if(value > max)
            {
                throw new PropertyException(parameterName, ErrorCodes.GetMaxFormatted(max));
            }

            return value;
        }

        /// <summary>
        /// Throws an <see cref="PropertyException" /> if <paramref name="value"/> is greater than. Error code 'MAX:{X}'
        /// </summary>
        /// <param name="_"></param>
        /// <param name="value">Value to validate</param>
        /// <param name="max">Max value</param>
        /// <param name="parameterName">If not defined, the name of the variable passed by the <paramref name="value"/> parameter will be used</param>
        /// <exception cref="PropertyException">Exception thrown when the value is greater than</exception>
        public static float? IfGreaterThan(
            this IGuardValidationClause _,
            float? value,
            float max,
            [CallerArgumentExpression("value")] string parameterName = null
        )
        {
            if(value > max)
            {
                throw new PropertyException(parameterName, ErrorCodes.GetMaxFormatted(max));
            }

            return value;
        }



        /// <summary>
        /// Throws an <see cref="PropertyException" /> if <paramref name="value"/> is less than. Error code 'MIN:{X}'
        /// </summary>
        /// <param name="_"></param>
        /// <param name="value">Value to validate</param>
        /// <param name="min">Min value</param>
        /// <param name="parameterName">If not defined, the name of the variable passed by the <paramref name="value"/> parameter will be used</param>
        /// <exception cref="PropertyException">Exception thrown when value is less than</exception>
        public static float IfLessThan(
            this IGuardValidationClause _,
            float value,
            float min,
            [CallerArgumentExpression("value")] string parameterName = null
        )
        {
            if(value < min)
            {
                throw new PropertyException(parameterName, ErrorCodes.GetMinFormatted(min));
            }

            return value;
        }

        /// <summary>
        /// Throws an <see cref="PropertyException" /> if <paramref name="value"/> is less than. Error code 'MIN:{X}'
        /// </summary>
        /// <param name="_"></param>
        /// <param name="value">Value to validate</param>
        /// <param name="min">Min value</param>
        /// <param name="parameterName">If not defined, the name of the variable passed by the <paramref name="value"/> parameter will be used</param>
        /// <exception cref="PropertyException">Exception thrown when value is less than</exception>
        public static float? IfLessThan(
            this IGuardValidationClause _,
            float? value,
            float min,
            [CallerArgumentExpression("value")] string parameterName = null
        )
        {
            if(value < min)
            {
                throw new PropertyException(parameterName, ErrorCodes.GetMinFormatted(min));
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
        public static float? IfEquals(
            this IGuardValidationClause _,
            float? value,
            float otherValue,
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
        public static float? IfDifferent(
            this IGuardValidationClause _,
            float? value,
            float otherValue,
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
        /// Throws an <see cref="PropertyException" /> if <paramref name="value"/> out of range. Error code 'MIN:{X}' or 'MAX:{X}'
        /// </summary>
        /// <param name="_"></param>
        /// <param name="value">Value to validate</param>
        /// <param name="min">Min value</param>
        /// <param name="max">Max value</param>
        /// <param name="parameterName">If not defined, the name of the variable passed by the <paramref name="value"/> parameter will be used</param>
        /// <exception cref="PropertyException">Exception thrown when the value is out of range</exception>
        public static float? IfOutOfRange(
            this IGuardValidationClause _,
            float? value,
            float min,
            float max,
            [CallerArgumentExpression("value")] string parameterName = null
        )
        {
            if(value < min)
            {
                throw new PropertyException(parameterName, ErrorCodes.GetMinFormatted(min));
            }

            if(value > max)
            {
                throw new PropertyException(parameterName, ErrorCodes.GetMaxFormatted(max));
            }

            return value;
        }
    }
}
