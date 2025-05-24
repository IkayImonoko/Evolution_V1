using System.ComponentModel.Design;
using OpenCvSharp;

namespace Evolution_V1;

public class Step
{
    public Point Coordinates { get; private set; }
    private int _stepLength;

    public Step(Point coordinates, int stepLength)
    {
        Coordinates = coordinates;
        _stepLength = stepLength;
    }

    public void MakeStep(Direction direction)
    {
            switch (direction)
            {
                case Direction.Center:
                    break;
                case Direction.TopLeft:
                    Coordinates = new Point(Coordinates.X - _stepLength, Coordinates.Y - _stepLength);
                    break;
                case Direction.TopMiddle:
                    Coordinates = new Point(Coordinates.X, Coordinates.Y - _stepLength);
                    break;
                case Direction.TopRight:
                    Coordinates = new Point(Coordinates.X + _stepLength, Coordinates.Y - _stepLength);
                    break;
                case Direction.Left:
                    Coordinates = new Point(Coordinates.X - _stepLength, Coordinates.Y);
                    break;
                case Direction.Right:
                    Coordinates = new Point(Coordinates.X + _stepLength, Coordinates.Y);
                    break;
                case Direction.BottomLeft:
                    Coordinates = new Point(Coordinates.X - _stepLength, Coordinates.Y + _stepLength);
                    break;
                case Direction.BottomMiddle:
                    Coordinates = new Point(Coordinates.X, Coordinates.Y + _stepLength);
                    break;
                case Direction.BottomRight:
                    Coordinates = new Point(Coordinates.X + _stepLength, Coordinates.Y + _stepLength);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
            }
    }
}