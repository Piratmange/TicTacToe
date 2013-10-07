using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;


public class AI_Random : Player
{
    public int DrawMarker(SortedList<int, char> list)
    {
        int boardPosition = 0;
        var coords = new int[2];
        int x = 0;
        int y = 0;
        var rnd = new Random();
        int rndNumber = rnd.Next(1, 10);

        //Loop until it finds an empty space on the board
        while (list[rndNumber] != ' ')
        {
            rndNumber = rnd.Next(1, 10);
        }

        coords = PosToCoords(rndNumber);
        x = coords[0];
        y = coords[1];
        boardPosition = rndNumber;

        Thread.Sleep(1000);

        Draw(x, y);

        //Return bordPosition for the Board-class to mark that space as occupied.
        return boardPosition;
    }
    public void Draw(int x, int y)
    {
        Console.SetCursorPosition(x - 1, y - 1);
        Console.Write("{0}{0}{0}", Marker);
        Console.SetCursorPosition(x - 1, y);
        Console.Write("{0} {0}", Marker);
        Console.SetCursorPosition(x - 1, y + 1);
        Console.Write("{0}{0}{0}", Marker);

    }
    //Translate position (1-9) to coordinates on the board.
    public int[] PosToCoords(int pos)
    {
        var coords = new int[2];
        if (pos == 1) { coords[0] = 3; coords[1] = 2; }
        if (pos == 2) { coords[0] = 9; coords[1] = 2; }
        if (pos == 3) { coords[0] = 15; coords[1] = 2; }
        if (pos == 4) { coords[0] = 3; coords[1] = 6; }
        if (pos == 5) { coords[0] = 9; coords[1] = 6; }
        if (pos == 6) { coords[0] = 15; coords[1] = 6; }
        if (pos == 7) { coords[0] = 3; coords[1] = 10; }
        if (pos == 8) { coords[0] = 9; coords[1] = 10; }
        if (pos == 9) { coords[0] = 15; coords[1] = 10; }
        return coords;
    }
    public AI_Random(string name, char marker) : base(name, marker)
    {
        Type = "Computer1";
    }
}
