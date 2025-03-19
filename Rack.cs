using Scrabble;
using System.Reflection;

namespace Scrable
{
    public class Rack
    {

        public List<char> rack;


        public Rack()
        {
            rack = new List<char>();
        }
        public void DisplayRack(List<char> rack)
        {
            Console.WriteLine(string.Join("-", rack));
        }
        public void PickLettersForPlayer(LettersBag bag)
        {
            int requiredNumberOfNewLetters = Game.MaxLettersPerPlayer - rack.Count;
            for (int i = 0; i < requiredNumberOfNewLetters; i++)
            {
                char letter = bag.GetPieceFromLettersBag();
                AddLetterOnTheRack(rack, letter);
            }
        }
        public bool VerificationLetterInRack(char letter, int position)
        {
            if (letter == rack[position]) { return true; }
            else { return false; }
        }
        public void AddLetterOnTheRack(List<char> rack, char letter)
        {
            if (rack.Count < Game.MaxLettersPerPlayer)
            {
                rack.Add(letter);
            }
        }
        public void RemoveLetterOnTheRack(List<char> rack, char letter)
        {
            rack.Remove(letter);
        }
    }
}