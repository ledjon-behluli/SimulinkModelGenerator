using NUnit.Framework;
using SimulinkModelGenerator.Modeler.Builders;
using SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.MathOperations;
using SimulinkModelGenerator.Modeler.Builders.SystemLineBuilders;

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
            var a = builder.WithName("untitled1")
                   .AddControlSystem(cs =>
                   {
                       cs.AddSources(s => s.AddConstant());
                       cs.AddMathOperations(mo => mo.AddSum(sum => sum.SetInputs(InputType.Minus, InputType.Minus))
                                                    .AddGain(g => g.SetGain(3)));
                       cs.AddContinuous(co =>
                       {
                           co.AddPIDController(pid =>
                           {
                               pid.WithName("PID 1");
                               pid.SetPosition(1, 1, 1, 1);
                               pid.SetDerivative(3).SetIntegral(3).SetProportional(3);
                           });
                           co.AddTransferFunction(tf => tf.SetNumerator(1).SetDenominator(1, 2));
                       });
                       cs.AddSinks(s => s.AddScope());
                       ////////////////////////////////////////////////

                       cs.Connect("Constant", "Gain3")
                            .BranchTo("Gain")                            
                                .ThanConnect("Scope1")
                            .BranchTo("Gain2")
                                .ThanConnect("Scope2")
                            .Done()
                         .Connect()

                   }).Build();
            
        }
    }
}