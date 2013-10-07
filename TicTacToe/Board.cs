using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Board
{
    public int PosX { get; set; }
    public int PosY { get; set; }
    public SortedList<int, char> BoardTiles { get; set; }

    public Board()
    {
        PosX = 3;
        PosY = 2;
        BoardTiles = new SortedList<int, char>();

        for (int ii = 1; ii < 10; ++ii)
            BoardTiles.Add(ii, ' ');
    }
    //Draws the board, can exchange for a loop
    public string DrawBoard()
    {
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        return "╔═════╦═════╦═════╗\n║     ║     ║     ║\n║     ║     ║     ║\n║     ║     ║     ║\n╠═════╬═════╬═════╣\n║     ║     ║     ║\n║     ║     ║     ║\n║     ║     ║     ║\n╠═════╬═════╬═════╣\n║     ║     ║     ║\n║     ║     ║     ║\n║     ║     ║     ║\n╚═════╩═════╩═════╝\n";
    }

    //Translates Coordinates to Position (1-9)
    public int CoordsToPos(int x, int y)
    {
        if (x == 3 && y == 2) { return 1; }
        if (x == 9 && y == 2) { return 2; }
        if (x == 15 && y == 2) { return 3; }
        if (x == 3 && y == 6) { return 4; }
        if (x == 9 && y == 6) { return 5; }
        if (x == 15 && y == 6) { return 6; }
        if (x == 3 && y == 10) { return 7; }
        if (x == 9 && y == 10) { return 8; }
        if (x == 15 && y == 10) { return 9; }
        else { return 0; }
    }
    public bool EvaluateWin(Player player)
    {
        var BT = BoardTiles;
        var PM = player.Marker;

        if (BT[1].Equals(PM) && BT[2].Equals(PM) && BT[3].Equals(PM)) { return true; }
        if (BT[4].Equals(PM) && BT[5].Equals(PM) && BT[6].Equals(PM)) { return true; }
        if (BT[7].Equals(PM) && BT[8].Equals(PM) && BT[9].Equals(PM)) { return true; }
        if (BT[1].Equals(PM) && BT[4].Equals(PM) && BT[7].Equals(PM)) { return true; }
        if (BT[2].Equals(PM) && BT[5].Equals(PM) && BT[8].Equals(PM)) { return true; }
        if (BT[3].Equals(PM) && BT[6].Equals(PM) && BT[9].Equals(PM)) { return true; }
        if (BT[1].Equals(PM) && BT[5].Equals(PM) && BT[9].Equals(PM)) { return true; }
        if (BT[3].Equals(PM) && BT[5].Equals(PM) && BT[7].Equals(PM)) { return true; }
        else { return false; }
    }
    public void MoveOnBoard(Player player)
    {
        // putting text on the side instead of under the board
        Console.SetCursorPosition(25, 5);
        "Please move around with the arrowkeys".Echo();
        Console.SetCursorPosition(25, 6);
        "Place your marker using the enterkey".Echo();

        Console.SetCursorPosition(25, 8);
        Console.WriteLine("Playerturn: {0}                               ", player.Name);

        int boardPosition;
        Console.CursorLeft = 3;
        Console.CursorTop = 2;
        PosX = Console.CursorLeft;
        PosY = Console.CursorTop;

        //Moves the cursor for placement of marker (X or O)
        ConsoleKey conKey = ConsoleKey.NoName;
        while ((conKey = Console.ReadKey().Key) != ConsoleKey.Enter)
        {
            switch (conKey)
            {
                case ConsoleKey.UpArrow:
                    if (PosY != 2) PosY -= 4;
                    break;
                case ConsoleKey.DownArrow:
                    if (PosY != 10) PosY += 4;
                    break;
                case ConsoleKey.LeftArrow:
                    if (PosX != 3) PosX -= 6;
                    break;
                case ConsoleKey.RightArrow:
                    if (PosX != 15) PosX += 6;
                    break;
            }
            Console.SetCursorPosition(PosX, PosY);
        }

        boardPosition = CoordsToPos(PosX, PosY);

        if (this.BoardTiles[boardPosition] != ' ')
        {
            MoveOnBoard(player);
        }
        else
        {
            player.DrawMarker(PosX, PosY);
            this.BoardTiles[boardPosition] = player.Marker;
        }
    }
}
