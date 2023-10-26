using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using System;
using System.Collections.Generic;

namespace MyGame
{
class Program
{
    
    static void Main(string[] args)
    {
        GameAccount gamer1 = new GameAccount("pyk", 1, 3);
        GameAccount gamer2 = new GameAccount("pipipypy", 10, 20);
        
        List<string> OpponentsNames = new List<string> {"Warrior", "Mage", "Archer", "Thief"};
        List<string> WinOrLose = new List<string> {"Win", "Lose"};
        Random rnd = new Random();
        
  
        gamer1.WinGame(60, OpponentsNames[rnd.Next(OpponentsNames.Count)]);
        gamer2.LoseGame(10, OpponentsNames[rnd.Next(OpponentsNames.Count)]);

        Console.WriteLine(gamer1.GetStats());
        Console.WriteLine(gamer2.GetStats());

      
        try
        {
            gamer1.WinGame(-1000, OpponentsNames[rnd.Next(OpponentsNames.Count)]);
            gamer2.LoseGame(-1000, OpponentsNames[rnd.Next(OpponentsNames.Count)]);
        }
        catch (ArgumentOutOfRangeException e)
        {
            Console.WriteLine("Error: " + e.Message);
            return;
        }
               
    }
  }
}


