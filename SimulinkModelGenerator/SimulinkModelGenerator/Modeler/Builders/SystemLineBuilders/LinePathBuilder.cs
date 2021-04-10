using SimulinkModelGenerator.Exceptions;
using SimulinkModelGenerator.Modeler.GrammarRules;

namespace SimulinkModelGenerator.Modeler.Builders.SystemLineBuilders
{
    internal class LinePathBuilder : IPathBuilder, IHorizontalPath, IVerticalPath
    {
        internal LinePath PathCombination { get; }

        internal LinePathBuilder()
        {
            PathCombination = new LinePath();
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
    }
}
