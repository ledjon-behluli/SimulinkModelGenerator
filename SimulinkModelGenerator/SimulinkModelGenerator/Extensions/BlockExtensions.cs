using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace SimulinkModelGenerator.Extensions
{
    internal static class BlockExtensions
    {
        internal static Point GetCenterPoint(this Block block)
        {
            string[] coordinates = block.P.Find(p => p.Name == "Position").Text.Split(',');

            int x1 = int.Parse(coordinates[0]);
            int y1 = int.Parse(coordinates[1]);
            int x2 = int.Parse(coordinates[2]);
            int y2 = int.Parse(coordinates[3]);

            return (block.P.Find(p => p.Name == "BlockMirror").Text == "on") ? new Point(x1 + (x1 - x2) / 2, y1 + (y2 - y1) / 2) 
                : new Point(x1 + (x2 - x1) / 2, y1 + (y2 - y1) / 2);
        }
    }
}
