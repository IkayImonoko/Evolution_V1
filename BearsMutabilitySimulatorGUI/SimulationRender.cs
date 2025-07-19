using System.Security.Cryptography.X509Certificates;
using BearsMutabilitySimulatorLib;
using OpenCvSharp;

namespace BearsMutabilitySimulatorGUI;

public class SimulationRender(CoordinateSpace coordinateSpace, List<Bear> bears, Habitat[] habitats)
{
    private readonly Mat _mainField = new(coordinateSpace.Height, coordinateSpace.Width, MatType.CV_8UC3, Scalar.Red);

    public void Render()
    {
        foreach (var habitat in habitats)
        {
            var habitatPosition = new Rect(habitat.TopLeft.X, habitat.TopLeft.Y, habitat.Length, habitat.Length);
            _mainField[habitatPosition].SetTo(habitat.Color);
        }
        bears.ForEach(b =>
        {
            _mainField.Circle(b.Position.X, b.Position.Y, 3, b.Color, -1);
            _mainField.Circle(b.Position.X, b.Position.Y, 3, Scalar.Black, 1);
        });
        Cv2.ImShow("Evolution", _mainField);
    }
}