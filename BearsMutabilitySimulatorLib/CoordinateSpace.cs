using OpenCvSharp;

namespace BearsMutabilitySimulatorLib;

public class CoordinateSpace
{
    private Point _topLeft;
    public int Width { get; }
    public int Height { get; }

    public Point BottomRight
    {
        get
        {
            return new Point(_topLeft.X + Width - 1, _topLeft.Y + Height - 1);
        }
    }

    public CoordinateSpace(Point topLeft, int width, int height)
    {
        _topLeft = topLeft;
        Width = width;
        Height = height;
    }

    public bool CanMoveTo(Point newPosition)
    {
        return newPosition.X >= _topLeft.X && newPosition.X <= Width - 1 && newPosition.Y >= _topLeft.Y && newPosition.Y <= Height - 1;
    }
}