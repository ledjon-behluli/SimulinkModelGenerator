using SimulinkModelGenerator.Exceptions;
using SimulinkModelGenerator.Modeler.GrammarRules;

namespace SimulinkModelGenerator.Modeler.Builders.SystemLineBuilders
{
    internal class LinePathBuilder : ILinePath, IHorizontalPath, IVerticalPath
    {
        internal enum LinePathType
        {
            None,
            Up,
            Down,
            Left,
            Right
        }

        
        internal LinePath PathCombination { get; }

        internal LinePathBuilder()
        {
            PathCombination = new LinePath();
        }


        public IHorizontalPath GoUp()
        {
            PathCombination.SetFirstPath(LinePathType.Up);
            return this;
        }

        public IHorizontalPath GoDown()
        {
            PathCombination.SetFirstPath(LinePathType.Down);
            return this;
        }

        public IVerticalPath GoLeft()
        {
            PathCombination.SetFirstPath(LinePathType.Left);
            return this;
        }

        public IVerticalPath GoRight()
        {
            PathCombination.SetFirstPath(LinePathType.Right);
            return this;
        }


        public void ThanUp() => PathCombination.SetSecondPath(LinePathType.Up);

        public void ThanDown() => PathCombination.SetSecondPath(LinePathType.Down);

        public void ThanLeft() => PathCombination.SetSecondPath(LinePathType.Left);

        public void ThanRight() => PathCombination.SetSecondPath(LinePathType.Right);


        internal class LinePath
        {
            private LinePathType firstPathType;
            private LinePathType secondPathType;

            internal LinePath()
            {
                firstPathType = LinePathType.None;
                secondPathType = LinePathType.None;
            }

            internal void SetFirstPath(LinePathType type) => firstPathType = type;
            internal void SetSecondPath(LinePathType type) => secondPathType = type;

            internal bool IsStraight() => firstPathType == LinePathType.None && secondPathType == LinePathType.None;
            internal bool IsPartial() => (firstPathType == LinePathType.None && secondPathType != LinePathType.None) ||
                                         (firstPathType != LinePathType.None && secondPathType == LinePathType.None);
        }
    }
}
