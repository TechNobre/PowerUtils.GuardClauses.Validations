using System;
using System.Runtime.CompilerServices;
using PowerUtils.Validations.Exceptions;

namespace PowerUtils.Validations.GuardClauses
{
    public static class GuardValidationGuidExtensions
    {
        /// <summary>
        /// Throws an <see cref="PropertyException" /> if <paramref name="value"/> is empty. Error code 'REQUIRED'
        /// </summary>
        /// <param name="_"></param>
        /// <param name="value">Value to validate</param>
        /// <param name="parameterName">If not defined, the name of the variable passed by the <paramref name="value"/> parameter will be used</param>
        /// <exception cref="PropertyException">Exception thrown when value is empty</exception>
        public static Guid IfEmpty(
            this IGuardValidationClause _,
            Guid value,
            [CallerArgumentExpression("value")] string parameterName = null
        )
        {
            if(value == Guid.Empty)
            {
                throw new PropertyException(parameterName, ErrorCodes.REQUIRED);
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
        public static Guid? IfEquals(
            this IGuardValidationClause _,
            Guid? value,
            Guid? otherValue,
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
        public static Guid? IfDifferent(
            this IGuardValidationClause _,
            Guid? value,
            Guid? otherValue,
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
