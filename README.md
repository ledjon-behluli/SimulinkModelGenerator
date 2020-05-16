![alt text](https://github.com/ledjon-behluli/SimulinkModelGenerator/blob/master/SimulinkModelGenerator/simulink-icon.png?raw=true)
# Simulink Model Generator
Fully .NET managed solution for creating [Simulink](https://www.mathworks.com/products/simulink.html) models in fluent style.

Library is available through [NuGet](https://www.nuget.org/packages/SimulinkModelGenerator/).

Create Simulink models right from your C# application. SimulinkModelGenerator targets .NET Standart 2.0, you can consume it within any type of application targeting below platform versions:

Platform | Supported Versions
------------ | -------------
.NET Framework | >= 4.6.1
.NET Core | >= 2.0
Mono | >= 5.4
Xamarin.iOS | >= 10.14
Xamarin.Mac | >= 3.8
Xamarin.Android | >= 8.0
Universal Windows Platform | >= 10.0.16299
Unity | >= 2018.1

Supported Simulink elements (*more to come*):
- Sources:
  - Constant
  - Step
  - Ramp
- Sinks:
  - Scope
  - Display
- Math Operations:
  - Sum
  - Gain
- Continuous:
  - Integrator
  - Transfer Function
  - 1dof PID Controller types:
    - PID
    - PD
    - PI
    - I
    - P
    
Below is a generated model as seen in Simulink (tested with Matlab R2017a).

![alt text](https://github.com/ledjon-behluli/SimulinkModelGenerator/blob/master/SimulinkModelGenerator/simulink-diagram.png?raw=true)

Scope output for 10s simulation time:

![alt text](https://github.com/ledjon-behluli/SimulinkModelGenerator/blob/master/SimulinkModelGenerator/scope-output.png?raw=true)

C# code to generate '.mdl' file of the above model. Other examples can be found [here](https://github.com/ledjon-behluli/SimulinkModelGenerator/blob/master/SimulinkModelGenerator/SimulinkModelGenerator.Test/Tests.cs)

```csharp
using SimulinkModelGenerator.Modeler.Builders;
using SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.MathOperations;

new ModelBuilder()
                .WithName("MyModel")
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
                .Save(@"C:\SimulinkModelGenerator");
```
