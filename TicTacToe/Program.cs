using System;
using System.Collections.Generic;
using System.Text;

class program
{
    public static void Main()
    {
        Console.WindowHeight = 30;
        Console.WindowWidth = 40;
        var MyBoard = new Board();
        Console.WriteLine(MyBoard.DrawBoard());
        while (true)
            MyBoard.MoveOnBoard();

    }
}