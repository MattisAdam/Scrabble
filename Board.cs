using Scrabble;
using System.ComponentModel.Design;
using System.Diagnostics.Metrics;

namespace Scrable
{
    public class Board
    {
        private char[,] grid;
        private int[,] bonus;
        public Board()
        {
            grid = new char[15, 15];
            bonus = new int[15, 15];
            _InitBoard();
        }
        private void _InitBoard()
        {
            _createBoard();
            _initialeBonus();
        }
        private void _initialeBonus()
        {
            Random bonusI = new();
            Random bonusJ = new();
            Random bonusMulti = new();
            int multiple;
            for (int i = 0; i < 25; i++)
            {
                int placementI;
                int placementJ;
                placementI = bonusI.Next(15);
                placementJ = bonusJ.Next(15);
                multiple = bonusMulti.Next(2, 5);
                bonus[placementI, placementJ] = multiple;
            }
        }
        public void PlaceWord(Player player, string word)
        {
            var totalPointOnTheBoard = 0;
            int orientation = 0;
            var positionJ = _targetPosition("Choose a horizontal position");
            int positionI = _targetPosition("Choose a vertical position");
            bool verif = IsAFreeCase(positionI, positionJ);
            string NewWord = string.Empty;
            if (verif)
            {
                try
                {
                    orientation = Fonction.HorizontalOrVertical();
                    NewWord  = WordWithLetterAround(positionI, positionJ, orientation, word);
                }
                catch (Exception e)
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(e.Message);
                    Console.ResetColor();
                }
                PutLetterOnTheGrid(word, positionI, positionJ, orientation);
                totalPointOnTheBoard = CalcScore(NewWord, orientation, positionI, positionJ, totalPointOnTheBoard);
                Console.WriteLine();
                player.GetScore(totalPointOnTheBoard);
            }

        }
        public void Display()
        {
            int horizontal = 30;
            int vertical = 30;
            Console.ForegroundColor = ConsoleColor.Blue;

            for (int i = 0; i < horizontal + 1; i++)
            {
                if (i % 2 == 0)
                {
                    for (int k = 0; k < vertical; k++)
                    {
                        if (k % 2 == 0)
                        {
                            Console.Write('+');
                        }
                        else
                        {
                            Console.Write("--");
                        }
                        if (k == vertical - 1)
                        {
                            Console.Write('+');
                        }
                    }
                }
                else
                {
                    for (int k = 0; k < vertical + 1; k++)
                    {
                        if (k % 2 == 0)
                        {
                            Console.Write('|');
                        }
                        else
                        {
                            if (bonus[(i - 1) / 2, (k - 1) / 2] == 2) { Console.ForegroundColor = ConsoleColor.Yellow; }
                            if (bonus[(i - 1) / 2, (k - 1) / 2] == 3) { Console.ForegroundColor = ConsoleColor.Green; }
                            if (bonus[(i - 1) / 2, (k - 1) / 2] == 4) { Console.ForegroundColor = ConsoleColor.Red; }
                            if (bonus[(i - 1) / 2, (k - 1) / 2] == ' ') { Console.ForegroundColor = ConsoleColor.Cyan; }

                            if (grid[(i - 1) / 2, (k - 1) / 2] != ' ')
                                Console.Write($" {grid[(i - 1) / 2, (k - 1) / 2]}");
                            else if (bonus[(i - 1) / 2, (k - 1) / 2] != '\0')
                                Console.Write($" {bonus[(i - 1) / 2, (k - 1) / 2]}");
                            else
                                Console.Write("  ");

                            Console.ResetColor();
                            Console.ForegroundColor = ConsoleColor.Blue;
                        }
                    }
                }
                Console.Write("\n");
            }
            Console.ResetColor();
        }
        private void _createBoard()
        {
            grid = new char[15, 15];
            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    grid[i, j] = ' ';
                }
            }
        }
        private int _targetPosition(string message)
        {
            return Fonction.EnterNumber(message);
        }
        private bool IsAFreeCase(int positionI, int positionJ)
        {
            if (grid[positionI, positionJ] != ' ')
            {
                Console.WriteLine("This place was already taken buddy, choose another position");
                return false;
            }
            return true;
        }
        private int _validationBoardBonus(int positionI, int positionJ)
        {
            return bonus[positionI, positionJ];
        }
        private int CalcScore(string word, int orientation, int positionITemp, int positionJTemp, int totalPointOnTheBoard)
        {
            int i = 0;
            int ptsBonus = 0;
            foreach (var _letter in word)
            {
                int ptsLetter = ScoreLetter.GetTheScoreOfTheLetter(_letter);

                if (orientation == 1)
                {
                    if(i == word.Length - 1)
                    {
                         ptsBonus = _validationBoardBonus(positionITemp, positionJTemp);
                    }
                    else
                    {
                        ptsBonus = _validationBoardBonus(positionITemp, positionJTemp + i);
                    }
        //---------------------------------------------------------------------------------------------------------------------------
                    if (ptsBonus != 0)
                    {
                        totalPointOnTheBoard += ptsBonus * ptsLetter;
                    }
                    else
                    {
                        totalPointOnTheBoard += ptsLetter;
                    }
                }


                else if (orientation == 2)
                {
                    if (i == word.Length - 1)
                    {
                        ptsBonus = _validationBoardBonus(positionITemp, positionJTemp);
                    }
                    else
                    {
                        ptsBonus = _validationBoardBonus(positionITemp + i, positionJTemp);
                    }
                    //---------------------------------------------------------------------------------------------------------------------------
                    if (ptsBonus != 0)
                    {
                        totalPointOnTheBoard += ptsBonus * ptsLetter;
                    }
                    else
                    {
                        totalPointOnTheBoard += ptsLetter;
                    }
                }
                i++;
            }
            return totalPointOnTheBoard;
        }
        public string WordWithLetterAround(int positionI, int positionJ, int orientation, string word)
        {
            string newWord = string.Empty;
            if (positionI != 0 || positionJ != 0)
            {
                if (orientation == 1)
                {
                    newWord = NewWord(word, positionI, positionJ - 1);
                    Console.WriteLine(newWord);
                }
                else if (orientation == 2)
                {
                    newWord = NewWord(word, positionI - 1, positionJ);
                    Console.WriteLine(newWord);
                }
                return newWord;
            }
            else
            {
                return word;
            }
        }
        public string NewWord(string word, int positionI, int positionJ)
        {
            char caseGrid = grid[positionI, positionJ];
            string x = caseGrid.ToString();
            return $"{x}{word}";
        }

        public void PutLetterOnTheGrid(string word, int positionI, int positionJ, int orientation)
        {
            int i = 0;
            if (orientation == 1)
            {
                foreach (char letter in word)
                {
                    grid[positionI, positionJ+i] = letter;
                    i++;
                }
            }
            else if(orientation == 2)
            {
                foreach (char letter in word)
                {
                    grid[positionI + i, positionJ] = letter;
                    i++;
                }
            }
        }
    }
}