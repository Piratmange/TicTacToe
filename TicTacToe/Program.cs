using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

public class program
{
    public static void Main()
    {
        Console.WindowHeight = 30;
        Console.WindowWidth = 50;
        Console.WriteLine("Name of player 1?");
        string P1 = Console.ReadLine();
        Console.WriteLine("Name of player 2?");
        string P2 = Console.ReadLine();
        Console.WriteLine("Welcome " + P1 + " and " + P2);
        Console.WriteLine(P1 + " is X and " + P2 + " is O");
        Console.WriteLine("Press any key to start playing TicTacToe");
        Console.ReadKey();
        Console.Clear();

        var PlayerOne = new Player(P1, 'X');
        var PlayerTwo = new Player(P2, 'O');
        var MyBoard = new Board();

        Console.WriteLine(MyBoard.DrawBoard());

        //Temporary lists to make the code shorter. p1 instead of PlayerOne.MarkerOnBoard
        var p1 = PlayerOne.MarkerOnBoard;
        var p2 = PlayerTwo.MarkerOnBoard;
        while (true)
        {
            //Tis a silly place below!
            MyBoard.MoveOnBoard(PlayerOne);
            if (p1.Contains(1) && p1.Contains(2) && p1.Contains(3)) { PlayerOne.Iwon(); break; }
            if (p1.Contains(4) && p1.Contains(5) && p1.Contains(6)) { PlayerOne.Iwon(); break; }
            if (p1.Contains(7) && p1.Contains(8) && p1.Contains(9)) { PlayerOne.Iwon(); break; }
            if (p1.Contains(1) && p1.Contains(4) && p1.Contains(7)) { PlayerOne.Iwon(); break; }
            if (p1.Contains(2) && p1.Contains(5) && p1.Contains(8)) { PlayerOne.Iwon(); break; }
            if (p1.Contains(3) && p1.Contains(6) && p1.Contains(9)) { PlayerOne.Iwon(); break; }
            if (p1.Contains(1) && p1.Contains(5) && p1.Contains(9)) { PlayerOne.Iwon(); break; }
            if (p1.Contains(7) && p1.Contains(5) && p1.Contains(3)) { PlayerOne.Iwon(); break; }
            MyBoard.MoveOnBoard(PlayerTwo);
            if (p2.Contains(1) && p2.Contains(2) && p2.Contains(3)) { PlayerTwo.Iwon(); break; }
            if (p2.Contains(4) && p2.Contains(5) && p2.Contains(6)) { PlayerTwo.Iwon(); break; }
            if (p2.Contains(7) && p2.Contains(8) && p2.Contains(9)) { PlayerTwo.Iwon(); break; }
            if (p2.Contains(1) && p2.Contains(4) && p2.Contains(7)) { PlayerTwo.Iwon(); break; }
            if (p2.Contains(2) && p2.Contains(5) && p2.Contains(8)) { PlayerTwo.Iwon(); break; }
            if (p2.Contains(3) && p2.Contains(6) && p2.Contains(9)) { PlayerTwo.Iwon(); break; }
            if (p2.Contains(1) && p2.Contains(5) && p2.Contains(9)) { PlayerTwo.Iwon(); break; }
            if (p2.Contains(7) && p2.Contains(5) && p2.Contains(3)) { PlayerTwo.Iwon(); break; }

        }



    }
}