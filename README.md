![alt text](https://github.com/ledjon-behluli/SimulinkModelGenerator/blob/master/SimulinkModelGenerator/Assets/simulink-icon.png?raw=true)
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

Sources | Sinks | Math Operations | Continuous
------------ | ------------- | ------------ | -------------
Constant | Scope | Sum | Integrator
Step | Display | Gain | Integrator Limited
Ramp | XY Graph | Slider Gain | Transfer Function
Inport | Outport | Add | Zero Pole
From Workspace | To Workspace | Product | Derivative
Clock | | Dot Product | Transport Delay
Digital Clock | | Divide | State Space
Repeating Sequence | | Subtract | PID
Random Number | | Min | PD
Uniform Random Number | | Max | PI
Signal Generator | | Sign | I
Time-based Pulse Generator | | Sqrt | P
Sample-based Pulse Generator | | Signed Sqrt | 2dof PID
Time-based Sine Wave Generator | | Reciprocal Sqrt | 2dof PD
Sample-based Sine Wave Generator | | Math Function | 2dof PI
 | | | Abs |
 | | | Trigonometric Function |

Below is a generated model as seen in Simulink (tested with Matlab R2017a).

![alt text](https://github.com/ledjon-behluli/SimulinkModelGenerator/blob/master/SimulinkModelGenerator/Assets/simulink-diagram.png?raw=true)

Scope output for 10s simulation time:

![alt text](https://github.com/ledjon-behluli/SimulinkModelGenerator/blob/master/SimulinkModelGenerator/Assets/scope-output.png?raw=true)

C# code to generate '.mdl' file of the above model. Other examples can be found [here](https://github.com/ledjon-behluli/SimulinkModelGenerator/blob/master/SimulinkModelGenerator/SimulinkModelGenerator.Samples/Program.cs)

```csharp
using SimulinkModelGenerator;
using SimulinkModelGenerator.Modeler.Builders;

ModelBuilder
    .Create()
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
