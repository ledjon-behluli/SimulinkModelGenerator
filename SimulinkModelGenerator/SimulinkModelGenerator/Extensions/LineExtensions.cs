using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace SimulinkModelGenerator.Extensions
{
    internal static class LineExtensions
    {
        internal static bool Exists(this List<Line> lines, Line line)
        {
            foreach(var l in lines)            
                if (l.Equals(l, line))
                    return true;

            return false;
        }
    }
}
