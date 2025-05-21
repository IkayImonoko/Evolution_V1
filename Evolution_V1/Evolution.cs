using System.Drawing;

namespace Evolution_V1;

internal class Evolution
{
    private Bear _bear = new Bear();
    private Habitat[] _habitats = new Habitat[4]
    {
        new Habitat("Ice", ConsoleColor.White, new Point(0,0)),
        new Habitat("Forest", ConsoleColor.Green, new Point(50,0)),
        new Habitat("Desert", ConsoleColor.Yellow, new Point(0,50)),
        new Habitat("Sea", ConsoleColor.Blue, new Point(50,50))
    };
    public void Run()
    {
        //Console.SetWindowSize(500, 500);
        //Console.SetBufferSize(500, 500);
        Console.Clear();
        foreach (Habitat habitat in _habitats)
        {
            habitat.Draw();
        }

        Console.ReadKey();
        
    }
}