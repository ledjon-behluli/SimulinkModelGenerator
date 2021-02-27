using SimulinkModelGenerator.Exceptions;
using SimulinkModelGenerator.Extensions;
using SimulinkModelGenerator.Modeler.GrammarRules;
using SimulinkModelGenerator.Models;
using System;

namespace SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.MathOperations
{
    public sealed class SumBuilder : MathOperationBuilder<SumBuilder>, ISum
    {
        internal override SizeU Size => new SizeU(20, 20);

        protected override string BlockType => "Sum";
        protected override string BlockName => "Sum";
        protected override string OutDataTypeStr => "Inherit: Same as first input";

        private IconShape _IconShape = IconShape.Round;
        private string _Ports
        {
            get
            {
                string ports = string.Empty;

                if (_InputTypes.Length == 0)
                    ports = "3, 1";
                else
                    ports = $"{_InputTypes.Length}, 1";

                return $"[{ports}]";
            }
        }
        private InputType[] _InputTypes = new[] { InputType.Plus, InputType.Plus };
        private string _Inputs
        {
            get
            {
                string inputs = string.Empty;

                if (_InputTypes.Length == 0)
                    inputs = "++";
                else
                {
                    foreach (InputType inputType in _InputTypes)
                        inputs += inputType.GetDescription();
                }

                return $"|{inputs}";
            }
        }

        internal SumBuilder(Model model)
            : base(model)
        {

        }


        public IBaseSum WithIconShape(IconShape shape)
        {
            _IconShape = shape;
            return this;
        }

        public IBaseSum SetInputs(params InputType[] inputs)
        {
            if (inputs.Length == 0)
                throw new SimulinkModelGeneratorException("Sum must have at least one input.");

            _InputTypes = inputs;
            return this;
        }

        internal override void Build()
        {
            Block block = GetBlock();

            block.Parameters.Add(new Parameter() { Name = "IconShape", Text = _IconShape.GetDescription() });
            block.Parameters.Add(new Parameter() { Name = "Inputs", Text = _Inputs });
            block.Parameters.Add(new Parameter() { Name = "Ports", Text = _Ports });

            model.System.Block.Add(block);
        }
    }
}
