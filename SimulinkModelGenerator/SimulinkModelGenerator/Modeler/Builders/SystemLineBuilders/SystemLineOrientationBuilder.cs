using SimulinkModelGenerator.Extensions;
using SimulinkModelGenerator.Exceptions;
using SimulinkModelGenerator.Modeler.GrammarRules;
using System;
using System.Collections.Generic;
using SimulinkModelGenerator.Models;

namespace SimulinkModelGenerator.Modeler.Builders.SystemLineBuilders
{
    internal class SystemLineOrientationBuilder : IControlSystemLineOrientation 
    {
        private readonly Model model;
        private string previousBlockName;

        internal SystemLineOrientationBuilder(Model model, string previousBlockName)
        {
            this.model = model;
            this.previousBlockName = previousBlockName;
        }

        public IControlSystemLine Straight()
        {
            //TODO: WIP
            throw new NotImplementedException();
        }
    }
}
