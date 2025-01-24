namespace Scrable
{
    public class Rack
    {
        Random getRandomPositionOnLettersBag = new Random();
        List<char> rack = new List<char>();

        public Rack()
        {
            PickLettersForPlayer();
        }
        public void DisplayRack()
        {
            for (int i = 0; i < rack.Count; i++)
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

        public bool ChooseALetterFromRack(char letter)
        {
            for (int i = 0; i < rack.Count; i++)
            {
                if (letter == rack[i]) { return true; }
                else
                {
                    Console.WriteLine("The choosen Letter is not on your rack");
                }
            }
            return false;
        }
    }
}