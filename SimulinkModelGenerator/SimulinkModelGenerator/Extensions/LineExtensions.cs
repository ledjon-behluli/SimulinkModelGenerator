using SimulinkModelGenerator.Models;
using System.Collections.Generic;

namespace SimulinkModelGenerator.Extensions
{
    internal static class LineExtensions
    {
        public static bool Exists(this List<Line> lines, Line line)
        {
            foreach(var l in lines)            
                if (l.Equals(l, line))
                    return true;

            return false;
        }
    }
}
