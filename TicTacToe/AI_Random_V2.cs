using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;


public class AI_Random_V2 : AI_Random
{
    new public int DrawMarker(SortedList<int, char> list)
    {
        int boardPosition = 0;
        var coords = new int[2] {0, 0};
        int x = 0;
        int y = 0;
        var rnd = new Random();
        int rndNumber = rnd.Next(1, 10);

        //Replaces the opponents marker with 'x'.
        for (int ii = 1; ii < 10; ++ii)
        {
            if (list[ii] != ' ' || list[ii] != this.Marker) { list[ii] = 'x'; }
        }

        if (list[1] == 'x' && list[2] == 'x') { coords = PosToCoords(3); }
        if (list[1] == 'x' && list[3] == 'x') { coords = PosToCoords(2); }
        if (list[2] == 'x' && list[3] == 'x') { coords = PosToCoords(1); }

        if (list[4] == 'x' && list[5] == 'x') { coords = PosToCoords(6); }
        if (list[4] == 'x' && list[6] == 'x') { coords = PosToCoords(5); }
        if (list[5] == 'x' && list[6] == 'x') { coords = PosToCoords(4); }

        if (list[7] == 'x' && list[8] == 'x') { coords = PosToCoords(9); }
        if (list[7] == 'x' && list[9] == 'x') { coords = PosToCoords(8); }
        if (list[8] == 'x' && list[9] == 'x') { coords = PosToCoords(7); }

        if (list[1] == 'x' && list[4] == 'x') { coords = PosToCoords(7); }
        if (list[1] == 'x' && list[7] == 'x') { coords = PosToCoords(4); }
        if (list[4] == 'x' && list[7] == 'x') { coords = PosToCoords(1); }

        if (list[2] == 'x' && list[5] == 'x') { coords = PosToCoords(8); }
        if (list[2] == 'x' && list[8] == 'x') { coords = PosToCoords(5); }
        if (list[5] == 'x' && list[8] == 'x') { coords = PosToCoords(2); }

        if (list[3] == 'x' && list[6] == 'x') { coords = PosToCoords(9); }
        if (list[3] == 'x' && list[9] == 'x') { coords = PosToCoords(6); }
        if (list[6] == 'x' && list[9] == 'x') { coords = PosToCoords(3); }

        if (list[1] == 'x' && list[5] == 'x') { coords = PosToCoords(9); }
        if (list[1] == 'x' && list[9] == 'x') { coords = PosToCoords(5); }
        if (list[5] == 'x' && list[9] == 'x') { coords = PosToCoords(1); }

        if (list[3] == 'x' && list[5] == 'x') { coords = PosToCoords(7); }
        if (list[3] == 'x' && list[7] == 'x') { coords = PosToCoords(5); }
        if (list[7] == 'x' && list[5] == 'x') { coords = PosToCoords(3); }

        if (coords[0] == 0)
        {
            //Loop until it finds an empty space on the board
            while (list[rndNumber] != ' ')
            {
                rndNumber = rnd.Next(1, 10);
            }

            coords = PosToCoords(rndNumber);
            boardPosition = rndNumber;
        }
        x = coords[0];
        y = coords[1];
        
        //MÅSTE LÄGGA TILL BOARDPOSITION IFALL DEN INTE KÖR WHILE-LOOPEN


        Thread.Sleep(1000);

        //Draws the marker
        Draw(x, y);

        //Return bordPosition for the Board-class to mark that space as occupied.
        return boardPosition;
        
    }
    public AI_Random_V2(string name, char marker)
        : base(name, marker)
    {
        Type = "Computer2";
    }
}
