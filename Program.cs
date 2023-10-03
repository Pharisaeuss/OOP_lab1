namespace Game;

public class GameAccount 
{
    public string UserName;
    public int CurrentRating;
    public int GamesCount;

    public GameAccount(string username, int currentrating, int gamescount)
    {
        UserName = username;
        CurrentRating = currentrating;
        GamesCount = gamescount;
    }

    
}
