using System.Runtime.CompilerServices;
using PowerUtils.Validations.Exceptions;
using System.Collections;

namespace PowerUtils.Validations.GuardClauses
{
    public static class GuardValidationCollectionExtensions
    {
        /// <summary>
        /// Throws an <see cref="PropertyException" /> if <paramref name="value"/> is empty. Error code 'REQUIRED'
        /// </summary>
        /// <param name="_"></param>
        /// <param name="value">Value to validate</param>
        /// <param name="parameterName">If not defined, the name of the variable passed by the <paramref name="value"/> parameter will be used</param>
        /// <exception cref="PropertyException">Exception thrown when the collection is empty</exception>
        public static void IfEmpty(
            this IGuardValidationClause _,
            IEnumerable value,
            [CallerArgumentExpression("value")] string parameterName = null
        )
        {
            if(value == null)
            {
                return;
            }

            if(value._itemCounter() == 0)
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
        /// <exception cref="PropertyException">Exception thrown when the collection is null or empty</exception>
        public static void IfNullOrEmpty(
            this IGuardValidationClause _,
            IEnumerable value,
            [CallerArgumentExpression("value")] string parameterName = null
        )
        {
            if(value == null)
            {
                throw new PropertyException(parameterName, ErrorCodes.REQUIRED);
            }

            if(value._itemCounter() == 0)
            {
                throw new PropertyException(parameterName, ErrorCodes.REQUIRED);
            }
        }


        /// <summary>
        /// Throws an <see cref="PropertyException" /> if <paramref name="value"/> the number of items in the collection is greater than. Error code 'MAX:{X}'
        /// </summary>
        /// <param name="_"></param>
        /// <param name="value">Value to validate</param>
        /// <param name="max">Maximum number of items in the collection</param>
        /// <param name="parameterName">If not defined, the name of the variable passed by the <paramref name="value"/> parameter will be used</param>
        /// <exception cref="PropertyException">Exception thrown when the number of items in the collection is greater than</exception>
        public static void IfCountGreaterThan(
            this IGuardValidationClause _,
            IEnumerable value,
            int max,
            [CallerArgumentExpression("value")] string parameterName = null
        )
        {
            if(value == null)
            {
                return;
            }

            if(value._itemCounter() > max)
            {
                throw new PropertyException(parameterName, ErrorCodes.GetMaxFormatted(max));
            }
        }

        /// <summary>
        /// Throws an <see cref="PropertyException" /> if <paramref name="value"/> the number of items in the collection is less than. Error code 'MIN:{X}'
        /// </summary>
        /// <param name="_"></param>
        /// <param name="value">Value to validate</param>
        /// <param name="min">Minimum of items in the list</param>
        /// <param name="parameterName">If not defined, the name of the variable passed by the <paramref name="value"/> parameter will be used</param>
        /// <exception cref="PropertyException">Exception thrown when the number of items in the collection is less than</exception>
        public static void IfCountLessThan(
            this IGuardValidationClause _,
            IEnumerable value,
            int min,
            [CallerArgumentExpression("value")] string parameterName = null
        )
        {
            if(value == null)
            {
                throw new PropertyException(parameterName, ErrorCodes.GetMinFormatted(min));
            }

            if(value._itemCounter() < min)
            {
                throw new PropertyException(parameterName, ErrorCodes.GetMinFormatted(min));
            }
        }

        private static int _itemCounter(this IEnumerable value)
        {
            if(value is ICollection collection)
            {
                return collection.Count;
            }

            return value._enumerableCounter();
        }

        private static int _enumerableCounter(this IEnumerable enumerable)
        {
            var count = 0;
            var enumerator = enumerable.GetEnumerator();
            while(enumerator.MoveNext())
            {
                count++;
            }

            return count;
        }
    }
}
