using NUnit.Framework;
using SimulinkModelGenerator.Modeler.Builders;
using SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.Continuous;
using SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.MathOperations;

namespace SimulinkModelGenerator.Test
{
    public class Tests
    {
        private string path;

        [SetUp]
        public void Setup()
        {
            path = @"C:\SimulinkModelGenerator";
        }

        [Test]
        public void Test0()
        {
            new ModelBuilder()
                .WithName("test0")
                .AddControlSystem(cs =>
                {
                    cs.AddSources(s => s.AddStep(s => s.SetPosition(100, 100))
                                        .AddConstant(c => c.SetPosition(100, 170))
                                        .AddRamp(r => r.SetPosition(100, 240)));
                    cs.AddMathOperations(mo => mo.AddSum(s => s.SetPosition(200, 105))
                                                 .AddGain(g => g.SetPosition(200, 170)));
                    cs.AddContinuous(co => co.AddTransferFunction(tf => tf.SetPosition(300, 100))
                                             .AddIntegrator(i => i.SetPosition(300, 170))
                                             .AddPIDController(pid => pid.SetPosition(300, 240))
                                             .AddPDController(pd => pd.SetPosition(300, 310))
                                             .AddPIController(pi => pi.SetPosition(300, 380))                                             
                                             .AddIController(i => i.SetPosition(300, 450))
                                             .AddPController(p => p.SetPosition(300, 520)));
                    cs.AddSinks(s => s.AddScope(s => s.SetPosition(425, 104))
                                      .AddDisplay(d => d.SetPosition(425, 170)));
                })
                .Save(path);
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
        public void Test4()
        {
            new ModelBuilder()     
                .WithName("test4")
                .AddControlSystem(cs =>
                {
                    cs.AddSources(s => s.AddStep(sp => sp.SetPosition(190, 145))
                                        .AddConstant(c => c.SetValue(3).SetPosition(190, 225)));
                    cs.AddMathOperations(mo => mo.AddSum(sum => sum.SetInputs(InputType.Plus, InputType.Minus, InputType.Minus).SetPosition(320, 150))
                                                .AddGain(g => g.SetGain(3).FlipHorizontally().SetPosition(515, 230))
                                                .AddGain(g => g.SetGain(2).FlipHorizontally().SetPosition(515, 300)));
                    cs.AddContinuous(co =>
                    {
                        co.AddPIDController(pid => pid.SetDerivative(3).SetIntegral(3).SetProportional(3).SetPosition(435, 142));                         
                        co.AddTransferFunction(tf => tf.SetNumerator(1).SetDenominator(3, 1, 2).SetPosition(595, 142));
                    });
                    cs.AddSinks(s => s.AddScope(scope => scope.SetInputPorts(2).SetPosition(820, 144)));
                    cs.AddConnections("Step", c =>
                    {
                        c.ThanConnect("Sum").ThanConnect("PID Controller").ThanConnect("TransferFcn")
                        .Branch(b => b.Towards("Scope", 1))
                        .Branch(b => b.Towards("Gain").ThanConnect("Sum", 3))
                        .Branch(b => b.Towards("Gain1").ThanConnect("Sum", 2))
                        .Connect("Constant", "Scope", 1, 2);
                    });
                })
                .Save(path);
        }
    }
}