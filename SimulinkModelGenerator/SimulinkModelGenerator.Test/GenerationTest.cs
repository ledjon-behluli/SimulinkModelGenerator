using NUnit.Framework;
using SimulinkModelGenerator.Modeler.Builders;
using SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.MathOperations;
using SimulinkModelGenerator.Modeler.Builders.SystemLineBuilders;

namespace SimulinkModelGenerator.Test
{
    public class GenerationTest
    {
        private string path;

        [SetUp]
        public void Setup()
        {
            path = @"D:\New folder (5)\Simulink-Model-Parsing-Tools-master";
        }
        
        [Test]
        public void Test1()
        {
            ModelBuilder builder = new ModelBuilder();
            builder.WithName("test1")
                   .AddControlSystem(cs =>
                   {
                       cs.AddSources(s => {
                           s.AddStep(step => step.SetPosition(170, 110).WithName("Step"));
                       })
                       .AddMathOperations(m =>
                       {
                           m.AddGain(gain => gain.SetPosition(355, 60).WithName("Gain1"));
                           m.AddGain(gain => gain.SetPosition(355, 165).WithName("Gain2"));
                       })
                       .AddSinks(s => {
                           s.AddScope(scope => scope.SetPosition(470, 59).WithName("Scope1"));
                           s.AddScope(scope => scope.SetPosition(470, 163).WithName("Scope2"));
                       })
                       .AddConnections("Step", c =>
                       {
                           c.Branch(b => b.Towards("Gain1").ThanConnect("Scope1"));
                           c.Branch(b => b.Towards("Gain2").ThanConnect("Scope2"));                            
                       });
                   })
                   .Save(path);
        }

        [Test]
        public void Test2()
        {
            new ModelBuilder()
                .WithName("test2")
                .AddControlSystem(cs =>
                {
                    cs.AddSources(s =>
                    {
                        s.AddConstant(c => c.SetPosition(285, 195).WithName("Constant"));
                    });
                    cs.AddMathOperations(mo =>
                    {
                        mo.AddGain(g => g.SetPosition(595, 120).WithName("Gain"))
                          .AddGain(g => g.SetPosition(595, 195).WithName("Gain1"))
                          .AddGain(g => g.SetPosition(595, 260).WithName("Gain2"))
                          .AddGain(g => g.SetPosition(380, 195).WithName("Gain3"));
                    });
                    cs.AddSinks(s =>
                    {
                        s.AddScope(sc => sc.SetPosition(720, 194).WithName("Scope"))
                         .AddScope(sc => sc.SetPosition(720, 119).WithName("Scope1"))
                         .AddScope(sc => sc.SetPosition(720, 259).WithName("Scope2"));
                    });
                    cs.AddConnections("Constant", c =>
                    {
                        c.ThanConnect("Gain3")
                         .Branch(b => b.Towards("Gain").ThanConnect("Scope1"))
                         .Branch(b => b.Towards("Gain1").ThanConnect("Scope"))
                         .Branch(b => b.Towards("Gain2").ThanConnect("Scope2"));
                    });
                })
                .Save(path);
        }

        [Test]
        public void Test3()
        {
            new ModelBuilder()
                .WithName("test3")
                .AddControlSystem(cs =>
                {
                    cs.AddSources(s =>
                    {
                        s.AddConstant(c => c.SetPosition(285, 195));
                    });
                    cs.AddMathOperations(mo =>
                    {
                        mo.AddGain(g => g.SetPosition(595, 120))
                          .AddGain(g => g.SetPosition(595, 195))
                          .AddGain(g => g.SetPosition(595, 260))
                          .AddGain(g => g.SetPosition(380, 195));
                    });
                    cs.AddSinks(s =>
                    {
                        s.AddScope(sc => sc.SetPosition(720, 194))
                         .AddScope(sc => sc.SetPosition(720, 119))
                         .AddScope(sc => sc.SetPosition(720, 259));
                    });
                    cs.AddConnections("Constant", c =>
                    {
                        c.ThanConnect("Gain3")
                         .Branch(b => b.Towards("Gain").ThanConnect("Scope1"))
                         .Branch(b => b.Towards("Gain1").ThanConnect("Scope"))
                         .Branch(b => b.Towards("Gain2").ThanConnect("Scope2"));
                    });
                })
                .Save(path);
        }

        [Test]
        public void Testn()
        {
            ModelBuilder builder = new ModelBuilder();
            var a = builder.WithName("test3")
                   .AddControlSystem(cs =>
                   {
                       cs.AddSources(s => s.AddStep(sp => sp.SetPosition(190, 145)));
                       cs.AddMathOperations(mo => mo.AddSum(sum => sum.SetInputs(InputType.Minus))
                                                    .AddGain(g => g.SetGain(3)).SetPosition(515, 230));
                       cs.AddContinuous(co =>
                       {
                           co.AddPIDController(pid =>
                           {
                               pid.SetPosition(435, 142).SetDerivative(3).SetIntegral(3).SetProportional(3);
                           });
                           co.AddTransferFunction(tf => tf.SetNumerator(1).SetDenominator(1, 2));
                       });
                       cs.AddSinks(s => s.AddScope());                     
                   }).Build();

        }
    }
}