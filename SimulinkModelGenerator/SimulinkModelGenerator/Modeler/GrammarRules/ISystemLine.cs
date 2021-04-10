﻿using System;

namespace SimulinkModelGenerator.Modeler.GrammarRules
{
    public interface ISystemLine : IControlSystemLine
    {

    }

    public interface IControlSystemLine
    {
        ISystemLine Connect(string sourceBlockName, string destinationBlockName, uint sourceBlockPort = 1, uint destinationBlockPort = 1, Action<IPathBuilder> action = null);
        ISystemLine ThanConnect(string destinationBlockName, uint destinationBlockPort = 1, Action<IPathBuilder> action = null);
        ISystemLine Branch(Action<ISystemBranch> action);
    }
}
