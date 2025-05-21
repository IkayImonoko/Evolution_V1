using System.Drawing;

namespace Evolution_V1;

public class Habitat
{
    private int _length = 50;
    public Point TopLeft;
    public string Name;
    public ConsoleColor Color;

    public Habitat(string name, ConsoleColor color, Point topLeft)
    {
        Name = name;
        Color = color;
        TopLeft = topLeft;
    }

    public void Draw()
    {
        for (int i = TopLeft.X; i < TopLeft.X + _length; i++)
        {
            for (int j = TopLeft.Y; j < TopLeft.Y + _length; j++)
            {
                Console.SetCursorPosition(i,j);
                Console.BackgroundColor = Color;
                Console.Write("1");
            }
        }

        Console.BackgroundColor = ConsoleColor.Black;
    }
}