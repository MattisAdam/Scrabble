using Scrable;

public class Program
{
    public static void Main(string[] args)
    {
        var game = new Game();
        var score = new Score();
        game.InitGame();
        game.Play();
    }
}