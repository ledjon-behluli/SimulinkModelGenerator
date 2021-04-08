using SimulinkModelGenerator.Models;
using System.Drawing;

namespace SimulinkModelGenerator.Extensions
{
    internal static class BlockExtensions
    {
        public static Point GetCenterPoint(this Block block)
        {
            string[] coordinates = block.Parameters.Find(p => p.Name == "Position").Text
                .Replace("[", string.Empty)
                .Replace("]", string.Empty)
                .Split(',');

            int x1 = int.Parse(coordinates[0]);
            int y1 = int.Parse(coordinates[1]);
            int x2 = int.Parse(coordinates[2]);
            int y2 = int.Parse(coordinates[3]);

            return (block.Parameters.Find(p => p.Name == "BlockMirror").Text == "on") ? new Point(x1 + (x1 - x2) / 2, y1 + (y2 - y1) / 2) 
                : new Point(x1 + (x2 - x1) / 2, y1 + (y2 - y1) / 2);
        }

        /// <returns>destCenter.X - srcCenter.X</returns>
        public static int GetHorizontalDistance(Block srcBlock, Block destBlock)
        {
            Point srcCenter = srcBlock.GetCenterPoint();
            Point destCenter = destBlock.GetCenterPoint();

            return destCenter.X - srcCenter.X;
        }

        /// <returns>destCenter.Y - srcCenter.Y</returns>
        public static int GetVerticalDistance(Block srcBlock, Block destBlock)
        {
            Point srcCenter = srcBlock.GetCenterPoint();
            Point destCenter = destBlock.GetCenterPoint();

            return destCenter.Y - srcCenter.Y;
        }
    }
}
