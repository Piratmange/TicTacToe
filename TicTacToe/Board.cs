using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



public class Board
{
    //Temporarty property to alternate between X and O
    public bool Alternate { get; set; }
    public int PosX { get; set; }
    public int PosY { get; set; }

    public Board()
    {
        Alternate = true;
        PosX = 2;
        PosY = 2;
    }

    //Draws the board, can exchange for a loop
    public string DrawBoard()
    {
        return "+-----------+\n|   |   |   |\n|   |   |   |\n|   |   |   |\n|---+---+---|\n|   |   |   |\n|   |   |   |\n|   |   |   |\n|---+---+---|\n|   |   |   |\n|   |   |   |\n|   |   |   |\n+-----------+\n";
    }

    //Not sure if its "okay" with a loop inside a class-method or if the loop should be in the Main-program.
    public void MoveOnBoard()
    {
        while (true)
        {
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
            //Prints X and O to the board, can exchange for a loop
            if (Alternate)
            {
                Console.SetCursorPosition(PosX - 1, PosY - 1);
                Console.Write("x x");
                Console.SetCursorPosition(PosX - 1, PosY);
                Console.Write(" x ");
                Console.SetCursorPosition(PosX - 1, PosY + 1);
                Console.Write("x x");
                Alternate = false;
            }
            else
            {
                Console.SetCursorPosition(PosX - 1, PosY - 1);
                Console.Write("ooo");
                Console.SetCursorPosition(PosX - 1, PosY);
                Console.Write("o o");
                Console.SetCursorPosition(PosX - 1, PosY + 1);
                Console.Write("ooo");
                Alternate = true;
            }

        }
    }
}
