using System.Reflection;

namespace Scrable
{
    public class Rack
    {

        public List<char> rack;
        LettersBag bag;
       


        public Rack()
        {
            rack = new List<char>();
            bag = new LettersBag();
            
            PickLettersForPlayer();

        }
        public void DisplayRack()
        {
            Console.WriteLine(string.Join("-", rack));
            Console.WriteLine("");
        }

        public void PickLettersForPlayer()
        {
            
            int requiredNumberOfNewLetters = Game.MaxLettersPerPlayer - rack.Count;
            for (int i = 0; i < requiredNumberOfNewLetters; i++)
            {
                char letter = bag.GetPieceFromLettersBag();
                AddLetterOnTheRack(letter);
            }

            
        }

        public bool VerificationLetterInRack(char letter, int position)
        { 
            if (letter == rack[position]) { return true; }
            else { return false; }
        }

        public void AddLetterOnTheRack(char letter)
        {
            if (rack.Count < Game.MaxLettersPerPlayer)
            {
                rack.Add(letter);
            }
        }

        public void RemoveLetterOnTheRack(char letter)
        {
            rack.Remove(letter);
        }


    }
}