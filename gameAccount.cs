namespace MyGame {
    public class GameAccount 
{
    public string UserName { get; set; }
    public int CurrentRating { get; set; }
    public int GamesCount { get; set; }
    public List<Game> allGames;

    public GameAccount(string username, int currentrating, int gamescount)
    {
        UserName = username;
        CurrentRating = currentrating;
        GamesCount = gamescount;
        allGames = new List<Game>();
        
    }

    public void WinGame(int Ratting, string opponent)
    {
        if (CurrentRating + Ratting  <= 0)
        {
            throw new ArgumentOutOfRangeException("Invalid rating value. Rating cannot be negative or zero.");
        }

        Console.WriteLine($"{UserName} win game against {opponent} with ratting {Ratting}");
        CurrentRating += Ratting;
        GamesCount += 1;
        allGames.Add(new Game {OpponentName = opponent, WinOrLose = "Win", Rating = Ratting, GamesCount = GamesCount, Gamer = UserName });
    }

    public void LoseGame(int Ratting, string opponent)
    {
        Console.WriteLine($"{UserName} lose game against {opponent} with ratting {Ratting}");
        GamesCount += 1;
        if (CurrentRating - Ratting  <= 0)
        {
            throw new ArgumentOutOfRangeException("Invalid rating value. Rating cannot be negative or zero.");
        }
        
        GamesCount += 1;
        CurrentRating -= Ratting;

        allGames.Add(new Game {OpponentName = opponent, WinOrLose = "Lose", Rating = Ratting, GamesCount = GamesCount, Gamer = UserName });

    }

    public string GetStats()
    {
        string gamer = $"Stats of {UserName}: \n";
        var SavedGames = new System.Text.StringBuilder();
        SavedGames.AppendLine("Opponents Name\t\tGame Result\tRating\tGames Count");
        foreach (var item in allGames)
        {   
            if (item.Gamer == UserName) 
            {
                SavedGames.AppendLine($"{item.OpponentName}\t\t\t{item.WinOrLose}\t\t{item.Rating}\t{item.GamesCount}");
            }
        }
        return gamer + SavedGames.ToString();
    }
}
}