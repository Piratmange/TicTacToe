using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

public class program
{
    public static void Main()
    {
        Console.WindowHeight = 30;
        Console.WindowWidth = 40;

        var PlayerOne = new Player("Simon", '/');
        var PlayerTwo = new Player("Rickard", 'O');
        var MyBoard = new Board();
        bool playerTurn = true;

        Console.WriteLine(MyBoard.DrawBoard());

        while (true)
        {
            var TempPlayer = playerTurn ? PlayerOne : PlayerTwo;
            playerTurn = !playerTurn;

            MyBoard.MoveOnBoard(TempPlayer);

            Console.SetCursorPosition(0, 15);
            if (MyBoard.EvaluateWin(TempPlayer))
            {
                Console.WriteLine("{0} WON!!!                                ", TempPlayer.Name);
                break;
            }
            else if (MyBoard.OccupiedBoardSpaces.Count == 10)
            {
                Console.WriteLine("It's a tie                                ");
                break;
            }
        }
    }
}