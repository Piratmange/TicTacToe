using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;


public class AI_Random_V2 : AI_Random
{
    new public int DrawMarker(SortedList<int, char> list)
    {
        var tempList = new SortedList<int, char>(list);
        int boardPosition = 0;
        var coords = new int[2] { 0, 0 };
        int x = 0;
        int y = 0;
        var rnd = new Random();
        int rndNumber = rnd.Next(1, 10);

        //Replaces the opponents marker with 'u'.
        for (int ii = 1; ii < 10; ++ii)
        {
            if (tempList[ii] == this.Marker) { continue; }
            else if (tempList[ii] != ' ') { tempList[ii] = 'u'; }
        }

        //check if you have 2 in a row and the 3 spot is free, if so, win!
        boardPosition = CheckForTwo(tempList, this.Marker);

        //check if your opponent have 2 in a row and the 3 spot is free, if so, block!
        if (boardPosition == 0) { boardPosition = CheckForTwo(tempList, 'u'); }

        //if you have gotten a positionvalue from one of the previous 2 methods.
        if (boardPosition != 0) { coords = PosToCoords(boardPosition); }

        //if either player have 2 in a row, play random.
        if (boardPosition == 0)
        {
            //Loop until it finds an empty space on the board
            while (tempList[rndNumber] != ' ')
            {
                rndNumber = rnd.Next(1, 10);
            }

            coords = PosToCoords(rndNumber);
            boardPosition = rndNumber;
        }
        x = coords[0];
        y = coords[1];

        Thread.Sleep(1000);

        //Draws the marker

        Draw(x, y);

        //Return bordPosition for the Board-class to mark that space as occupied.
        return boardPosition;
    }
    public int CheckForTwo(SortedList<int, char> tempList, char marker)
    {
        if (tempList[1] == marker && tempList[2] == marker && tempList[3] == ' ') { return 3; }
        else if (tempList[1] == marker && tempList[3] == marker && tempList[2] == ' ') { return 2; }
        else if (tempList[2] == marker && tempList[3] == marker && tempList[1] == ' ') { return 1; }

        else if (tempList[4] == marker && tempList[5] == marker && tempList[6] == ' ') { return 6; }
        else if (tempList[4] == marker && tempList[6] == marker && tempList[5] == ' ') { return 5; }
        else if (tempList[5] == marker && tempList[6] == marker && tempList[4] == ' ') { return 4; }

        else if (tempList[7] == marker && tempList[8] == marker && tempList[9] == ' ') { return 9; }
        else if (tempList[7] == marker && tempList[9] == marker && tempList[8] == ' ') { return 8; }
        else if (tempList[8] == marker && tempList[9] == marker && tempList[6] == ' ') { return 7; }

        else if (tempList[1] == marker && tempList[4] == marker && tempList[7] == ' ') { return 7; }
        else if (tempList[1] == marker && tempList[7] == marker && tempList[4] == ' ') { return 4; }
        else if (tempList[4] == marker && tempList[7] == marker && tempList[1] == ' ') { return 1; }

        else if (tempList[2] == marker && tempList[5] == marker && tempList[8] == ' ') { return 8; }
        else if (tempList[2] == marker && tempList[8] == marker && tempList[5] == ' ') { return 5; }
        else if (tempList[5] == marker && tempList[8] == marker && tempList[2] == ' ') { return 2; }

        else if (tempList[3] == marker && tempList[6] == marker && tempList[9] == ' ') { return 9; }
        else if (tempList[3] == marker && tempList[9] == marker && tempList[6] == ' ') { return 6; }
        else if (tempList[6] == marker && tempList[9] == marker && tempList[3] == ' ') { return 3; }

        else if (tempList[1] == marker && tempList[5] == marker && tempList[9] == ' ') { return 9; }
        else if (tempList[1] == marker && tempList[9] == marker && tempList[5] == ' ') { return 5; }
        else if (tempList[5] == marker && tempList[9] == marker && tempList[1] == ' ') { return 1; }

        else if (tempList[3] == marker && tempList[5] == marker && tempList[7] == ' ') { return 7; }
        else if (tempList[3] == marker && tempList[7] == marker && tempList[5] == ' ') { return 5; }
        else if (tempList[7] == marker && tempList[5] == marker && tempList[3] == ' ') { return 3; }
        else { return 0; }
    }
    public AI_Random_V2(string name, char marker)
        : base(name, marker)
    {
        Type = "Computer2";
    }
}
