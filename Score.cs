using System.Numerics;
using System.Security.Cryptography;

namespace Scrable
{
    public class Score
    {
        // do a dico with letter and point
        public static Dictionary<char, int> ScoreLetter { get; private set; } = new Dictionary<char, int>();
        
        public static void InitScoreLetter()
        {
            ScoreLetter.Add('a', 1);
            ScoreLetter.Add('b', 3);
            ScoreLetter.Add('c', 3);
            ScoreLetter.Add('d', 2);
            ScoreLetter.Add('e', 1);
            ScoreLetter.Add('f', 4);
            ScoreLetter.Add('g', 2);
            ScoreLetter.Add('h', 4);
            ScoreLetter.Add('i', 1);
            ScoreLetter.Add('j', 8);
            ScoreLetter.Add('k', 10);
            ScoreLetter.Add('l', 1);
            ScoreLetter.Add('m', 2);
            ScoreLetter.Add('n', 1);
            ScoreLetter.Add('o', 1);
            ScoreLetter.Add('p', 3);
            ScoreLetter.Add('q', 8);
            ScoreLetter.Add('r', 1);
            ScoreLetter.Add('s', 1);
            ScoreLetter.Add('t', 1);
            ScoreLetter.Add('u', 1);
            ScoreLetter.Add('v', 4);
            ScoreLetter.Add('w', 10);
            ScoreLetter.Add('x', 10);
            ScoreLetter.Add('y', 10);
            ScoreLetter.Add('z', 10);

        }
       

        public static int GetTheScoreOfTheLetter(char letter)
        {
            foreach(var _letter in ScoreLetter)
            {
              if(_letter.Key == letter)
                {  return _letter.Value; }
            }
            return 0 ;
        }
        public void StockScore(int pts)
        { 
            var game = new Game();
            var score = new Player(pts);
            var x = new Player();
            int totalScore = 0;
           
            List<int> scores = new List<int>();
            
                
                score.Score = pts;
                totalScore += score.Score;
                Console.WriteLine($"Score for {x.Name}  is {score.Score}");
                for (int i = 0; i < game._players.Count; i++)
                {
                    scores.Add(totalScore);
                }
            
            Console.WriteLine($"miaou : {score.Score}");
            
        }

    }
}
