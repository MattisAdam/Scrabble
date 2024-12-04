namespace Scrable
{
    public class Player
    {
        public string Name { get; set; }
        public List<char> Hand { get; set; }
        public int? Score { get; set; }

        public Player()
        {

        }
        public Player(string name) : this(name, null, 0) { }
        public Player(List<char> hand) : this(null, hand, 0) { }
        public Player(int score) : this(null, null, 0) { }
        public Player(string name, List<char> hand) : this(name, hand, 0) { }
        public Player(string name, List<char> hand, int score)
        {
            Name = name;
            Hand = hand;
            Score = score;

            // Code pour jouer un tour
            //Calcul du score

            //var toto = ValideWords.SetOfValidWords;
        }

    }
}