using OpenCvSharp;


namespace Evolution_V1;

internal class Bear
{
    private readonly Scalar _color;
    private Point _boardSize;
    public int Lifetime { get; private set; }
    public Point Position { get; private set; }
    public int TimeToNextChildLeft { get; private set; }
    // private static int _radius = 3;

    public Bear(Point boardSize, Scalar colorA = default, Scalar colorB = default)
    {
        _boardSize = boardSize;
        Random random = new Random();
        TimeToNextChildLeft = 730;
        Lifetime = random.Next(365 * 5, 365 * 10);
        var mutation = random.Next(1, 11);
        if (mutation == 1)
        {
            _color = new Scalar(random.Next(0, 256), random.Next(0, 256), random.Next(0, 256));
        }
        else
        {
            _color = new Scalar((colorA.Val0 + colorB.Val0) / 2, (colorA.Val1 + colorB.Val1) / 2, (colorA.Val2 + colorB.Val2) / 2);
        }

        Position = new Point(random.Next(0, boardSize.X), random.Next(0, boardSize.Y));
        
    }
    

    public static Bear? MakeChild(Bear parrentA, Bear parrentB)
    {
        var newBear = new Bear(parrentA._boardSize, parrentA._color, parrentB._color);
        var random = new Random();
        newBear.Position = new Point(
            parrentA.Position.X + random.Next(-20, 21),
            parrentA.Position.Y + random.Next(-20, 21)
        );
        parrentA.TimeToNextChildLeft = 730;
        parrentB.TimeToNextChildLeft = 730;

        return Evolution.CanMoveTo(newBear.Position) ? newBear : null;
    }

    // public void Draw(Mat mainField)
    // {
    //     mainField.Circle(Coordinates.X, Coordinates.Y, _radius, _color, -1);
    //     mainField.Circle(Coordinates.X, Coordinates.Y, _radius, Scalar.Black, 1);
    // }

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
            var step = new Step(Position, stepLength);
            step.MakeStep((Direction)stepDirection);
            newCoordinates = step.Coordinates;

            while (!Evolution.CanMoveTo(newCoordinates))
            {
                stepDirection = random.Next(0, 9);
                step = new Step(Position, stepLength);
                step.MakeStep((Direction)stepDirection);
                newCoordinates = step.Coordinates;
            }
            
            Position = newCoordinates;
            
        }
    }


    

}