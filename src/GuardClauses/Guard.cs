namespace PowerUtils.Validations.GuardClauses
{
    public interface IGuardValidationClause { }

    public class Guard : IGuardValidationClause
    {
        public static IGuardValidationClause Validate { get; } = new Guard();

        private Guard() { }
    }
}
