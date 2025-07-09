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
        Point newPosition = direction switch
        {
            Direction.Center => StartingPosition,
            Direction.TopLeft => new Point(StartingPosition.X - stepLength, StartingPosition.Y - stepLength),
            Direction.TopMiddle => new Point(StartingPosition.X, StartingPosition.Y - stepLength),
            Direction.TopRight => new Point(StartingPosition.X + stepLength, StartingPosition.Y - stepLength),
            Direction.Left => new Point(StartingPosition.X - stepLength, StartingPosition.Y),
            Direction.Right => new Point(StartingPosition.X + stepLength, StartingPosition.Y),
            Direction.BottomLeft => new Point(StartingPosition.X - stepLength, StartingPosition.Y + stepLength),
            Direction.BottomMiddle => new Point(StartingPosition.X, StartingPosition.Y + stepLength),
            Direction.BottomRight => new Point(StartingPosition.X + stepLength, StartingPosition.Y + stepLength),
            _ => throw new ArgumentOutOfRangeException(nameof(direction), direction, null)
        };

        return newPosition;
    }
}