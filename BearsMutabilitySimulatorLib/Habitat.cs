using OpenCvSharp;

namespace BearsMutabilitySimulatorLib;

public class Habitat(string name, Scalar color, Point topLeft, int length)
{
    public readonly int Length = length;
    public Point TopLeft = topLeft;
    public readonly string Name = name;
    public Scalar Color = color;
}