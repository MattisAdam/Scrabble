namespace Scrable
{
    public class Rack
    {
        Random getRandomPositionOnLettersBag = new Random();
        List<char> rack = new();
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
        public bool VerificationLetterInRack(char letter, int position)
        {
            if (letter == rack[position]) { return true; }
            else { return false; }
        }
        public char TakeAletter()
        {

            char letter = Fonction.EnterChar();
            letter = Fonction.CharToUpper(letter);
            bool check = false;
            Console.WriteLine();
            for (int i = 0; i < rack.Count; i++)
            {
                check = VerificationLetterInRack(letter, i);
                if (check) { break;  }
                
            }
            Console.WriteLine();
            if(check != true)
            {
                Console.WriteLine("Letter not fund on the rack please retry...");
                TakeAletter();
            }
            Console.WriteLine("Letter find");
            rack.Remove(letter);
            return letter;
            
        }

    }
}