using SimulinkModelGenerator.Models;
using System;
using System.Drawing;

namespace SimulinkModelGenerator.Extensions
{
    internal static class BlockExtensions
    {
        public static Tuple<int, int, int, int> GetCoordinates(this Block block)
        {
            string[] coordinates = block.Parameters.Find(p => p.Name == "Position").Text
                .Replace("[", string.Empty)
                .Replace("]", string.Empty)
                .Split(',');

            int x1 = int.Parse(coordinates[0]);
            int y1 = int.Parse(coordinates[1]);
            int x2 = int.Parse(coordinates[2]);
            int y2 = int.Parse(coordinates[3]);

            return new Tuple<int, int, int, int>(x1, y1, x2, y2);
        }

        public static Point GetCenterPoint(this Block block)
        {
            (int x1, int y1, int x2, int y2) = block.GetCoordinates();

            return (block.Parameters.Find(p => p.Name == "BlockMirror").Text == "on") ?
               new Point(x1 + (x1 - x2) / 2, y1 + (y2 - y1) / 2) :
               new Point(x1 + (x2 - x1) / 2, y1 + (y2 - y1) / 2);
        }

        public static int GetHorizontalDistance(Block srcBlock, Block destBlock)
        {
            Point srcCenter = srcBlock.GetCenterPoint();
            Point destCenter = destBlock.GetCenterPoint();

            return Math.Abs(destCenter.X - srcCenter.X);
        }

        public static int GetVerticalDistance(Block srcBlock, Block destBlock)
        {
            Point srcCenter = srcBlock.GetCenterPoint();
            Point destCenter = destBlock.GetCenterPoint();

            return Math.Abs(destCenter.Y - srcCenter.Y);
        }

        public static int GetWidth(this Block block)
        {
            (int x1, int y1, int x2, int y2) = block.GetCoordinates();
            return x2 - x1;
        }

        public static int GetHeight(this Block block)
        {
            (int x1, int y1, int x2, int y2) = block.GetCoordinates();
            return y2 - y1;
        }
    }
}
