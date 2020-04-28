using NUnit.Framework;
using SimulinkModelGenerator.Modeler.Builders;
using SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.MathOperations;

namespace SimulinkModelGenerator.Test
{
    public class GenerationTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            ModelBuilder builder = new ModelBuilder();
            builder.WithName("untitled1")
                   .AddControlSystem(cs =>
                   {
                       cs.AddSources(s => s.AddConstant());
                       cs.AddMathOperations(mo => mo.AddSum(sum => sum.SetInputs(InputType.Minus, InputType.Minus).SetPosition(1, 1, 1, 1))
                                                    .AddGain(g => g.SetGain(3).SetPosition(1, 1, 1, 1)));
                       cs.AddContinuous(co =>
                       {
                           co.AddPIDController(pid =>
                           {
                               pid.WithName("PID 1");
                               pid.SetPosition(1, 1, 1, 1);
                               pid.SetDerivative(3).SetIntegral(3).SetProportional(3);
                           });
                           co.AddTransferFunction(tf => tf.SetNumerator(1).SetDenominator(1, 2).SetPosition(1, 1, 1, 1));
                       });
                       cs.AddSinks(s => s.AddScope(scope => scope.SetPosition(1, 1, 1, 1)));
                   });
        }
    }
}