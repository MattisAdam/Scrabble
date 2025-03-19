namespace Scrable
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Title = "Scrabble";
            var game = new Game();
            ValideWords.LoadWords(@"C:\code\Sainz\Scrable\DictionnaryLoader.txt");

            game.Play();
           
        }
    }
}