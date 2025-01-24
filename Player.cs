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



    }
}