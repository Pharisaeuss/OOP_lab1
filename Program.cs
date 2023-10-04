using System.Security.Cryptography.X509Certificates;

namespace MyGame
{
public class GameAccount 
{
    public string gamer1Name { get; set; }
    public int CurrentRating { get; set; }
    public int GamesCount { get; set; }
    public List<Game> SavedGames { get; set; }

    public GameAccount(string gamer1name, int currentrating, int gamescount)
    {
        gamer1Name = gamer1name;
        CurrentRating = currentrating;
        GamesCount = gamescount;
        SavedGames = new List<Game>();
    }

    public void WinGame(int Ratting)
    {
        Console.WriteLine($"{gamer1Name} win game against opponentName with ratting {Ratting}");
        CurrentRating += Ratting;
        GamesCount += 1;
    }

    public void LoseGame(int Ratting)
    {
        Console.WriteLine($"{gamer1Name} lose game against opponentName with ratting {Ratting}");
        GamesCount += 1;
        if (CurrentRating - Ratting < 1)
        {
            CurrentRating = 1;
        }
        else
        {
            CurrentRating -= Ratting;
        }
    }

    public string GetStats(List<Game> games)
    {
        var SavedGames = new System.Text.StringBuilder();
        SavedGames.AppendLine("Opponents Name\t\tGame Result\tRating\tGames Count");
        foreach (var item in games)
        {
            SavedGames.AppendLine($"{item.OpponentName}\t\t\t{item.WinOrLose}\t\t{item.Rating}\t{item.GamesCount}");
        }
        return SavedGames.ToString();
    }
}

public class Game 

{
    public string OpponentName { get; set; }
    public string WinOrLose { get; set; }
    public int Rating { get; set; }
    public int GamesCount { get; set; }

    public Game(string opponent, string whowins, int rating, int gamescount)
    {
        OpponentName = opponent;
        WinOrLose = whowins;
        Rating = rating;
        GamesCount = gamescount;
    }
}

public enum Results
{
    Win, Lose
}
class Program
{
    
    static void Main(string[] args)
    {
        GameAccount gamer1 = new GameAccount("pyk", 1, 3);
        GameAccount gamer2 = new GameAccount("pipipypy", 10, 20);
        
        List<string> OpponentsNames = new List<string> {"Warrior", "Mage", "Archer", "Thief"};
        List<string> WinOrLose = new List<string> {"Win", "Lose"};
        Random rnd = new Random();
        Game StartGame1 = new Game(OpponentsNames[rnd.Next(0, OpponentsNames.Count)], WinOrLose[rnd.Next(0, WinOrLose.Count)], rnd.Next(1, 101), gamer1.GamesCount);
        Game StartGame2 = new Game(OpponentsNames[rnd.Next(0, OpponentsNames.Count)], WinOrLose[rnd.Next(0, WinOrLose.Count)], rnd.Next(1, 101), gamer2.GamesCount);
        List<Game> allGames = new List<Game>();
        allGames.Add(StartGame1);
        allGames.Add(StartGame2); /* треба переробити функцію щоб можна було викликати стати конкретного гравця(по прикладу викладача)*/
        if (StartGame1.WinOrLose is "Win")
        {
            gamer1.WinGame(StartGame1.Rating);
        }
        else
        {
            gamer1.LoseGame(StartGame1.Rating);
        }

        if (StartGame2.WinOrLose is "Win")
        {
            gamer2.WinGame(StartGame2.Rating);
        }
        else
        {
            gamer2.LoseGame(StartGame2.Rating);
        }

        Console.WriteLine(gamer1.GetStats(allGames));
       


        
        
    }
}
}


