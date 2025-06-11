using OpenCvSharp;

namespace BearsMutabilitySimulatorLib;

public class CoordinateSpace
{
    public Point TopLeft { get; }
    public int Width { get; }
    public int Height { get; }

    public Point BottomRight
    {
        get
        {
            return new Point(TopLeft.X + Width - 1, TopLeft.Y + Height - 1);
        }
    }

    public CoordinateSpace(Point topLeft, int width, int height)
    {
        TopLeft = topLeft;
        Width = width;
        Height = height;
    }

    public bool CanMoveTo(Point newPosition)
    {
        return newPosition.X >= TopLeft.X && newPosition.X <= Width - 1 && newPosition.Y >= TopLeft.Y && newPosition.Y <= Height - 1;
    }
}