namespace Scrable
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Title = "Scrabble";
            var game = new Game();

            game.Play();
           
        }
    }
}