using System.Runtime.CompilerServices;
using PowerUtils.Validations.Exceptions;

namespace PowerUtils.Validations.GuardClauses
{
    public static class GuardValidationGeolocationExtensions
    {
        private const double MAX_LATITUDE = 90;
        private const double MIN_LATITUDE = MAX_LATITUDE * -1;

        private const double MAX_LONGITUDE = 180;
        private const double MIN_LONGITUDE = MAX_LONGITUDE * -1;


        /// <summary>
        /// Throws an <see cref="PropertyException" /> if <paramref name="latitude"/> is out of range. Error code 'MIN:-90' or 'MAX:90'
        /// </summary>
        /// <param name="_"></param>
        /// <param name="latitude">Value to validate</param>
        /// <param name="parameterName">If not defined, the name of the variable passed by the <paramref name="latitude"/> parameter will be used</param>
        /// <exception cref="PropertyException">Exception thrown when the latitude is out of range</exception>
        public static float IfLatitudeOutOfRange(
            this IGuardValidationClause _,
            float latitude,
            [CallerArgumentExpression("latitude")] string parameterName = null
        )
        {
            if(latitude < MIN_LATITUDE)
            {
                throw new PropertyException(parameterName, ErrorCodes.MIN_LATITUDE);
            }

            if(latitude > MAX_LATITUDE)
            {
                throw new PropertyException(parameterName, ErrorCodes.MAX_LATITUDE);
            }

            return latitude;
        }

        /// <summary>
        /// Throws an <see cref="PropertyException" /> if <paramref name="latitude"/> is out of range. Error code 'MIN:-90' or 'MAX:90'
        /// </summary>
        /// <param name="_"></param>
        /// <param name="latitude">Value to validate</param>
        /// <param name="parameterName">If not defined, the name of the variable passed by the <paramref name="latitude"/> parameter will be used</param>
        /// <exception cref="PropertyException">Exception thrown when the latitude is out of range</exception>
        public static float? IfLatitudeOutOfRange(
            this IGuardValidationClause _,
            float? latitude,
            [CallerArgumentExpression("latitude")] string parameterName = null
        )
        {
            if(latitude < MIN_LATITUDE)
            {
                throw new PropertyException(parameterName, ErrorCodes.MIN_LATITUDE);
            }

            if(latitude > MAX_LATITUDE)
            {
                throw new PropertyException(parameterName, ErrorCodes.MAX_LATITUDE);
            }

            return latitude;
        }

        /// <summary>
        /// Throws an <see cref="PropertyException" /> if <paramref name="latitude"/> is out of range. Error code 'MIN:-90' or 'MAX:90'
        /// </summary>
        /// <param name="_"></param>
        /// <param name="latitude">Value to validate</param>
        /// <param name="parameterName">If not defined, the name of the variable passed by the <paramref name="latitude"/> parameter will be used</param>
        /// <exception cref="PropertyException">Exception thrown when the latitude is out of range</exception>
        public static double IfLatitudeOutOfRange(
            this IGuardValidationClause _,
            double latitude,
            [CallerArgumentExpression("latitude")] string parameterName = null
        )
        {
            if(latitude < MIN_LATITUDE)
            {
                throw new PropertyException(parameterName, ErrorCodes.MIN_LATITUDE);
            }

            if(latitude > MAX_LATITUDE)
            {
                throw new PropertyException(parameterName, ErrorCodes.MAX_LATITUDE);
            }

            return latitude;
        }

        /// <summary>
        /// Throws an <see cref="PropertyException" /> if <paramref name="latitude"/> is out of range. Error code 'MIN:-90' or 'MAX:90'
        /// </summary>
        /// <param name="_"></param>
        /// <param name="latitude">Value to validate</param>
        /// <param name="parameterName">If not defined, the name of the variable passed by the <paramref name="latitude"/> parameter will be used</param>
        /// <exception cref="PropertyException">Exception thrown when the latitude is out of range</exception>
        public static double? IfLatitudeOutOfRange(
            this IGuardValidationClause _,
            double? latitude,
            [CallerArgumentExpression("latitude")] string parameterName = null
        )
        {
            if(latitude < MIN_LATITUDE)
            {
                throw new PropertyException(parameterName, ErrorCodes.MIN_LATITUDE);
            }

            if(latitude > MAX_LATITUDE)
            {
                throw new PropertyException(parameterName, ErrorCodes.MAX_LATITUDE);
            }

            return latitude;
        }

