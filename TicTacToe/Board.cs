using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Board
{
    public int PosX { get; set; }
    public int PosY { get; set; }
    public List<int> OccupiedBoardSpaces { get; set; } //Which tiles are occupied

    public Board()
    {
        PosX = 2;
        PosY = 2;
        OccupiedBoardSpaces = new List<int>() { 0 };
    }
    //Draws the board, can exchange for a loop
    public string DrawBoard()
    {
        return "+-----------+\n|   |   |   |\n|   |   |   |\n|   |   |   |\n|---+---+---|\n|   |   |   |\n|   |   |   |\n|   |   |   |\n|---+---+---|\n|   |   |   |\n|   |   |   |\n|   |   |   |\n+-----------+\n";
    }
    //Translates Coordinates to Position (1-9)
    public int CoordsToPos(int x, int y)
    {
        if (x == 2 && y == 2) { return 1; }
        if (x == 6 && y == 2) { return 2; }
        if (x == 10 && y == 2) { return 3; }
        if (x == 2 && y == 6) { return 4; }
        if (x == 6 && y == 6) { return 5; }
        if (x == 10 && y == 6) { return 6; }
        if (x == 2 && y == 10) { return 7; }
        if (x == 6 && y == 10) { return 8; }
        if (x == 10 && y == 10) { return 9; }
        else { return 0; }
    }
    public bool EvaluateWin(Player player)
    {
        var p1 = player.MarkerOnBoard;
        if (p1.Contains(1) && p1.Contains(2) && p1.Contains(3)) { return true; }
        if (p1.Contains(4) && p1.Contains(5) && p1.Contains(6)) { return true; }
        if (p1.Contains(7) && p1.Contains(8) && p1.Contains(9)) { return true; }
        if (p1.Contains(1) && p1.Contains(4) && p1.Contains(7)) { return true; }
        if (p1.Contains(2) && p1.Contains(5) && p1.Contains(8)) { return true; }
        if (p1.Contains(3) && p1.Contains(6) && p1.Contains(9)) { return true; }
        if (p1.Contains(1) && p1.Contains(5) && p1.Contains(9)) { return true; }
        if (p1.Contains(7) && p1.Contains(5) && p1.Contains(3)) { return true; }
        else { return false; }
    }
    public void MoveOnBoard(Player player)
    {
        Console.SetCursorPosition(0, 15);
        Console.WriteLine("Playerturn: {0}                               ", player.Name);

        int boardPosition;
        Console.CursorLeft = 2;
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
                    if (PosX != 2) PosX -= 4;
                    break;
                case ConsoleKey.RightArrow:
                    if (PosX != 10) PosX += 4;
                    break;
            }
            Console.SetCursorPosition(PosX, PosY);
        }

        boardPosition = CoordsToPos(PosX, PosY);

        if (this.OccupiedBoardSpaces.Contains(boardPosition))
        {
            MoveOnBoard(player);
        }
        else
        {
            player.DrawMarker(PosX, PosY);
            player.MarkerOnBoard.Add(boardPosition);
            this.OccupiedBoardSpaces.Add(boardPosition);
        }
    }
}
