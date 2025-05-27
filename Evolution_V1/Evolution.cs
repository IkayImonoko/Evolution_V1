using OpenCvSharp;

namespace Evolution_V1;

internal class Evolution 
{
    private List<Bear> _bears;
    private static int _habitatLength;
    private Habitat[] _habitats;

    public static bool CanMoveTo(Point newCoordinates)
    {
        return newCoordinates is { X: >= 0 and < 800, Y: >= 0 and < 800 };
    }
    public static double GetDistanceBetweenBears(Bear bear1, Bear bear2)
    {
        double deltaX = bear1.Coordinates.X - bear2.Coordinates.X;
        double deltaY = bear1.Coordinates.Y - bear2.Coordinates.Y;
        return Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
    }
    public Evolution(int bearsAmount)
    {
        _habitatLength = 400;
        _habitats =
        [
            new Habitat("Ice", Scalar.White, new Point(0, 0)),
            new Habitat("Forest", Scalar.Green, new Point(_habitatLength, 0)),
            new Habitat("Desert", Scalar.Yellow, new Point(0, _habitatLength)),
            new Habitat("Sea", Scalar.Blue, new Point(_habitatLength, _habitatLength))
        ];
        _bears = new List<Bear>(bearsAmount);
        _bears.AddRange(Enumerable.Range(0, bearsAmount).Select(_ => new Bear()));
    }

    public void Run()
    {
        Habitat.Length = _habitatLength;
        var mainField = new Mat(_habitatLength * 2, _habitatLength * 2, MatType.CV_8UC3, Scalar.Red);

        int key = 0;
        while (key != 27)
        {
            foreach (Habitat habitat in _habitats)
            {
                habitat.Draw(mainField);
            }

            _bears.RemoveAll(b => b.Lifetime == 0);
            _bears.ForEach(b => b.Draw(mainField));
            _bears.ForEach(b => b.Move());
            CheckCollisionsAndSpawnBears();
            Console.Clear();
            Console.WriteLine(_bears.Count);
            Cv2.ImShow("Evolution", mainField);

            key = Cv2.WaitKey(100);
        }
        
    }
    
    private void CheckCollisionsAndSpawnBears()
    {
        for (int i = 0; i < _bears.Count - 1; i++)
        {
            for (int j = i + 1; j < _bears.Count; j++)
            {
                Bear bear1 = _bears[i];
                Bear bear2 = _bears[j];
                double distance = GetDistanceBetweenBears(bear1, bear2);
                if (distance < 6 && 
                    bear1.TimeToNextChildLeft == 0 && 
                    bear2.TimeToNextChildLeft == 0)
                {

                    var newBear = Bear.MakeChild(bear1, bear2);
                    if (newBear != null)
                    {
                        _bears.Add(newBear); 
                    }
                    break;
                   
                }
            }
        }
    }
}