        /// <summary>
        /// Throws an <see cref="PropertyException" /> if <paramref name="latitude"/> is out of range. Error code 'MIN:-90' or 'MAX:90'
        /// </summary>
        /// <param name="_"></param>
        /// <param name="latitude">Value to validate</param>
        /// <param name="parameterName">If not defined, the name of the variable passed by the <paramref name="latitude"/> parameter will be used</param>
        /// <exception cref="PropertyException">Exception thrown when the latitude is out of range</exception>
        public static decimal IfLatitudeOutOfRange(
            this IGuardValidationClause _,
            decimal latitude,
            [CallerArgumentExpression("latitude")] string parameterName = null
        )
        {
            if(latitude < -90)
            {
                throw new PropertyException(parameterName, ErrorCodes.MIN_LATITUDE);
            }

            if(latitude > 90)
            {
                throw new PropertyException(parameterName, ErrorCodes.MAX_LATITUDE);
            }

            return latitude;
        }

        /// <summary>
        /// Throws an <see cref="PropertyException" /> if <paramref name="latitude"/> is out of range. Error code 'MIN:-90' or 'MAX:90'
        /// </summary>
        /// <param name="_"></param>
        /// <param name="latitude">Value to validate</param>
        /// <param name="parameterName">If not defined, the name of the variable passed by the <paramref name="latitude"/> parameter will be used</param>
        /// <exception cref="PropertyException">Exception thrown when the latitude is out of range</exception>
        public static decimal? IfLatitudeOutOfRange(
            this IGuardValidationClause _,
            decimal? latitude,
            [CallerArgumentExpression("latitude")] string parameterName = null
        )
        {
            if(latitude < -90)
            {
                throw new PropertyException(parameterName, ErrorCodes.MIN_LATITUDE);
            }

            if(latitude > 90)
            {
                throw new PropertyException(parameterName, ErrorCodes.MAX_LATITUDE);
            }

            return latitude;
        }



        /// <summary>
        /// Throws an <see cref="PropertyException" /> if <paramref name="longitude"/> is out of range. Error code 'MIN:-180' or 'MAX:180'
        /// </summary>
        /// <param name="_"></param>
        /// <param name="longitude">Value to validate</param>
        /// <param name="parameterName">If not defined, the name of the variable passed by the <paramref name="longitude"/> parameter will be used</param>
        /// <exception cref="PropertyException">Exception thrown when the longitude is out of range</exception>
        public static float IfLongitudeOutOfRange(
            this IGuardValidationClause _,
            float longitude,
            [CallerArgumentExpression("longitude")] string parameterName = null
        )
        {
            if(longitude < MIN_LONGITUDE)
            {
                throw new PropertyException(parameterName, ErrorCodes.MIN_LONGITUDE);
            }

            if(longitude > MAX_LONGITUDE)
            {
                throw new PropertyException(parameterName, ErrorCodes.MAX_LONGITUDE);
            }

            return longitude;
        }

        /// <summary>
        /// Throws an <see cref="PropertyException" /> if <paramref name="longitude"/> is out of range. Error code 'MIN:-180' or 'MAX:180'
        /// </summary>
        /// <param name="_"></param>
        /// <param name="longitude">Value to validate</param>
        /// <param name="parameterName">If not defined, the name of the variable passed by the <paramref name="longitude"/> parameter will be used</param>
        /// <exception cref="PropertyException">Exception thrown when the longitude is out of range</exception>
        public static float? IfLongitudeOutOfRange(
            this IGuardValidationClause _,
            float? longitude,
            [CallerArgumentExpression("longitude")] string parameterName = null
        )
        {
            if(longitude < MIN_LONGITUDE)
            {
                throw new PropertyException(parameterName, ErrorCodes.MIN_LONGITUDE);
            }

            if(longitude > MAX_LONGITUDE)
            {
                throw new PropertyException(parameterName, ErrorCodes.MAX_LONGITUDE);
            }

            return longitude;
        }

