using SimulinkModelGenerator.Modeler.GrammarRules;
using SimulinkModelGenerator.Models;
using System;
using System.Collections.Generic;

namespace SimulinkModelGenerator.Modeler.Builders.SystemBlockBuilders.Continuous
{
    public sealed class TransportDelayBuilder : SystemBlockBuilder<TransportDelayBuilder>, ITransportDelay
    {
        internal override SizeU Size => new SizeU(40, 40);

        private string _TimeDelay = "1";
        private string _InitialOutput = "0";
        private string _InitialBufferSize = "1024";
        private bool _FixedBufferSize = false;
        private bool _TransportDelayFeedthrough = false;
        private string _PadeOrder = "0";

        public TransportDelayBuilder(Model model)
            : base(model)
        {

        }

      
        public ITransportDelay SetTimeDelay(double delay)
        {
            if(delay < 0)
                throw new ArgumentException("Time delay must be greater than or equal to 0");

            _TimeDelay = delay.ToString();
            return this;
        }

        public ITransportDelay SetInitialOutput(double output)
        {
            _InitialOutput = output.ToString();
            return this;
        }

        public ITransportDelay SetInitialBufferSize(int memoryInKB)
        {
            if (memoryInKB <= 0)
                throw new ArgumentException("Memory allocation size must be greater than 0");

            _InitialBufferSize = (1024 * memoryInKB).ToString();
            return this;
        }

        public ITransportDelay SetPadeOrder(int order)
        {
            if (order < 0)
                throw new ArgumentException("Pade order must be greater than or equal to 0");

            _PadeOrder = order.ToString();
            return this;
        }

        public ITransportDelay WithFixedBufferSize()
        {
            _FixedBufferSize = true;
            return this;
        }

        public ITransportDelay WithDirectFeedthrough()
        {
            _TransportDelayFeedthrough = true;
            return this;
        }


        internal override void Build()
        {
            model.System.Block.Add(new Block()
            {
                BlockType = "TransportDelay",
                BlockName = GenerateUniqueName("Transport\\nDelay"),
                P = new List<Parameter>()
                {
                    new Parameter() { Name = "Position", Text = base._Position },
                    new Parameter() { Name = "BlockMirror", Text = base._BlockMirror },
                    new Parameter() { Name = "DelayTime", Text = _TimeDelay },
                    new Parameter() { Name = "InitialOutput", Text = _InitialOutput },
                    new Parameter() { Name = "BufferSize", Text = _InitialBufferSize },
                    new Parameter() { Name = "FixedBuffer", Text = _FixedBufferSize ? "on" : "off" },
                    new Parameter() { Name = "TransDelayFeedthrough", Text = _TransportDelayFeedthrough ? "on" : "off" },
                    new Parameter() { Name = "PadeOrder", Text = _PadeOrder },
                }
            });
        }
    }
}
