
namespace SimulinkModelGenerator.Rules
{
    internal interface IRule<TValue>
    {
        /// <summary>
        /// Defines if the rule is statisfied by the provided <paramref name="value"/> parameter.
        /// </summary>
        /// <returns><see cref="RuleResult"/></returns>
        RuleResult IsStatisfied(TValue value);
    }

    internal class RuleResult
    {
        public bool Result { get; private set; }
        public string Error { get; private set; }

        public static RuleResult Success() => new RuleResult
        {
            Result = true,
            Error = string.Empty
        };

        public static RuleResult Failure(string error) => new RuleResult
        {
            Result = false,
            Error = error
        };
    }
}