        /// <summary>
        /// Throws an <see cref="PropertyException" /> if <paramref name="longitude"/> is out of range. Error code 'MIN:-180' or 'MAX:180'
        /// </summary>
        /// <param name="_"></param>
        /// <param name="longitude">Value to validate</param>
        /// <param name="parameterName">If not defined, the name of the variable passed by the <paramref name="longitude"/> parameter will be used</param>
        /// <exception cref="PropertyException">Exception thrown when the longitude is out of range</exception>
        public static double IfLongitudeOutOfRange(
            this IGuardValidationClause _,
            double longitude,
            [CallerArgumentExpression("longitude")] string parameterName = null
        )
        {
            if(longitude < MIN_LONGITUDE)
            {
                throw new PropertyException(parameterName, ErrorCodes.MIN_LONGITUDE);
            }

            if(longitude > MAX_LONGITUDE)
            {
                throw new PropertyException(parameterName, ErrorCodes.MAX_LONGITUDE);
            }

            return longitude;
        }

        /// <summary>
        /// Throws an <see cref="PropertyException" /> if <paramref name="longitude"/> is out of range. Error code 'MIN:-180' or 'MAX:180'
        /// </summary>
        /// <param name="_"></param>
        /// <param name="longitude">Value to validate</param>
        /// <param name="parameterName">If not defined, the name of the variable passed by the <paramref name="longitude"/> parameter will be used</param>
        /// <exception cref="PropertyException">Exception thrown when the longitude is out of range</exception>
        public static double? IfLongitudeOutOfRange(
            this IGuardValidationClause _,
            double? longitude,
            [CallerArgumentExpression("longitude")] string parameterName = null
        )
        {
            if(longitude < MIN_LONGITUDE)
            {
                throw new PropertyException(parameterName, ErrorCodes.MIN_LONGITUDE);
            }

            if(longitude > MAX_LONGITUDE)
            {
                throw new PropertyException(parameterName, ErrorCodes.MAX_LONGITUDE);
            }

            return longitude;
        }

        /// <summary>
        /// Throws an <see cref="PropertyException" /> if <paramref name="longitude"/> is out of range. Error code 'MIN:-180' or 'MAX:180'
        /// </summary>
        /// <param name="_"></param>
        /// <param name="longitude">Value to validate</param>
        /// <param name="parameterName">If not defined, the name of the variable passed by the <paramref name="longitude"/> parameter will be used</param>
        /// <exception cref="PropertyException">Exception thrown when the longitude is out of range</exception>
        public static decimal IfLongitudeOutOfRange(
            this IGuardValidationClause _,
            decimal longitude,
            [CallerArgumentExpression("longitude")] string parameterName = null
        )
        {
            if(longitude < -180)
            {
                throw new PropertyException(parameterName, ErrorCodes.MIN_LONGITUDE);
            }

            if(longitude > 180)
            {
                throw new PropertyException(parameterName, ErrorCodes.MAX_LONGITUDE);
            }

            return longitude;
        }

        /// <summary>
        /// Throws an <see cref="PropertyException" /> if <paramref name="longitude"/> is out of range. Error code 'MIN:-180' or 'MAX:180'
        /// </summary>
        /// <param name="_"></param>
        /// <param name="longitude">Value to validate</param>
        /// <param name="parameterName">If not defined, the name of the variable passed by the <paramref name="longitude"/> parameter will be used</param>
        /// <exception cref="PropertyException">Exception thrown when the longitude is out of range</exception>
        public static decimal? IfLongitudeOutOfRange(
            this IGuardValidationClause _,
            decimal? longitude,
            [CallerArgumentExpression("longitude")] string parameterName = null
        )
        {
            if(longitude < -180)
            {
                throw new PropertyException(parameterName, ErrorCodes.MIN_LONGITUDE);
            }

            if(longitude > 180)
            {
                throw new PropertyException(parameterName, ErrorCodes.MAX_LONGITUDE);
            }

            return longitude;
        }
    }
}
