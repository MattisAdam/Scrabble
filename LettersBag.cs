namespace Scrable
{
    public static class LettersBag
    {
        public static Dictionary<char, int> lettersBag
        {
            get; private set;
        } = new Dictionary<char, int>();
        public static void InitLettersBag()
        {
            lettersBag.Add('A', 9);
            lettersBag.Add('B', 2);
            lettersBag.Add('C', 2);
            lettersBag.Add('D', 3);
            lettersBag.Add('E', 15);
            lettersBag.Add('F', 2);
            lettersBag.Add('G', 2);
            lettersBag.Add('H', 2);
            lettersBag.Add('I', 8);
            lettersBag.Add('J', 1);
            lettersBag.Add('K', 1);
            lettersBag.Add('L', 5);
            lettersBag.Add('M', 3);
            lettersBag.Add('N', 6);
            lettersBag.Add('O', 6);
            lettersBag.Add('P', 2);
            lettersBag.Add('Q', 1);
            lettersBag.Add('R', 6);
            lettersBag.Add('S', 6);
            lettersBag.Add('T', 6);
            lettersBag.Add('U', 6);
            lettersBag.Add('V', 2);
            lettersBag.Add('W', 1);
            lettersBag.Add('X', 1);
            lettersBag.Add('Y', 1);
            lettersBag.Add('Z', 1);
        }
        public static char PickPiecesPosition(int position)
        {
            var result = '#';
            var count = 0;
            while (result == '#')
            {
                foreach (char pieces in lettersBag.Keys)
                {

                    for (int i = 0; i < lettersBag[pieces]; i++)
                    {
                        count++;

                        if (count == position)
                        {
                            result = pieces;
                            lettersBag[pieces] -= 1;
                        }
                    }
                }
            }
            return result;
        }
        public static int NumberPiecesInBag()
        {
            int result = 0;
            result = lettersBag.Sum(x => x.Value);
            return result;
        }
        public static void PlayerPickLetters()
        {

            ///attention ici il faut en compte les probabilité de piocher chaque lettre. par exemple la proba de piocher 'E' est de 15/100
        }
    }
}