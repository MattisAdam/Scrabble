using System.Numerics;
using System.Security.Cryptography;

namespace Scrable
{
    public class ScoreLetter
    {
        public static Dictionary<char, int> LetterScore { get; private set; }


        public ScoreLetter()
        {
            LetterScore = new Dictionary<char, int>();
            InitScoreLetter();
        }
        // do a dico with letter and point
        
        private static void InitScoreLetter()
        {
            LetterScore.Add('A', 1);
            LetterScore.Add('B', 3);
            LetterScore.Add('C', 3);
            LetterScore.Add('D', 2);
            LetterScore.Add('E', 1);
            LetterScore.Add('F', 4);
            LetterScore.Add('G', 2);
            LetterScore.Add('H', 4);
            LetterScore.Add('I', 1);
            LetterScore.Add('J', 8);
            LetterScore.Add('K', 10);
            LetterScore.Add('L', 1);
            LetterScore.Add('M', 2);
            LetterScore.Add('N', 1);
            LetterScore.Add('O', 1);
            LetterScore.Add('P', 3);
            LetterScore.Add('Q', 8);
            LetterScore.Add('R', 1);
            LetterScore.Add('S', 1);
            LetterScore.Add('T', 1);
            LetterScore.Add('U', 1);
            LetterScore.Add('V', 4);
            LetterScore.Add('W', 10);
            LetterScore.Add('X', 10);
            LetterScore.Add('Y', 10);
            LetterScore.Add('Z', 10);
        }
        public static int GetTheScoreOfTheLetter(char letter)
        {
            if(LetterScore.TryGetValue(letter, out var score)) { return score;  }
                return score;
        }
    }
}
