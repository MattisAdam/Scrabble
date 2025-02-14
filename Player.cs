using System.Dynamic;
using System.Security.Cryptography;

namespace Scrable
{
    public class Player
    {
        public string Name { get; set; }
        public Rack Rack { get; set; }
        public int Score { get; set; }

        List<string> words;
        public Player() 
        {
            var name = Fonction.EnterString("What's your name ?");
            Name = name;
            Rack = new Rack();
            words = new List<string>();
            
        }
        public Player(string name) : this(name, new Rack(), 0)
        {
        }
        public Player(string name, Rack rack) : this(name, rack, 0)
        {
            
        }
        public Player(string name, Rack rack, int score ) 
        {
            Name = name;
            Rack = rack;
            Score = score;
        }
        

        public string ChooseWord()
        {
            
            int occurence = Fonction.MenuWord();
            
            for (int i = 0; i < occurence; i++)
            {
                words.Add(TakeAletter().ToString());
                Console.WriteLine();
                Console.WriteLine($"your word is : { String.Join("", words)}");
                Console.WriteLine();

                Console.Write("your rack : ");
                Rack.DisplayRack();
                Console.WriteLine();
            }
            Console.WriteLine();
            return String.Join("", words);
        }

        // pioche rack
        

        // choisit une lettre dans le rack 
        public char TakeAletter()
        {
            char letter = ' ';
            bool check = false;

            while (!check)
            {
                Console.Write("Enter a letter : ");
                letter = Fonction.EnterChar(" ");
                letter = Fonction.CharToUpper(letter);


                for (int i = 0; i < Rack.rack.Count; i++)
                {
                    check = Rack.VerificationLetterInRack(letter, i);
                    if (check) { break; }
                }

                if (!check)
                {
                    Console.WriteLine("Letter not found, please retry.");
                }
            }

            Rack.RemoveLetterOnTheRack(letter);
            return letter;
        }
        public void getScore(int pts)
        {
            Score += pts;

            Console.WriteLine($"Score for {Name} = {Score}");
        }
    }
}