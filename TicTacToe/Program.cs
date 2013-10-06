using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

public class program
{
    public static void Main()
    {
        var MyBoard = new Board();
        bool playerTurn = true;

        var PlayerOne = Intro();
        var PlayerTwo = Intro();

        Console.Clear();
        Console.WriteLine(MyBoard.DrawBoard());

        while (true)
        {
            var TempPlayer = playerTurn ? PlayerOne : PlayerTwo;
            playerTurn = !playerTurn;
            var TempPlayerColor = playerTurn ? Console.ForegroundColor = ConsoleColor.DarkGreen : Console.ForegroundColor = ConsoleColor.DarkRed;

            MyBoard.MoveOnBoard(TempPlayer);

            Console.SetCursorPosition(0, 15);
            if (MyBoard.EvaluateWin(TempPlayer))
            {
                Console.ResetColor();
                Console.WriteLine("{0} WON!!!                                ", TempPlayer.Name);
                "Play again Y/N?".Echo();
                string PlayAnswer = Console.ReadLine().ToLower();
                if (PlayAnswer == "y")
                    Main();
                else break;
            }
            else if (!MyBoard.BoardTiles.ContainsValue(" "))
            {
                Console.ResetColor();
                Console.WriteLine("It's a tie                                ");
                "Play again Y/N?".Echo();
                string PlayAnswer = Console.ReadLine().ToLower();
                if (PlayAnswer == "y")
                    Main();
                else break;
            }
        }
    }
    public static Player Intro()
    {
        var playerList = new List<Player>();
        var AI1 = new AI_Random("Crappy AI1", "Z");
        var AI2 = new AI_Random("Crappy AI2", "V");
        var P1 = new Player("Player 1", "O");
        var P2 = new Player("Player 2", "X");

        playerList.Add(AI1);
        playerList.Add(AI2);
        playerList.Add(P1);
        playerList.Add(P2);

        int number = 1;
        "Chose a player".Echo();
        foreach (var player in playerList)
        {
            Console.Write("{0}. {1} that uses the marker: {2}", number, player.Name, player.Marker + "\n");
            number++;
        }
        int playerNumber = int.Parse(Console.ReadLine());
        var chosenPlayer = playerList[playerNumber - 1];
        playerList.RemoveAt(playerNumber - 1);

        return chosenPlayer;
    }
}