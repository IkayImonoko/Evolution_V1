using OpenCvSharp;


namespace Evolution_V1;

internal class Bear
{
    private readonly Scalar _color;
    public int Lifetime { get; private set; } //= 365 * 20;//days
    public Point Coordinates { get; private set; }
    public int TimeToNextChildLeft { get; private set; }

    public Bear(Scalar colorA = default, Scalar colorB = default)
    {
        
        Random random = new Random();
        TimeToNextChildLeft = 730;
        Lifetime = random.Next(365 * 5, 365 * 10);
        int mutation = random.Next(1, 11);
        if (mutation == 1)
        {
            _color = new Scalar(random.Next(0, 256), random.Next(0, 256), random.Next(0, 256));
        }
        else
        {
            _color = new Scalar((colorA.Val0 + colorB.Val0) / 2, (colorA.Val1 + colorB.Val1) / 2, (colorA.Val2 + colorB.Val2) / 2);
        }

        Coordinates = new Point(random.Next(0, 800), random.Next(0, 800));
        
    }
    

    public static Bear? MakeChild(Bear parrentA, Bear parrentB)
    {
        Bear newBear = new Bear(parrentA._color, parrentB._color);
        Random random = new Random();
        newBear.Coordinates = new Point(
            parrentA.Coordinates.X + random.Next(-20, 21),
            parrentA.Coordinates.Y + random.Next(-20, 21)
        );
        parrentA.TimeToNextChildLeft = 730;
        parrentB.TimeToNextChildLeft = 730;

        return Evolution.CanMoveTo(newBear.Coordinates) ? newBear : null;
    }

    public void Draw(Mat mainField)
    {
        mainField.Circle(Coordinates.X, Coordinates.Y, 3, _color, -1);
        mainField.Circle(Coordinates.X, Coordinates.Y, 3, Scalar.Black, 1);
    }

    public void Move()
    {
        if (TimeToNextChildLeft > 0)
        {
            TimeToNextChildLeft--;
        }
        if (Lifetime > 0)
        {
            Lifetime--;
            Random random = new Random();
            Point newCoordinates = new Point(0, 0);
            int stepDirection = random.Next(0, 9);
            int stepLength = random.Next(0, 9);
            var step = new Step(Coordinates, stepLength);
            step.MakeStep((Direction)stepDirection);
            newCoordinates = step.Coordinates;

            while (!Evolution.CanMoveTo(newCoordinates))
            {
                stepDirection = random.Next(0, 9);
                step = new Step(Coordinates, stepLength);
                step.MakeStep((Direction)stepDirection);
                newCoordinates = step.Coordinates;
            }
            
            Coordinates = newCoordinates;
            
        }
    }


    

}