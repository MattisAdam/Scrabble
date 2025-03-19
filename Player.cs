

using Scrable;

namespace Scrabble
{
    public class Player
    {
        public string Name { get; set; }
        public Rack Rack { get; set; }
        public int Score { get; set; }
        public List<char> temp;
        private List<string> words;

        public Player()
        {
            Name = Fonction.EnterString("What's your name ?");
            Rack = new Rack();
            temp = new List<char>();
            words = new List<string>(); 
           
        }

        public bool VerificationWordInDictionnary(string word)
        {
            bool check = ValideWords.IsValidWordInDictionnary(word);
            
            return check;
        }
        public string ChooseWord()
        {
           
            int occurence = Fonction.MenuWord();
            for (int i = 0; i < occurence; i++)
            {
                char letter = TakeAletter();
                Console.WriteLine();
                Console.WriteLine($"Your word is : {String.Join("", temp)}");
                Console.WriteLine();
                Console.Write("Your rack: ");
                Rack.DisplayRack(Rack.rack);
                Console.WriteLine();
            }
            Console.WriteLine();
            return String.Join("", temp); 
        }
        public char TakeAletter()
        {
            char letter = ' ';
            bool check = false;
            while (!check)
            {
                Console.Write("Enter a letter: ");
                letter = Fonction.EnterChar(" ");
                letter = Fonction.CharToUpper(letter);
                for (int i = 0; i < Rack.rack.Count; i++)
                {
                    check = Rack.VerificationLetterInRack(letter, i);
                    if (check)
                    {
                        temp.Add(letter);
                        Rack.RemoveLetterOnTheRack(Rack.rack, letter);
                        break;
                    }
                }
                if (!check)
                {
                    Console.WriteLine();
                    Console.WriteLine("Letter not found, please retry.");
                }
            }
            return letter; 
        }

        public void GetScore(int pts)
        {
            Score += pts;
        }

        public void ShowStatus()
        {
            Console.Write($"Rack for {Name} = ");
            Rack.DisplayRack(Rack.rack);
            Console.WriteLine($"Score for {Name} = {Score}");
        }
    
        public void PicklettersFromBag (LettersBag bag)
        {
            Rack.PickLettersForPlayer(bag);
        }

        public void RemoveLetterOnTheRack(List<char> rack, char letter)
        {
            rack.Remove(letter);

        }
        public void AddLetterOnTheRack(List<char> rack, char letter)
        {
            if (rack.Count < Game.MaxLettersPerPlayer)
            {
                rack.Add(letter);
            }
        }
        public void ReinitialisationOfTheRack(string word)
        {
            Console.WriteLine($"{word} doesn't exist.");
            foreach (var letter in temp)
            {
                AddLetterOnTheRack(Rack.rack, letter);
            }
            while (temp.Count != 0)
            {
                RemoveLetterOnTheRack(temp, temp[0]);
            }
        }
    }
}
