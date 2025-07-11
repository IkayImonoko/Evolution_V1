using OpenCvSharp;

namespace BearsMutabilitySimulatorLib;

public class Bear
{
    public Scalar Color { get; }
    public Point MaximumAllowablePosition { get; }
    public int Lifetime { get; set; }
    public Point Position { get; set; }
    public int TimeToNextChildLeft { get; set; }

    public Bear(Point maximumAllowablePosition, Scalar colorA = default, Scalar colorB = default)
    {
        MaximumAllowablePosition = maximumAllowablePosition;
        var random = new Random();
        TimeToNextChildLeft = 730;
        Lifetime = random.Next(365 * 5, 365 * 10);
        var mutation = random.Next(1, 11);
        Color = mutation == 1 ? new Scalar(random.Next(0, 256), random.Next(0, 256), random.Next(0, 256)) : 
            new Scalar((colorA.Val0 + colorB.Val0) / 2, (colorA.Val1 + colorB.Val1) / 2, (colorA.Val2 + colorB.Val2) / 2);

        Position = new Point(random.Next(0, maximumAllowablePosition.X), random.Next(0, maximumAllowablePosition.Y));
        
    }
    
}