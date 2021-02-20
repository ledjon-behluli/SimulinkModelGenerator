using SimulinkModelGenerator.Modeler.GrammarRules;
using SimulinkModelGenerator.Models;

namespace SimulinkModelGenerator.Modeler.Builders.ConfigurationBuilders.Solver.Fixed
{
    public sealed class IntrapolatedSolverBuilder : IIntrapolatedFixedSolverType
    {
        private readonly Model model;

        public IntrapolatedSolverBuilder(Model model)
        {
            this.model = model;
        }

        public void WithSampleTime(double sampleTime = 0.001) => 
            model.ConfigSet.Solver.AdditionalSolverOptions.SetSampleTime(sampleTime);
    }   
}
