using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Player
{
    public string Name { get; set; }
    public char Marker { get; set; }
    public List<int> MarkerOnBoard { get; set; }

    public Player(string name, char marker)
    {
        Name = name;
        Marker = marker;
        MarkerOnBoard = new List<int>();
    }
    public void Iwon()
    {
        Console.ResetColor();
        Console.Clear();
        Console.WriteLine("Player {0} has won the game", this.Name);
    }
}

