using SimulinkModelGenerator.Exceptions;
using SimulinkModelGenerator.Extensions;
using SimulinkModelGenerator.Modeler.GrammarRules;
using SimulinkModelGenerator.Models;
using System;
using System.Linq;

namespace SimulinkModelGenerator.Modeler.Builders.SystemLineBuilders
{
    internal class LinePathBuilder : IPathBuilder, IHorizontalPath, IVerticalPath
    {
        private readonly Model model;
        internal LinePath PathCombination { get; }

        internal LinePathBuilder(Model model)
        {
            PathCombination = new LinePath();
            this.model = model;
        }


        public IHorizontalPath GoUp()
        {
            PathCombination.SetFirstPath(LinePath.Type.Up);
            return this;
        }

        public IHorizontalPath GoDown()
        {
            PathCombination.SetFirstPath(LinePath.Type.Down);
            return this;
        }

        public IVerticalPath GoLeft()
        {
            PathCombination.SetFirstPath(LinePath.Type.Left);
            return this;
        }

        public IVerticalPath GoRight()
        {
            PathCombination.SetFirstPath(LinePath.Type.Right);
            return this;
        }


        public void ThanUp() => PathCombination.SetSecondPath(LinePath.Type.Up);

        public void ThanDown() => PathCombination.SetSecondPath(LinePath.Type.Down);

        public void ThanLeft() => PathCombination.SetSecondPath(LinePath.Type.Left);

        public void ThanRight() => PathCombination.SetSecondPath(LinePath.Type.Right);


        internal class LinePath
        {
            internal enum Type
            {
                Straight,
                Up,
                Down,
                Left,
                Right
            }

            internal enum Combination
            {
                Up_Left,
                Up_Right,
                Down_Left,
                Down_Right,
                Left_Up,
                Left_Down,
                Right_Up,
                Right_Down
            }

            private Type firstPathType;
            private Type secondPathType;

            internal Combination CombinationType
            {
                get
                {
                    if (firstPathType == Type.Up && secondPathType == Type.Left)
                        return Combination.Up_Left;
                    else if (firstPathType == Type.Up && secondPathType == Type.Right)
                        return Combination.Up_Right;
                    else if (firstPathType == Type.Down && secondPathType == Type.Left)
                        return Combination.Down_Left;
                    else if (firstPathType == Type.Down && secondPathType == Type.Right)
                        return Combination.Down_Right;
                    if (firstPathType == Type.Left && secondPathType == Type.Up)
                        return Combination.Left_Up;
                    else if (firstPathType == Type.Left && secondPathType == Type.Down)
                        return Combination.Left_Down;
                    else if (firstPathType == Type.Right && secondPathType == Type.Up)
                        return Combination.Right_Up;
                    else if (firstPathType == Type.Right && secondPathType == Type.Down)
                        return Combination.Right_Down;
                    else
                        throw new SimulinkModelGeneratorException("Using formated connection lines requires setting either both horizontal and vertical orientations, or setting neither of them.");
                }
            }

            internal LinePath()
            {
                firstPathType = Type.Straight;
                secondPathType = Type.Straight;
            }

            internal void SetFirstPath(Type type) => firstPathType = type;
            internal void SetSecondPath(Type type) => secondPathType = type;

            internal bool IsStraight() => firstPathType == Type.Straight && secondPathType == Type.Straight;
        }

        internal Parameter GetBranchPointParameter(string sourceBlockName, string destinationBlockName, Action<IPathBuilder> action = null)
        {
            Parameter @default = new Parameter() { Name = "Points", Text = "[0, 0]" };

            action?.Invoke(this);

            if (!PathCombination.IsStraight())
            {
                Block srcBlock = this.model.System.Block.FirstOrDefault(b => b.BlockName == sourceBlockName);
                if (srcBlock != null)
                {
                    Block destBlock = this.model.System.Block.FirstOrDefault(b => b.BlockName == destinationBlockName);
                    if (destBlock != null)
                    {
                        int horizontalDiff = BlockExtensions.GetHorizontalDistance(srcBlock, destBlock);
                        int verticalDiff = BlockExtensions.GetVerticalDistance(srcBlock, destBlock);

                        switch (PathCombination.CombinationType)
                        {
                            case LinePath.Combination.Up_Left:
                            case LinePath.Combination.Up_Right:
                                {
                                    @default = new Parameter() { Name = "Points", Text = $"[0, {-1 * verticalDiff}]" };
                                }
                                break;
                            case LinePath.Combination.Down_Left:
                            case LinePath.Combination.Down_Right:
                                {
                                    @default = new Parameter() { Name = "Points", Text = $"[0, {verticalDiff}]" };
                                }
                                break;
                            case LinePath.Combination.Left_Up:
                            case LinePath.Combination.Left_Down:
                                {
                                    @default = new Parameter() { Name = "Points", Text = $"[{-1 * horizontalDiff}, 0]" };
                                }
                                break;
                            case LinePath.Combination.Right_Up:
                            case LinePath.Combination.Right_Down:
                                {
                                    @default = new Parameter() { Name = "Points", Text = $"[{horizontalDiff}, 0]" };
                                }
                                break;
                        }
                    }
                }
            }

            return @default;
        }
    }
}
