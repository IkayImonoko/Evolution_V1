using OpenCvSharp;

namespace BearsMutabilitySimulatorLib;

public class Habitat
{
    public int Length;
    public Point TopLeft;
    public string Name;
    public Scalar Color;

    public Habitat(string name, Scalar color, Point topLeft, int length)
    {
        Name = name;
        Color = color;
        TopLeft = topLeft;
        Length = length;
    }

    // public void Draw(Mat mainField)
    // {
    //    var habitatPosition = new Rect(TopLeft.X, TopLeft.Y, Length, Length);
    //    mainField[habitatPosition].SetTo(Color);
    // }
}