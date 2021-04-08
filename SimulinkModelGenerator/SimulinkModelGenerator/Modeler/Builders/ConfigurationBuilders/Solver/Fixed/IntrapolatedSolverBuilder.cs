using SimulinkModelGenerator.Modeler.GrammarRules;
using SimulinkModelGenerator.Models;

namespace SimulinkModelGenerator.Modeler.Builders.ConfigurationBuilders.Solver.Fixed
{
    internal class IntrapolatedSolverBuilder : IIntrapolatedFixedSolverType
    {
        private readonly Model model;

        internal IntrapolatedSolverBuilder(Model model)
        {
            this.model = model;
        }

        public void WithSampleTime(double sampleTime = 0.001) => 
            model.Array.ConfigSet.Solver.AdditionalSolverOptions.SetSampleTime(sampleTime);
    }   
}
