using System.Collections.Generic;
using System.Linq;

namespace SimulinkModelGenerator.Rules
{
    internal abstract class LogicalRule<TValue> : IRule<TValue>
    {
        protected readonly IRule<TValue>[] rules;
        public IReadOnlyList<IRule<TValue>> Rules => rules.ToList().AsReadOnly();

        public LogicalRule(params IRule<TValue>[] rules)
        {
            this.rules = rules ?? new IRule<TValue>[] { };
        }

        public abstract RuleResult IsStatisfied(TValue value);
    }

    internal class AndRule<TValue> : LogicalRule<TValue>
    {
        public AndRule(params IRule<TValue>[] rules)
            : base(rules)
        {

        }

        /// <summary>
        /// Iteratively evaluates all rules by calling their respective <seealso cref="IRule.IsStatisfied(string)"/>.
        /// <para>Evaluates to:</para>
        /// <list type="bullet">
        /// <item><description>'True' if all rules are statisfied.</description></item>
        /// <item><description>'False' if any of the rules are not statisfied.</description></item>
        /// </list>
        /// </summary>
        public override RuleResult IsStatisfied(TValue value)
        {
            RuleResult result = RuleResult.Success();

            foreach (IRule<TValue> rule in rules)
            {
                RuleResult ruleResult = rule.IsStatisfied(value);
                if (!ruleResult.Result)
                {
                    result = ruleResult;
                    break;
                }
            }

            return result;
        }
    }
}
