namespace PowerUtils.Validations.GuardClauses
{
    public interface IGuardClause { }

    public class Guard : IGuardClause
    {
        public static IGuardClause Validate { get; } = new Guard();

        private Guard() { }
    }
}
