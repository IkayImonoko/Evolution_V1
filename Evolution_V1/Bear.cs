using OpenCvSharp;


namespace Evolution_V1;

internal class Bear
{
    Scalar _color;
    public int Lifetime; //= 365 * 20;//days
    public Point Coordinates;
    public int ChildsAmount { get; set; }

    public Bear(Scalar colorA = default, Scalar colorB = default)
    {
        
        Random random = new Random();
        ChildsAmount = random.Next(0, 11);;
        Lifetime = random.Next(365 * 10, 365 * 50);
        int mutation = random.Next(1, 11);
        if (mutation == 1)
        {
            _color = new Scalar(random.Next(0, 256), random.Next(0, 256), random.Next(0, 256));
        }
        else
        {
            _color = new Scalar((colorA.Val0 + colorB.Val0) / 2, (colorA.Val1 + colorB.Val1) / 2, (colorA.Val2 + colorB.Val2) / 2);
        }
        
        Coordinates.X = random.Next(0, 800);//TODO Magic number - size of Main field
        Coordinates.Y = random.Next(0, 800);//
    }
    
    // public Bear(Scalar colorA, Scalar colorB)
    // {
    //     ChildsAmount = 10;
    //     _color = new Scalar((colorA.Val0 + colorB.Val0)/(double)2, (colorA.Val1 + colorB.Val1)/(double)2, (colorA.Val2 + colorB.Val2)/(double)2);
    // }

    public static Bear MakeChild(Scalar colorA, Scalar colorB)
    {
        return new Bear(colorA, colorB);
    }

    public void Draw(Mat mainField)
    {
        mainField.Circle(Coordinates.X, Coordinates.Y, 3, _color, -1);
        mainField.Circle(Coordinates.X, Coordinates.Y, 3, Scalar.Black, 1);
    }

    public void Move()
    {
        // Console.Clear();
        // Console.WriteLine(_lifetime);
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

            while (!CanMove(newCoordinates))
            {
                newCoordinates.X = 0;
                newCoordinates.Y = 0;
                stepDirection = random.Next(0, 9);
                step = new Step(Coordinates, stepLength);
                step.MakeStep((Direction)stepDirection);
                newCoordinates = step.Coordinates;
            }

            if (newCoordinates.X >=0 && newCoordinates.Y < 800)
            {
                Coordinates.X = newCoordinates.X;
                Coordinates.Y = newCoordinates.Y;
            }
            
        }
    }

    private bool CanMove(Point coordinates)
    {
        return coordinates is { X: >= 0 and < 800, Y: >= 0 and < 800 };
    }
    
    private static double GetDistanceBetweenBears(Bear bear1, Bear bear2)
    {
        double deltaX = bear1.Coordinates.X - bear2.Coordinates.X;
        double deltaY = bear1.Coordinates.Y - bear2.Coordinates.Y;
        return Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
    }
}