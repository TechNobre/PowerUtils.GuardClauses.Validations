using System.Runtime.CompilerServices;
using PowerUtils.Validations.Exceptions;

namespace PowerUtils.Validations.GuardClauses
{
    public static class GuardValidationULongExtensions
    {
        /// <summary>
        /// Throws an <see cref="PropertyException" /> if <paramref name="value"/> is greater than. Error code 'MAX:{X}'
        /// </summary>
        /// <param name="_"></param>
        /// <param name="value">Value to validate</param>
        /// <param name="max">Max value</param>
        /// <param name="parameterName">If not defined, the name of the variable passed by the <paramref name="value"/> parameter will be used</param>
        /// <exception cref="PropertyException">Exception thrown when the value is greater than</exception>
        public static ulong IfGreaterThan(
            this IGuardValidationClause _,
            ulong value,
            ulong max,
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
        public static ulong? IfGreaterThan(
            this IGuardValidationClause _,
            ulong? value,
            ulong max,
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
        public static ulong IfLessThan(
            this IGuardValidationClause _,
            ulong value,
            ulong min,
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
        public static ulong? IfLessThan(
            this IGuardValidationClause _,
            ulong? value,
            ulong min,
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
        public static ulong? IfEquals(
            this IGuardValidationClause _,
            ulong? value,
            ulong otherValue,
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
        public static ulong? IfDifferent(
            this IGuardValidationClause _,
            ulong? value,
            ulong otherValue,
            [CallerArgumentExpression("value")] string parameterName = null
        )
        {
            if(value != otherValue)
            {
                throw new PropertyException(parameterName, ErrorCodes.INVALID);
            }

            return value;
        }
    }
}
