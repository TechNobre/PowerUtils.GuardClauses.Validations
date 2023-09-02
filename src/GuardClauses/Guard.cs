using System;

namespace PowerUtils.Validations.GuardClauses
{
    [Obsolete("This package has been discontinued because it never evolved, and the code present in this package does not justify its continuation. It is preferable to implement this code directly in the project if necessary. The package will be completely removed after 2024/02/03.")]
    public interface IGuardValidationClause { }

    [Obsolete("This package has been discontinued because it never evolved, and the code present in this package does not justify its continuation. It is preferable to implement this code directly in the project if necessary. The package will be completely removed after 2024/02/03.")]
    public class Guard : IGuardValidationClause
    {
        public static IGuardValidationClause Validate { get; } = new Guard();

        private Guard() { }
    }
}
