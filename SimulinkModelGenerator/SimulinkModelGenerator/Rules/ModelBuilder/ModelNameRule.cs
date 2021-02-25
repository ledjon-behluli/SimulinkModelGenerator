using System.Linq;
using System.Text.RegularExpressions;

namespace SimulinkModelGenerator.Rules.ModelBuilder
{
    internal class ModelNameRule : AndRule<string>
    {
        private ModelNameRule()
            : base(new EmptyNameRule(), 
                   new LengthCheckRule(), 
                   new PatternMatchRule(),
                   new WhiteSpaceRule(), 
                   new StartsWithUnderscoreRule(), 
                   new StartsWithNumberRule())
        { 
        
        }

        public static bool Evaluate(string modelName, out string error)
        {
            RuleResult result = new ModelNameRule().IsStatisfied(modelName);
            
            if (result.Result)
            {
                error = string.Empty;
                return true;
            }
            else
            {
                error = result.Error;
                return false;
            }
        }

        #region Individual Rules

        private class EmptyNameRule : IRule<string>
        {
            public RuleResult IsStatisfied(string value) => string.IsNullOrEmpty(value) ?
                RuleResult.Failure("Model name can not be null or empty") : RuleResult.Success();
        }

        private class LengthCheckRule : IRule<string>
        {
            public RuleResult IsStatisfied(string value) => value.Length < 2 || value.Length >= 64 ?
                RuleResult.Failure("Model name must have more than 2 and less than 64 characters") : RuleResult.Success();
        }

        private class PatternMatchRule : IRule<string>
        {
            public RuleResult IsStatisfied(string value) => !Regex.Match(value, "^[A-Za-z0-9_]+$").Success ?
                RuleResult.Failure("Model name can only contain these characters: a-z, A-Z, 0-9, and the underscore") : RuleResult.Success();
        }

        private class WhiteSpaceRule : IRule<string>
        {
            public RuleResult IsStatisfied(string value) => value.Any(c => char.IsWhiteSpace(c)) ?
                RuleResult.Failure("Model name can not have any whitespace character") : RuleResult.Success();
        }

        private class StartsWithUnderscoreRule : IRule<string>
        {
            public RuleResult IsStatisfied(string value) => value.StartsWith("_") ?
                RuleResult.Failure("Model name can not start with an underscore character") : RuleResult.Success();
        }

        private class StartsWithNumberRule : IRule<string>
        {
            public RuleResult IsStatisfied(string value) => char.IsNumber(value.ToCharArray().ElementAt(0)) ?
                RuleResult.Failure("Model name can not start with a number") : RuleResult.Success();
        }

        #endregion
    }
}
