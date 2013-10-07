using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

public class program
{
    static int playerNumber;
    static Player P1 = new Player("Default", 'X');
    static Player P2 = new Player("Player 2", 'O');
    static AI_Random AI1 = new AI_Random("Crappy AI1", 'Z');
    static AI_Random AI2 = new AI_Random("Crappy AI2", 'V');
    static bool playAgain = false;
    static bool firstTime = true;

    public static void Main()
    {
        var MyBoard = new Board();
        bool playerTurn = true;

        if (playAgain == false || firstTime != false)
        {
            Intro();
        }

        Console.Clear();
        Console.WriteLine(MyBoard.DrawBoard());

        WinningCount(P1.Name, P1.Winning, 25, 10);
        WinningCount(P2.Name, P2.Winning, 25, 11);

            while (true)
            {
                // checks whos turn it is
                var TempPlayer = playerTurn ? P1 : P2;
                playerTurn = !playerTurn;
                var TempPlayerColor = playerTurn ? Console.ForegroundColor = ConsoleColor.DarkGreen : Console.ForegroundColor = ConsoleColor.DarkRed;
                MyBoard.MoveOnBoard(TempPlayer);

                Console.SetCursorPosition(0, 15);
                if (MyBoard.EvaluateWin(TempPlayer))
                {
                    Console.WriteLine("{0} WON!!!                                ", TempPlayer.Name);
                    // For every win add score
                    TempPlayer.Winning++;
                    "Play again Y/N?".Echo();
                    string PlayAnswer = Console.ReadLine().ToLower();
                    if (PlayAnswer == "y")
                    {
                        playAgain = true;
                        firstTime = false;
                        Main();
                    }
                    else Environment.Exit(1);
                }
                else if (!MyBoard.BoardTiles.ContainsValue(' '))
                {
                    Console.ResetColor();
                    Console.WriteLine("It's a tie                                ");
                    "Play again Y/N?".Echo();
                    string PlayAnswer = Console.ReadLine().ToLower();
                    if (PlayAnswer == "y")
                    {
                        Main();
                        playAgain = false;
                        firstTime = false;
                    }
                    else break;
                }
            
        }
    }

    public static Player Intro()
    {
        var playerList = new List<Player>();

        playerList.Add(AI1);
        playerList.Add(AI2);
        playerList.Add(P1);
        playerList.Add(P2);

        int number = 1;
        "Choose player".Echo();
        foreach (var player in playerList)
        {
            Console.Write("{0}. {1} that uses the marker: {2}", number, player.Name, player.Marker + "\n");
            number++;
        }
        playerNumber = int.Parse(Console.ReadLine());
        if (playerNumber == 3)
        {
            P1 = new Player(Player.GetPlayer(), Player.GetChar());
            playerList.RemoveAt(2);
            playerList.Insert(2, P1);
        }
        if (playerNumber == 4)
        {
            P1 = new Player(Player.GetPlayer(), Player.GetChar());
            playerList.RemoveAt(3);
            playerList.Insert(3, P2);
        }
        var chosenPlayer = playerList[playerNumber - 1];
        playerList.RemoveAt(playerNumber - 1);
        return chosenPlayer;               
    }

    public static void WinningCount(string Name, int Wins, int x, int y)
    {
        Console.SetCursorPosition(x, y);
        Console.WriteLine(Name + " Wins: " + Wins + "                           ");
    }
}