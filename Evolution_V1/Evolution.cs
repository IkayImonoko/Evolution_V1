using OpenCvSharp;

namespace Evolution_V1;

internal class Evolution 
{
    private Bear _bear = new Bear();
    private static int _habitatLength = 400;
    private Habitat[] _habitats = new Habitat[4]
    {
        new Habitat("Ice", Scalar.White, new Point(0,0)),
        new Habitat("Forest", Scalar.Green, new Point(_habitatLength,0)),
        new Habitat("Desert", Scalar.Yellow, new Point(0,_habitatLength)),
        new Habitat("Sea", Scalar.Blue, new Point(_habitatLength,_habitatLength))
    };
    public void Run()
    {
        Habitat.Length = _habitatLength;
        var mainField = new Mat(_habitatLength * 2, _habitatLength * 2, MatType.CV_8UC3, Scalar.Red);
        
        foreach (Habitat habitat in _habitats)
        {
            habitat.Draw(mainField);
        }
        _bear.Draw(mainField);
        
        Cv2.ImShow("Evolution", mainField);
        Cv2.WaitKey(0);
        Cv2.DestroyAllWindows();
        Console.ReadKey();
        
    }
}