namespace Scrable
{
    public class Hand : Player
    {
        public Hand() : base() { }
        Random getRandomPositionOnLettersBag = new Random();
        List<char> rack = new List<char>();
        int maxLettersPerPlayer = 7;

        public  void DisplayHand()
        {
            _pickLettersForPlayer();
        }
        private void _pickLettersForPlayer() //transformer la fonction pour respecter la regle (trj tirer le nmb de lettres (max de lettre - le nmbre de lettre dans la rack)
        {
            int requiredNumberOfNewLetters = maxLettersPerPlayer - rack.Count;
            GetPieceFromLettersBag(requiredNumberOfNewLetters);
        }
        public char GetPieceFromLettersBag(int requiredNUmberOfNewLetters)
        {
            char pickedLetter = ' ';
            for (int i = 0; i < requiredNUmberOfNewLetters; i++)
            {
                int randomPosition = getRandomPositionOnLettersBag.Next(LettersBag.NumberPiecesInBag());
                pickedLetter = LettersBag.PickPiecesPosition(randomPosition);
                rack.Add(pickedLetter); 
                Console.Write(rack[i]);
                if (i < (requiredNUmberOfNewLetters - 1))
                {
                    Console.Write('-');
                }
            }
            Console.WriteLine(" ");
            return rack[0];
        }
    }
}

