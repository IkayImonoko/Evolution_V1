using OpenCvSharp;

namespace BearsMutabilitySimulatorLib;

public class BearsController(CoordinateSpace coordinateSpace, List<Bear> bears)
{
    private Bear? MakeChild(Bear parrentA, Bear parrentB)
    {
        var newBear = new Bear(coordinateSpace.BottomRight, parrentA.Color, parrentB.Color);
        var random = new Random();
        newBear.Position = new Point(
            parrentA.Position.X + random.Next(-20, 21),
            parrentA.Position.Y + random.Next(-20, 21)
        );
        parrentA.TimeToNextChildLeft = 730;
        parrentB.TimeToNextChildLeft = 730;
        
        return coordinateSpace.CanMoveTo(newBear.Position) ? newBear : null;
    }
    
    private void Move(Bear bear)
    {
        if (bear.TimeToNextChildLeft > 0)
        {
            bear.TimeToNextChildLeft--;
        }

        if (bear.Lifetime <= 0) return;
        bear.Lifetime--;
        var random = new Random();
        var stepDirection = random.Next(0, 9);
        var stepLength = random.Next(0, 9);
        var step = new Step(bear.Position);
        var newPosition = step.MakeStep((Direction)stepDirection, stepLength);

        while (!coordinateSpace.CanMoveTo(newPosition))
        {
            stepDirection = random.Next(0, 9);
            newPosition = step.MakeStep((Direction)stepDirection, stepLength);
        }
            
        bear.Position = newPosition;
    }
    
    private void CheckCollisionsAndSpawnBears()
    {
        for (var i = 0; i < bears.Count - 1; i++)
        {
            for (var j = i + 1; j < bears.Count; j++)
            {
                var bear1 = bears[i];
                var bear2 = bears[j];
                var distance = GetDistanceBetweenBears(bear1, bear2);
                if (!(distance < 6) ||
                    bear1.TimeToNextChildLeft != 0 ||
                    bear2.TimeToNextChildLeft != 0) continue;
                var newBear = MakeChild(bear1, bear2);
                if (newBear != null)
                {
                    bears.Add(newBear); 
                }
                break;
            }
        }
    }
    
    private static double GetDistanceBetweenBears(Bear bear1, Bear bear2)
    {
        double deltaX = bear1.Position.X - bear2.Position.X;
        double deltaY = bear1.Position.Y - bear2.Position.Y;
        
        return Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
    }

    public void RunOneIteration()
    {
        bears.RemoveAll(b => b.Lifetime == 0);
        bears.ForEach(Move);
        CheckCollisionsAndSpawnBears();
    }
    
    
}