using SimulinkModelGenerator.Exceptions;
using SimulinkModelGenerator.Extensions;
using SimulinkModelGenerator.Modeler.GrammarRules;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.MathOperations
{
    public enum IconShape
    {
        [Description("round")]
        Round,

        [Description("rectangular")]
        Rectangular
    }

    public enum InputType
    {
        [Description("+")]
        Plus,

        [Description("-")]
        Minus
    }

    public sealed class SumBuilder : SystemBlockBuilder<SumBuilder>, ISum
    {
        internal override SizeU Size => new SizeU(20, 20);

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

        public SumBuilder(Model model)
            : base(model)
        {

        }


        public ISum WithIconShape(IconShape shape)
        {
            _IconShape = shape;
            return this;
        }

        public ISum SetInputs(params InputType[] inputs)
        {
            if (inputs.Length == 0)
                throw new ArgumentException("Sum must have at least one input.");

            _InputTypes = inputs;
            return this;
        }

        internal override void Build()
        {
            base.model.System.Block.Add(new Block()
            {
                BlockType = "Sum",
                Name = base.GetName("Sum"),
                P = new List<P>()
                {
                    // Customizable
                    new P() { Name = "Position", Text = base._Position },
                    new P() { Name = "BlockMirror", Text = base.BlockMirror },
                    new P() { Name = "IconShape", Text = _IconShape.GetDescription() },
                    new P() { Name = "Inputs", Text = _Inputs },
                    new P() { Name = "Ports", Text = _Ports }
                }
            });
        }
    }
}
