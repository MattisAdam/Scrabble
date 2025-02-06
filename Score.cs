namespace Scrable
{
    public class Score
    {
        // do a dico with letter and point
        public static Dictionary<char, int> ScoreLetter { get; private set; } = new Dictionary<char, int>();
        public static void InitScoreLetter()
        {
            ScoreLetter.Add('A', 1);
            ScoreLetter.Add('B', 3);
            ScoreLetter.Add('C', 3);
            ScoreLetter.Add('D', 2);
            ScoreLetter.Add('E', 1);
            ScoreLetter.Add('F', 4);
            ScoreLetter.Add('G', 2);
            ScoreLetter.Add('H', 4);
            ScoreLetter.Add('I', 1);
            ScoreLetter.Add('J', 8);
            ScoreLetter.Add('K', 10);
            ScoreLetter.Add('L', 1);
            ScoreLetter.Add('M', 2);
            ScoreLetter.Add('N', 1);
            ScoreLetter.Add('O', 1);
            ScoreLetter.Add('P', 3);
            ScoreLetter.Add('Q', 8);
            ScoreLetter.Add('R', 1);
            ScoreLetter.Add('S', 1);
            ScoreLetter.Add('T', 1);
            ScoreLetter.Add('U', 1);
            ScoreLetter.Add('V', 4);
            ScoreLetter.Add('W', 10);
            ScoreLetter.Add('X', 10);
            ScoreLetter.Add('Y', 10);
            ScoreLetter.Add('Z', 10);
        }

        public int GetTheScoreOfTheLetter(char letter)
        {
            foreach(var _letter in ScoreLetter)
            {
                if (ScoreLetter.ContainsKey(letter)){
                    return _letter.Value;
                }
            }
            return 0;
        }
    }
}
