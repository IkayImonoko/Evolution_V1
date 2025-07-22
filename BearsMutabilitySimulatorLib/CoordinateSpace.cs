using OpenCvSharp;

namespace BearsMutabilitySimulatorLib;

public class CoordinateSpace(Point topLeft, int width, int height)
{
    public Point TopLeft { get; } = topLeft;
    public int Width { get; } = width;
    public int Height { get; } = height;

    public Point BottomRight => new(TopLeft.X + Width - 1, TopLeft.Y + Height - 1);

    public bool CanMoveTo(Point newPosition)
    {
        return newPosition.X >= TopLeft.X && newPosition.X <= Width - 1 && newPosition.Y >= TopLeft.Y && newPosition.Y <= Height - 1;
    }
}