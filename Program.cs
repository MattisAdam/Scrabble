using Scrable;

public class Program
{
    public static void Main(string[] args)
    {
        var game = new Game();
        game.InitGame();
        while (true)
        {
            game.Play();
        }

    }
}