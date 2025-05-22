using OpenCvSharp;

namespace Evolution_V1;

public class Habitat
{
    public static int Length = 0;
    public Point TopLeft;
    public string Name;
    public Scalar Color;

    public Habitat(string name, Scalar color, Point topLeft)
    {
        Name = name;
        Color = color;
        TopLeft = topLeft;
    }

    public void Draw(Mat mainField)
    {
       var habitatPosition = new Rect(TopLeft.X, TopLeft.Y, Length, Length);
       mainField[habitatPosition].SetTo(Color);
    }
}