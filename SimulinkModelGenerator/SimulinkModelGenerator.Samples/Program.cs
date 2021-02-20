using SimulinkModelGenerator.Modeler.Builders;
using SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.MathOperations;

namespace SimulinkModelGenerator.Samples
{
    class Program
    {
        static string path = @"C:\SimulinkModelGenerator";

        static void Main(string[] args)
        {
            test();

            //All_Elements();
            //Common_Elements_With_Set_Names_And_Without_Connections();
            //Common_Elements_With_Set_Names_And_With_Connections();
            //Common_Elements_With_Automatic_Names_And_With_Connections_Style_1();
            //Common_Elements_With_Automatic_Names_And_With_Connections_Style_2();
            //PID_Example();
        }

        static void test()
        {
            ModelBuilder
                .Create()
                .WithName("test")
                .WithSimulationMode(SimulationMode.Accelerator)
                .Configure(c => c
                    .Solver(s => s
                        .SetSimulationTimes(0, 10)
                        .Options(o => o
                            .AsFixedStepSolver()
                                .Ode14x()
                                .WithJacobian(Jacobian.FullPerturbation)
                                .WithNewtonInterations(4)
                                .WithOrder(ExtrapolationOrder.Four))))
                .AddControlSystem()
                .Build();
        }

        static void All_Elements()
        {
            ModelBuilder
                .Create()
                .WithName("all elements")
                .AddControlSystem(cs =>
                {
                    cs.AddSources(s => s.AddStep(x => x.SetPosition(100, 100))
                                        .AddConstant(x => x.SetPosition(100, 170))
                                        .AddRamp(x => x.SetPosition(100, 240))
                                        .AddInPort(x => x.SetPosition(100, 310))
                                        .AddRepeatingSequence(x => x.SetPosition(100, 380))
                                        .AddFromWorkspace(x => x.SetPosition(100, 450))
                                        .AddClock(x => x.SetPosition(100, 520))
                                        .AddDigitalClock(x => x.SetPosition(100, 590))
                                        .AddRandomNumber(x => x.SetPosition(100, 660))
                                        .AddUniformRandomNumber(x => x.SetPosition(100, 730))
                                        .AddSignalGenerator(x => x.SetPosition(100, 800))
                                        .AddTimeBasedPulseGenerator(x => x.SetPosition(100, 870))
                                        .AddSampleBasedPulseGenerator(x => x.SetPosition(100, 940))
                                        .AddTimeBasedSineWaveGenerator(x => x.SetPosition(100, 1010))
                                        .AddSampleBasedSineWaveGenerator(x => x.SetPosition(100, 1080)));
                    cs.AddMathOperations(mo => mo.AddSum(x => x.SetPosition(200, 100))
                                                 .AddAbs(x => x.SetPosition(200, 170))
                                                 .AddAddition(x => x.SetPosition(200, 240))
                                                 .AddSubtraction(x => x.SetPosition(200, 310))
                                                 .AddDivision(x => x.SetPosition(200, 380))
                                                 .AddProduct(x => x.SetPosition(200, 450))
                                                 .AddDotProduct(x => x.SetPosition(200, 520))
                                                 .AddMathFunction(x => x.SetPosition(200, 590))
                                                 .AddMin(x => x.SetPosition(200, 660))
                                                 .AddMin(x => x.SetPosition(200, 730))
                                                 .AddSign(x => x.SetPosition(200, 800))
                                                 .AddGain(x => x.SetPosition(200, 870))
                                                 .AddSliderGain(x => x.SetPosition(200, 940))
                                                 .AddSquareRoot(x => x.SetPosition(200, 1010))
                                                 .AddSignedSquareRoot(x => x.SetPosition(200, 1080))
                                                 .AddReciprocalSquareRoot(x => x.SetPosition(200, 1150))
                                                 .AddTrigonometricFunction(x => x.SetPosition(200, 1220)));
                    cs.AddContinuous(co => co.AddIntegrator(x => x.SetPosition(300, 100))
                                             .AddLimitedIntegrator(x => x.SetPosition(300, 170))
                                             .AddTransferFunction(x => x.SetPosition(300, 240))
                                             .AddZeroPole(x => x.SetPosition(300, 310))
                                             .AddDerivative(x => x.SetPosition(300, 380))
                                             .AddStateSpace(x => x.SetPosition(300, 450))
                                             .AddTransportDelay(x => x.SetPosition(300, 520))
                                             .AddPIDController(x => x.SetPosition(300, 590))
                                             .AddPDController(x => x.SetPosition(300, 660))
                                             .AddPIController(x => x.SetPosition(300, 730))
                                             .AddIController(x => x.SetPosition(300, 800))
                                             .AddPController(x => x.SetPosition(300, 870))
                                             .Add2DofPIDController(x => x.SetPosition(300, 940))
                                             .Add2DofPDController(x => x.SetPosition(300, 1010))
                                             .Add2DofPIController(x => x.SetPosition(300, 1080)));
                    cs.AddSinks(s => s.AddScope(x => x.SetPosition(425, 100))
                                      .AddDisplay(x => x.SetPosition(425, 170))
                                      .AddOutPort(x => x.SetPosition(425, 240))
                                      .AddToWorkspace(x => x.SetPosition(425, 310))
                                      .AddXYGraph(x => x.SetPosition(425, 380)));
                })
                .Save(path);
        }

