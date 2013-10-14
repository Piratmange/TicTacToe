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
<<<<<<< HEAD
            else if (tempList[ii] != ' ') { tempList[ii] = 'u'; }
=======
            else if (tempList[ii] != ' ') { tempList[ii] = 'x'; }
>>>>>>> c5d61e3e0f97674da5fac5476662a92b86b16a47
        }
        //for (int ii = 1; ii < 10; ++ii)
        //{
        //    Console.WriteLine(tempList[ii]);
        //}

<<<<<<< HEAD
        //check if you have 2 in a row and the 3 spot is free, if so, win!
        boardPosition = CheckForTwo(tempList, this.Marker);

        //check if your opponent have 2 in a row and the 3 spot is free, if so, block!
        if (boardPosition == 0) { boardPosition = CheckForTwo(tempList, 'u'); }

        //if you have gotten a positionvalue from one of the previous 2 methods.
        if (boardPosition != 0) { coords = PosToCoords(boardPosition); }

        //if either player have 2 in a row, play random.
        if (boardPosition == 0)
=======
        if (tempList[1] == 'x' && tempList[2] == 'x' && tempList[3] == ' ') { coords = PosToCoords(3); boardPosition = 3; }
        if (tempList[1] == 'x' && tempList[3] == 'x' && tempList[2] == ' ') { coords = PosToCoords(2); boardPosition = 2; }
        if (tempList[2] == 'x' && tempList[3] == 'x' && tempList[1] == ' ') { coords = PosToCoords(1); boardPosition = 1; }

        if (tempList[4] == 'x' && tempList[5] == 'x' && tempList[6] == ' ') { coords = PosToCoords(6); boardPosition = 6; }
        if (tempList[4] == 'x' && tempList[6] == 'x' && tempList[5] == ' ') { coords = PosToCoords(5); boardPosition = 5; }
        if (tempList[5] == 'x' && tempList[6] == 'x' && tempList[4] == ' ') { coords = PosToCoords(4); boardPosition = 4; }

        if (tempList[7] == 'x' && tempList[8] == 'x' && tempList[9] == ' ') { coords = PosToCoords(9); boardPosition = 9; }
        if (tempList[7] == 'x' && tempList[9] == 'x' && tempList[8] == ' ') { coords = PosToCoords(8); boardPosition = 8; }
        if (tempList[8] == 'x' && tempList[9] == 'x' && tempList[7] == ' ') { coords = PosToCoords(7); boardPosition = 7; }

        if (tempList[1] == 'x' && tempList[4] == 'x' && tempList[7] == ' ') { coords = PosToCoords(7); boardPosition = 7; }
        if (tempList[1] == 'x' && tempList[7] == 'x' && tempList[4] == ' ') { coords = PosToCoords(4); boardPosition = 4; }
        if (tempList[4] == 'x' && tempList[7] == 'x' && tempList[1] == ' ') { coords = PosToCoords(1); boardPosition = 1; }

        if (tempList[2] == 'x' && tempList[5] == 'x' && tempList[8] == ' ') { coords = PosToCoords(8); boardPosition = 8; }
        if (tempList[2] == 'x' && tempList[8] == 'x' && tempList[5] == ' ') { coords = PosToCoords(5); boardPosition = 5; }
        if (tempList[5] == 'x' && tempList[8] == 'x' && tempList[2] == ' ') { coords = PosToCoords(2); boardPosition = 2; }

        if (tempList[3] == 'x' && tempList[6] == 'x' && tempList[9] == ' ') { coords = PosToCoords(9); boardPosition = 9; }
        if (tempList[3] == 'x' && tempList[9] == 'x' && tempList[6] == ' ') { coords = PosToCoords(6); boardPosition = 6; }
        if (tempList[6] == 'x' && tempList[9] == 'x' && tempList[3] == ' ') { coords = PosToCoords(3); boardPosition = 3; }

        if (tempList[1] == 'x' && tempList[5] == 'x' && tempList[9] == ' ') { coords = PosToCoords(9); boardPosition = 9; }
        if (tempList[1] == 'x' && tempList[9] == 'x' && tempList[5] == ' ') { coords = PosToCoords(5); boardPosition = 5; }
        if (tempList[5] == 'x' && tempList[9] == 'x' && tempList[1] == ' ') { coords = PosToCoords(1); boardPosition = 1; }

        if (tempList[3] == 'x' && tempList[5] == 'x' && tempList[7] == ' ') { coords = PosToCoords(7); boardPosition = 7; }
        if (tempList[3] == 'x' && tempList[7] == 'x' && tempList[5] == ' ') { coords = PosToCoords(5); boardPosition = 5; }
        if (tempList[7] == 'x' && tempList[5] == 'x' && tempList[3] == ' ') { coords = PosToCoords(3); boardPosition = 3; }

        if (coords[0] == 0)
>>>>>>> c5d61e3e0f97674da5fac5476662a92b86b16a47
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
