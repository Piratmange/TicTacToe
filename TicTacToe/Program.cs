using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

public class program
{

    public static void Main()
    {
        string P1 = Player.GetPlayerOne();
        string C1 = Player.GetCharOne();
        string P2 = Player.GetPlayerTwo();
        string C2 = Player.GetCharTwo();

        ("Hello and welcome " + P1 +" and " + P2).Echo();
        ("Press any key to continue to game TIC-TAC-TOE ").Echo();
        Console.ReadKey();
        Console.Clear();

        Console.WindowHeight = 30;
        Console.WindowWidth = 50;

        var PlayerOne = new Player(P1, C1);
        var PlayerTwo = new Player(P2, C2);
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