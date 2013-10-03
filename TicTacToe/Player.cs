using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Player
{
    public string Name { get; set; }
    public string Marker { get; set; }
    public List<int> MarkerOnBoard { get; set; }

    public static string GetPlayerOne()
    {
        Console.WriteLine("Name of player 1?");
        string P1 = Console.ReadLine();
        return P1;
    }
    public static string GetCharOne()
    {
        Console.WriteLine("What char do you want?");
        string C1 = Console.ReadLine();
        return C1;
    }


    public static string GetPlayerTwo()
    {
        Console.WriteLine("Name of player 2?");
        string P2 = Console.ReadLine();
        return P2;
    }
    public static string GetCharTwo()
    {
        Console.WriteLine("What char do you want?");
        string C2 = Console.ReadLine();
        return C2;
    }



    public Player(string name, string marker)
    {
        Name = name;
        Marker = marker;
        MarkerOnBoard = new List<int>();
    }
    public void DrawMarker(int x, int y)
    {
        Console.SetCursorPosition(x - 1, y - 1);
        Console.Write("{0}{0}{0}", Marker);
        Console.SetCursorPosition(x - 1, y);
        Console.Write("{0} {0}", Marker);
        Console.SetCursorPosition(x - 1, y + 1);
        Console.Write("{0}{0}{0}", Marker);
    }
}

