using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Player
{
    public string Name { get; set; }
    public string Marker { get; set; }
    public string Type { get; set; }

    // Just some simple playerinputs
    public static string GetPlayerOne()
    {
        Console.WriteLine("Name of player?");
        return Console.ReadLine();
    }
    public static string GetCharOne()
    {
        Console.WriteLine("What char do you want, either a letter or a number?");
        return Console.ReadLine();
    }
    public Player(string name, string marker)
    {
        Name = name;
        Marker = marker;
        Type = "Human";
    }
    public void DrawMarker(int x, int y)
    {
        // Drawing the Cursor depending on playerturn
        // and chosen char
        Console.SetCursorPosition(x - 1, y - 1);
        Console.Write("{0}{0}{0}", Marker);
        Console.SetCursorPosition(x - 1, y);
        Console.Write("{0} {0}", Marker);
        Console.SetCursorPosition(x - 1, y + 1);
        Console.Write("{0}{0}{0}", Marker);
    }
}

