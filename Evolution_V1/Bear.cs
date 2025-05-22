using OpenCvSharp;


namespace Evolution_V1;

internal class Bear
{
    Scalar _color;
    public int Lifetime = 365 * 20;//days
    public Point Coordinates;

    public Bear()
    { 
        Random random = new Random();
        _color = new Scalar(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255));
        Coordinates.X = random.Next(0, 800);//TODO Magic number - size of Main field
        Coordinates.Y = random.Next(0, 800);//
    }
    
    public Bear(Scalar colorA, Scalar colorB)
    { 
        _color = new Scalar((colorA.Val0 + colorB.Val0)/(double)2, (colorA.Val1 + colorB.Val1)/(double)2, (colorA.Val2 + colorB.Val2)/(double)2);
    }

    public static Bear MakeChild(Scalar colorA, Scalar colorB)
    {
        return new Bear(colorA, colorB);
    }

    public void Draw(Mat mainField)
    {
        mainField.Circle(Coordinates.X, Coordinates.Y, 3, _color, -1);
        mainField.Circle(Coordinates.X, Coordinates.Y, 3, Scalar.Black, 1);
    }
}