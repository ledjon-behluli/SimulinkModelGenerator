using SimulinkModelGenerator.Extensions;
using SimulinkModelGenerator.Modeler.GrammarRules;
using SimulinkModelGenerator.Models;
using System;
using System.Linq;

namespace SimulinkModelGenerator.Modeler.Builders.SystemLineBuilders
{
    internal class PathDirectionBuilder : IPathDirection, IPathDirectionDistance
    { 
        private readonly Model model;
        internal LinePath Path { get; }

        internal PathDirectionBuilder(Model model)
        {
            Path = new LinePath();
            this.model = model;
        }

        public IPathDirectionDistance Upward()
        {
            Path.Type = LinePath.DirectionType.Up;
            return this;
        }

        public IPathDirectionDistance Downward()
        {
            Path.Type = LinePath.DirectionType.Down;
            return this;
        }

        public IPathDirectionDistance Leftward()
        {
            Path.Type = LinePath.DirectionType.Left;
            return this;
        }

        public IPathDirectionDistance Rightward()
        {
            Path.Type = LinePath.DirectionType.Right;
            return this;
        }

        public void Lengthen(uint distance)
        {
            Path.AppendedDistance = (int)distance;
        }

        public void Shorten(uint distance)
        {
            Path.AppendedDistance = -1 * (int)distance;
        }

        
        internal Parameter CalculateBranchPoint(string sourceBlockName, string destinationBlockName, Action<IPathDirection> action = null)
        {
            Parameter @default = new Parameter() { Name = "Points", Text = "[0, 0]" };

            action?.Invoke(this);

            if (Path.Type != LinePath.DirectionType.Straight)
            {
                Block srcBlock = this.model.System.Block.FirstOrDefault(b => b.BlockName == sourceBlockName);
                if (srcBlock != null)
                {
                    Block destBlock = this.model.System.Block.FirstOrDefault(b => b.BlockName == destinationBlockName);
                    if (destBlock != null)
                    {
                        int horizontalDiff = BlockExtensions.GetHorizontalDistance(srcBlock, destBlock);
                        int verticalDiff = BlockExtensions.GetVerticalDistance(srcBlock, destBlock);

                        switch (Path.Type)
                        {
                            case LinePath.DirectionType.Up:
                                {
                                    @default = new Parameter() { Name = "Points", Text = $"[0, {-1 * (verticalDiff + Path.AppendedDistance)}]" };
                                }
                                break;
                            case LinePath.DirectionType.Down:
                                {
                                    @default = new Parameter() { Name = "Points", Text = $"[0, {verticalDiff + Path.AppendedDistance}]" };
                                }
                                break;
                            case LinePath.DirectionType.Left:
                                {
                                    @default = new Parameter() { Name = "Points", Text = $"[{-1 * (horizontalDiff + Path.AppendedDistance)}, 0]" };
                                }
                                break;
                            case LinePath.DirectionType.Right:
                                {
                                    @default = new Parameter() { Name = "Points", Text = $"[{horizontalDiff + Path.AppendedDistance}, 0]" };
                                }
                                break;
                        }
                    }
                }
            }

            return @default;
        }


        internal class LinePath
        {
            internal enum DirectionType
            {
                Straight,
                Up,
                Down,
                Left,
                Right
            }

            internal DirectionType Type { get; set; }
            internal int AppendedDistance { get; set; }


            internal LinePath()
            {
                Type = DirectionType.Straight;
                AppendedDistance = 0;
            }
        }
    }
}
