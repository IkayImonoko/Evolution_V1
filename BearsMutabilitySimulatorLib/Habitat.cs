using OpenCvSharp;

namespace BearsMutabilitySimulatorLib;

public class Habitat
{
    public readonly int Length;
    public Point TopLeft;
    public readonly string Name;
    public Scalar Color;

    public Habitat(string name, Scalar color, Point topLeft, int length)
    {
        Name = name;
        Color = color;
        TopLeft = topLeft;
        Length = length;
    }
    
}