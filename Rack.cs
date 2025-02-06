using System.Reflection;

namespace Scrable
{
    public class Rack
    {
        Random getRandomPositionOnLettersBag = new Random();
        public static List<char> rack = new List<char>();
        public Rack()
        {
            PickLettersForPlayer();
        }
        public void DisplayRack()
        {
            for (
                int i = 0; i < rack.Count; i++)
            {
                if ((rack.Count) - 1 == i)
                {
                    Console.Write($"{rack[i]}");
                }
                else
                {
                    Console.Write($"{rack[i]}-");
                }
            }
            Console.WriteLine("");
        }
        public void PickLettersForPlayer()
        {
            int requiredNumberOfNewLetters = Game.MaxLettersPerPlayer - rack.Count;
            GetPieceFromLettersBag(requiredNumberOfNewLetters);
        }
        public void GetPieceFromLettersBag(int requiredNumberOfNewLetters)
        {
            char pickedLetter = ' ';

            for (int i = 0; i < requiredNumberOfNewLetters; i++)
            {
                int randomPosition = getRandomPositionOnLettersBag.Next(LettersBag.NumberPiecesInBag());
                pickedLetter = LettersBag.PickPiecesPosition(randomPosition);
                rack.Add(pickedLetter);
            }
        }
        public bool VerificationLetterInRack(char letter, int position)
        {
            if (letter == rack[position]) { return true; }
            else { return false; }
        }
        public char TakeAletter()
        {
            char letter = ' ';
            bool check = false;
            
            while (check != true)
            {
                letter = Fonction.EnterChar();
                letter = Fonction.CharToUpper(letter);
                
                for (int i = 0; i < rack.Count; i++)
                {
                    check = VerificationLetterInRack(letter, i);
                    if (check) { break; }
                    
                   
                }
                if (check != true)
                {
                    Console.WriteLine();
                    Console.WriteLine("Letter not found, please retry with a correct letter.");
                }
                else
                {
                    check = true;
                    
                }
            }
            rack.Remove(letter);
            return letter;
        }

        
    }
}
