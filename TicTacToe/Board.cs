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

    public void MoveOnBoard(Player player)
    {
        int position = 0;
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
        //Translates coordinates to positions (1-9)
        if (PosX == 2 && PosY == 2) { position = 1; }
        if (PosX == 6 && PosY == 2) { position = 2; }
        if (PosX == 10 && PosY == 2) { position = 3; }
        if (PosX == 2 && PosY == 6) { position = 4; }
        if (PosX == 6 && PosY == 6) { position = 5; }
        if (PosX == 10 && PosY == 6) { position = 6; }
        if (PosX == 2 && PosY == 10) { position = 7; }
        if (PosX == 6 && PosY == 10) { position = 8; }
        if (PosX == 10 && PosY == 10) { position = 9; }


        //Checks if the move if valid, if not, restarts the method. (prolly better with a while-loop but im tired)
        if (!ValidMove(position))
        {
            MoveOnBoard(player);
        }
        //Checks if the move is valid and which marker the player has. Also adds the position to the...
        //... players personal "marker-map" to remember the location of the markers.
        else if (ValidMove(position) && player.Marker == 'X')
        {
            Console.SetCursorPosition(PosX - 1, PosY - 1);
            Console.Write("X X");
            Console.SetCursorPosition(PosX - 1, PosY);
            Console.Write(" X ");
            Console.SetCursorPosition(PosX - 1, PosY + 1);
            Console.Write("X X");
            player.MarkerOnBoard.Add(position);

        }
        else if (ValidMove(position) && player.Marker == 'O')
        {
            Console.SetCursorPosition(PosX - 1, PosY - 1);
            Console.Write("OOO");
            Console.SetCursorPosition(PosX - 1, PosY);
            Console.Write("O O");
            Console.SetCursorPosition(PosX - 1, PosY + 1);
            Console.Write("OOO");
            player.MarkerOnBoard.Add(position);

        }
        //Adds the "Valid position" to the Board-List to mark up occupied markerspaces.
        OccupiedBoardSpaces.Add(position);

    }
    public bool ValidMove(int position)
    {

        return (!OccupiedBoardSpaces.Contains(position));

    }
}
