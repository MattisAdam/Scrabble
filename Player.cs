using System.Dynamic;
using System.Security.Cryptography;

namespace Scrable
{ 
    public class Player
    {
        public string Name { get; set; }
        public Rack Rack { get; set; }
        public int Score { get; set; }
        

        public Player()
        {
            
        }
        public Player(string name, Rack rack)
        {
            Name = name;
            Rack = rack;
        }

        public Player(int score, string name)
        {
            Score = score;
            Name = name;
        }
        public Player(int score)
        {
            Score = score;
        }


        public string ChooseWord()
        {
            List<string> words = new List<string>();
            var x = new Rack();
            string word = string.Empty;
            x.DisplayRack(); 
            int occurence = Fonction.MenuWord();
            for (int i = 0; i < occurence; i++)
            {
                var letter = x.TakeAletter().ToString();
                words.Add(letter);
                Console.WriteLine();
                
                Console.Write("your word is : ");
                word = String.Join("", words);
                Console.WriteLine(word);
                Console.WriteLine();
                Console.Write("your rack : "); Rack.DisplayRack();
                Console.WriteLine();
            }
            Console.WriteLine();

            
            return word;
        }

    }
}