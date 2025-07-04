using BearsMutabilitySimulatorLib;
using OpenCvSharp;

namespace BearsMutabilitySimulatorGUI;

public class BearsMutabilitySimulator
{
    public static void Run()
    {
        const int bearsAmount = 50;
        const int habitatLenght = 400;
        var coordinateSpace = new CoordinateSpace(new Point(0,0), habitatLenght * 2, habitatLenght * 2);
        Habitat[] habitats =
        [
            new Habitat("Ice", Scalar.White, new Point(0, 0), habitatLenght),
            new Habitat("Forest", Scalar.Green, new Point(habitatLenght, 0),habitatLenght),
            new Habitat("Desert", Scalar.Yellow, new Point(0, habitatLenght),habitatLenght),
            new Habitat("Sea", Scalar.Blue, new Point(habitatLenght, habitatLenght),habitatLenght)
        ];
        var bears = new List<Bear>(bearsAmount);
        bears.AddRange(Enumerable.Range(0, bearsAmount).Select(_ => new Bear(coordinateSpace.BottomRight)));
        var bearController = new BearsController(coordinateSpace, bears);
        var simulationRender = new SimulationRender(coordinateSpace, bears, habitats);

        var key = 0;
        while (key != 27)
        {
            bearController.RunOneIteration();
            simulationRender.Render();
            key = Cv2.WaitKey(100);
        }
    }
}