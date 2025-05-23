using OpenCvSharp;

namespace Evolution_V1;

internal class Evolution 
{
    private List<Bear> _bears;
    private static int _habitatLength;
    private Habitat[] _habitats;

    public Evolution(int bearsAmount)
    {
        _habitatLength = 400;
        _habitats = new Habitat[4]
        {
            new Habitat("Ice", Scalar.White, new Point(0, 0)),
            new Habitat("Forest", Scalar.Green, new Point(_habitatLength, 0)),
            new Habitat("Desert", Scalar.Yellow, new Point(0, _habitatLength)),
            new Habitat("Sea", Scalar.Blue, new Point(_habitatLength, _habitatLength))
        };
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
 
            Cv2.ImShow("Evolution", mainField);

            key = Cv2.WaitKey(100);
        }
    
        
        
        // Cv2.WaitKey(0);
        // Cv2.DestroyAllWindows();
        // Console.ReadKey();
        
    }
}