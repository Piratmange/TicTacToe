using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Player
{
    public string Name { get; set; }
    public char Marker { get; set; }
    public List<int> MarkerOnBoard { get; set; }

    public Player(string name, char marker)
    {
        Name = name;
        Marker = marker;
        MarkerOnBoard = new List<int>();
    }
    public void DrawMarker(int x, int y)
    {
        Console.SetCursorPosition(x - 1, y - 1);
        Console.Write("{0}{0}{0}", Marker);
        Console.SetCursorPosition(x - 1, y);
        Console.Write("{0} {0}", Marker);
        Console.SetCursorPosition(x - 1, y + 1);
        Console.Write("{0}{0}{0}", Marker);
    }
}

