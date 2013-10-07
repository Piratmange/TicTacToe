using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

public class program
{
    static int playerNumber;
    static char buttonPressed;
    static Player P1;
    static Player P2;
    static bool playAgain = false;
    static bool firstTime = true;

    public static void Main()
    {

        var MyBoard = new Board();
        bool playerTurn = true;

        if (playAgain == false || firstTime != false)
        {
            firstIntro();
        }

        Console.Clear();
        Console.WriteLine(MyBoard.DrawBoard());

        WinningCount(P1.Name, P1.Winning, 25, 10);
        WinningCount(P2.Name, P2.Winning, 25, 11);

        while (true)
        {
            var TempPlayer = playerTurn ? P1 : P2;
            playerTurn = !playerTurn;
            var TempPlayerColor = playerTurn ? Console.ForegroundColor = ConsoleColor.DarkGreen : Console.ForegroundColor = ConsoleColor.DarkRed;
            MyBoard.MoveOnBoard(TempPlayer);

            Console.SetCursorPosition(0, 15);
            if (MyBoard.EvaluateWin(TempPlayer))
            {
                Console.WriteLine("{0} WON!!!                                ", TempPlayer.Name);
                TempPlayer.Winning++;
                "Play again Y/N?".Echo();
                char PlayAnswer = Console.ReadKey().KeyChar;
                if (PlayAnswer == 'y')
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
                char PlayAnswer = Console.ReadKey().KeyChar;
                if (PlayAnswer == 'y')
                {
                    playAgain = true;
                    firstTime = false;
                    Main();
                }
                else break;
            }

        }
    }

    public static Player Intro()
    {
        var playerList = new List<Player>();

        playerList.Add(P1);
        playerList.Add(P2);

        int number = 1;
        "Choose 2 players".Echo();
        foreach (var player in playerList)
        {
            Console.Write("{0}. {1} that uses the marker: {2}", number, player.Name, player.Marker + "\n");
            number++;
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

    public static void firstIntro()
    {
        Console.WriteLine("1. Mänsklig Spelare\n2. Dum Dator\n3. Smart Dator");
        Console.WriteLine("Välj Spelare 1!");
        buttonPressed = Console.ReadKey().KeyChar;

        if (buttonPressed == '1')
        {
            Console.WriteLine("");
            P1 = new Player(Player.GetPlayer(), Player.GetChar());
        }
        else if (buttonPressed == '2')
            P1 = new AI_Random("Anna", 'X');
        else
            P1 = new AI_Random_V2("Anna", 'X');

        Console.WriteLine("\n1. Mänsklig Spelare\n2. Dum Dator\n3. Smart Dator");
        Console.WriteLine("Välj Spelare 2!");
        buttonPressed = Console.ReadKey().KeyChar;

        if (buttonPressed == '1')
        {
            Console.WriteLine("");
            P2 = new Player(Player.GetPlayer(), Player.GetChar());
        }
        else if (buttonPressed == '2')
            P2 = new AI_Random("AnnaBåt", 'O');
        else
            P2 = new AI_Random_V2("Anna", 'O');
    }
}