        static void Common_Elements_With_Set_Names_And_Without_Connections()
        {
            ModelBuilder
                .Create()
                .WithName("common elements with set names and without connections")
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

        static void Common_Elements_With_Set_Names_And_With_Connections()
        {
            ModelBuilder
                .Create()
                .WithName("common elements with set names and with connections")
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

        static void Common_Elements_With_Automatic_Names_And_With_Connections_Style_1()
        {
            ModelBuilder
                .Create()
                .WithName("common elements with automatic names and with connections")
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

        static void Common_Elements_With_Automatic_Names_And_With_Connections_Style_2()
        {
            ModelBuilder
                .Create()
                .WithName("common elements with automatic names and with connections")
                .AddControlSystem(cs => cs
                    .AddSources(s => s.AddConstant(c => c.SetPosition(285, 195)))
                    .AddMathOperations(mo => mo
                        .AddGain(g => g.SetPosition(595, 120))
                        .AddGain(g => g.SetPosition(595, 195))
                        .AddGain(g => g.SetPosition(595, 260))
                        .AddGain(g => g.SetPosition(380, 195)))
                    .AddSinks(s => s
                        .AddScope(sc => sc.SetPosition(720, 194))
                        .AddScope(sc => sc.SetPosition(720, 119))
                        .AddScope(sc => sc.SetPosition(720, 259)))
                    .AddConnections("Constant", c => c
                        .ThanConnect("Gain3")
                        .Branch(b => b.Towards("Gain")
                            .ThanConnect("Scope1"))
                            .Branch(b => b.Towards("Gain1")
                                .ThanConnect("Scope"))
                                .Branch(b => b.Towards("Gain2").ThanConnect("Scope2"))))
                .Save(path);
        }

        static void PID_Example()
        {
            ModelBuilder
                .Create()
                .WithName("PID example")
                .AddControlSystem(cs =>
                {
                    cs.AddSources(s => s.AddStep(sp => sp.SetStepTime(0).SetPosition(190, 145))
                                        .AddConstant(c => c.SetPosition(190, 245)));
                    cs.AddMathOperations(mo => mo.AddSum(sum => sum.SetInputs(InputType.Plus, InputType.Minus).SetPosition(320, 150))
                                                .AddGain(g => g.SetGain(1).FlipHorizontally().SetPosition(515, 230)));
                    cs.AddContinuous(co =>
                    {
                        co.AddPIDController(pid => pid.SetProportional(31.0019358281379)
                                                      .SetIntegral(88.4489521692078)
                                                      .SetDerivative(1.81032163065042)
                                                      .SetFilterCoefficient(4337.28406726102)
                                                      .SetPosition(435, 142));
                        co.AddTransferFunction(tf => tf.SetNumerator(20).SetDenominator(1, 10, 20).SetPosition(595, 142));
                    });
                    cs.AddSinks(s => s.AddScope(scope => scope.SetInputPorts(2).SetPosition(820, 144)));
                    cs.AddConnections("Step", c =>
                    {
                        c.ThanConnect("Sum").ThanConnect("PID Controller").ThanConnect("TransferFcn")
                        .Branch(b => b.Towards("Scope", 1))
                        .Branch(b => b.Towards("Gain").ThanConnect("Sum", 2))
                        .Connect("Constant", "Scope", 1, 2);
                    });
                })
                .Save(path);
        }
    }
}
