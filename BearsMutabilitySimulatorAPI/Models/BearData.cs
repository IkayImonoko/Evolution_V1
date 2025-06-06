namespace BearsMutabilitySimulatorAPI.Models;

public class BearData
{
    public double[] Color { get; set;}
    public double[] MaximumAllowablePosition { get; set;}
    public int Lifetime { get; set; }
    public double[] Position { get; set; }
    public int TimeToNextChildLeft { get; set; }
}