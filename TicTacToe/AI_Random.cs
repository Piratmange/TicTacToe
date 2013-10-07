using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class AI_Random : Player
{
    new public void DrawMarker(int x, int y)
    {
        "ete".Echo();
        // Drawing the Cursor depending on playerturn
        // and chosen char
        Console.SetCursorPosition(x - 1, y - 1);
        Console.Write("{0}{0}{0}", Marker);
        Console.SetCursorPosition(x - 1, y);
        Console.Write("{0} {0}", Marker);
        Console.SetCursorPosition(x - 1, y + 1);
        Console.Write("{0}{0}{0}", Marker);
    }
    public AI_Random(string name, char marker) : base(name, marker)
    {
        Type = "Computer";
    }
}
