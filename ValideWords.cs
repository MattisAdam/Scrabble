using System.Data;

namespace Scrable
{
    public static class ValideWords
    {
        private static HashSet<string> SetOfValidWords { get;  set; }

        static ValideWords()
        {
            SetOfValidWords = new HashSet<string>();
        }


        public static void LoadWords(string filePath)
        {
            // Lire chaque ligne du fichier et l'ajouter à l'ensemble
            SetOfValidWords.Clear();
            using (StreamReader sr = new StreamReader(filePath)) 
            { 
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    SetOfValidWords.Add(_fixWords(line));
                }
            }
        }
        private static string _fixWords(string word)
        {
            word = word.Replace('é', 'e');
            word = word.Replace('è', 'e');
            word = word.Replace('ë', 'e');
            word = word.Replace('ê', 'e');
            word = word.Replace('à', 'a');
            word = word.Replace('ä', 'a');
            word = word.Replace('ö', 'o');
            word = word.Replace('ü', 'u');
            word = word.Replace('â', 'a');
            
            word = word.ToUpper();
            return word;
        }
    }
}
