using System.Security.Cryptography.X509Certificates;
using BearsMutabilitySimulatorLib;
using OpenCvSharp;

namespace BearsMutabilitySimulatorGUI;

public class SimulationRender
{
    private readonly Mat _mainField;
    private readonly List<Bear> _bears;
    private readonly Habitat[] _habitats;

    public SimulationRender(CoordinateSpace coordinateSpace, List<Bear> bears, Habitat[] habitats)
    {
        _bears = bears;
        _habitats = habitats;
        _mainField = new Mat(coordinateSpace.Height, coordinateSpace.Width, MatType.CV_8UC3, Scalar.Red);

    }
    public void Render()
    {
        foreach (var habitat in _habitats)
        {
            var habitatPosition = new Rect(habitat.TopLeft.X, habitat.TopLeft.Y, habitat.Length, habitat.Length);
            _mainField[habitatPosition].SetTo(habitat.Color);
        }
        _bears.ForEach(b =>
        {
            _mainField.Circle(b.Position.X, b.Position.Y, 3, b.Color, -1);
            _mainField.Circle(b.Position.X, b.Position.Y, 3, Scalar.Black, 1);
        });
        Cv2.ImShow("Evolution", _mainField);
    }
}