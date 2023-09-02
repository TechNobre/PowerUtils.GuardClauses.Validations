using System;
using System.Runtime.CompilerServices;
using PowerUtils.Validations.Exceptions;

namespace PowerUtils.Validations.GuardClauses
{
    [Obsolete("This package has been discontinued because it never evolved, and the code present in this package does not justify its continuation. It is preferable to implement this code directly in the project if necessary. The package will be completely removed after 2024/02/03.")]
    public static class GuardValidationObjectExtensions
    {
        /// <summary>
        /// Throws an <see cref="PropertyException" /> if <paramref name="value"/> is null with the error code 'REQUIRED'
        /// </summary>
        /// <param name="_"></param>
        /// <param name="value">Value to validate</param>
        /// <param name="parameterName">If not defined, the name of the variable passed by the <paramref name="value"/> parameter will be used</param>
        /// <exception cref="PropertyException">Exception thrown when value is null</exception>
        public static T IfNull<T>(
            this IGuardValidationClause _,
            T value,
            [CallerArgumentExpression("value")] string parameterName = null
        )
        {
            if(value == null)
            {
                throw new PropertyException(parameterName, ErrorCodes.REQUIRED);
            }

            return value;
        }
    }
}
