using System.Dynamic;
using System.Security.Cryptography;

namespace Scrable
{ 
    public class Player
    {
        public string Name { get; set; }
        public Rack Rack { get; set; }
        public int? Score { get; set; }

        public Player()
        {

        }
        public Player(string name, Rack rack)
        {
            Name = name;
            Rack = rack;
            Score = 0;
        }

        public Player(int? score, string name)
        {
            Score = score;
            Name = name;
        }

        public string ChooseWord()
        {
            List<char> rack = new();
            var x = new Rack();
            string word = "";
            Console.Write("Votre rack : "); Rack.DisplayRack(); ;
            for (int i = 0; i < x.Count; i++)
            {
                var letter = x.TakeAletter();
                rack[i] = letter;
                
                var choice = Fonction.MenuWord();
                if (choice == 2)
                {
                    break ;
                }
                Console.WriteLine($"Votre mot est {rack[i]}");
            }
            return word;
        }

    }
}