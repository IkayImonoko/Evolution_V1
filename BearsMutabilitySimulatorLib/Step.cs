using OpenCvSharp;

namespace BearsMutabilitySimulatorLib;

public class Step
{
    private Point StartingPosition { get;}
  

    public Step(Point startingPosition)
    {
        StartingPosition = startingPosition;
    }

    public Point MakeStep(Direction direction, int stepLength)
    {
        Point newPosition = default;
        switch (direction)
        {
            case Direction.Center:
                newPosition = StartingPosition;
                break;
            case Direction.TopLeft:
                newPosition = new Point(StartingPosition.X - stepLength, StartingPosition.Y - stepLength);
                break;
            case Direction.TopMiddle:
                newPosition = new Point(StartingPosition.X, StartingPosition.Y - stepLength);
                break;
            case Direction.TopRight:
                newPosition = new Point(StartingPosition.X + stepLength, StartingPosition.Y - stepLength);
                break;
            case Direction.Left:
                newPosition = new Point(StartingPosition.X - stepLength, StartingPosition.Y);
                break;
            case Direction.Right:
                newPosition = new Point(StartingPosition.X + stepLength, StartingPosition.Y);
                break;
            case Direction.BottomLeft:
                newPosition = new Point(StartingPosition.X - stepLength, StartingPosition.Y + stepLength);
                break;
            case Direction.BottomMiddle:
                newPosition = new Point(StartingPosition.X, StartingPosition.Y + stepLength);
                break;
            case Direction.BottomRight:
                newPosition = new Point(StartingPosition.X + stepLength, StartingPosition.Y + stepLength);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
        }
        
        return newPosition;
    }
}