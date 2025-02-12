﻿using System.Windows.Markup;
using static System.Formats.Asn1.AsnWriter;

namespace Scrable
{
    public class Board
    {
        private char[,] grid = new char[15, 15];
        private int[,] bonus = new int[15, 15];
        private List<Player> _players = new List<Player>();
        public void InitBoard()
        {
            _createBoard();
            _initialeBonus();
        }
        private void _initialeBonus()
        {
            Random bonusI = new Random();
            Random bonusJ = new Random();
            Random bonusMulti = new Random();
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

        public void PlaceWord(string word)
        {
            var _player = new Player();
            PlaceLetter(_player, word);
        }

        public void PlaceLetter(Player player, string word)
        {
            int positionI = 0;
            int positionJ = 0;
            int i = 0;
            int ptsBonus = 0;
            int ptsLetter = 0;
            var verif = true;
            int factorpts = 0;
            var score = new Score();
            while (verif == true)
            {
                positionJ = _TargetPosition("Choose a horizontal position");
                positionI = _TargetPosition("Choose a vertical position");
                verif = _ValidationBoard(positionI, positionJ);
            }

            int orientation = Fonction.HorizontalOrVertical();
            Console.WriteLine();
            if (orientation == 1)
            {
                foreach (var _letter in word)
                {
                    ptsLetter = ScoreGestion(_letter);
                    ptsBonus = _ValidationBoardBonus(positionI, positionJ+ i);
                    if(ptsBonus != 0) { factorpts += ptsBonus * ptsLetter; }
                    else { factorpts += ptsLetter; }

                    grid[positionI, positionJ + i] = _letter;
                    i++;
                }
            }
            else if (orientation == 2)
            {
                foreach (var _letter in word)
                {
                    ptsLetter = ScoreGestion(_letter);
                    ptsBonus = _ValidationBoardBonus(positionI + i, positionJ);
                    if (ptsBonus != 0) { factorpts += ptsBonus * ptsLetter; }
                    else { factorpts += ptsLetter; }
                    
                    grid[positionI + i, positionJ] = _letter;
                    i++;
                }
            }
            Console.WriteLine($"Score : {factorpts}");
            score.StockScore(factorpts);
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
        private int _TargetPosition(string message)
        {
            Console.WriteLine(message);
            int position = Fonction.EnterNumber();
            return position;
        }
        private bool _ValidationBoard(int positionI, int positionJ)
        {
            bool check = false;

            if (grid[positionI, positionJ] != ' ')
            {
                Console.WriteLine("This place was already taken buddy, choose another position");
                check = true;
            }
            return check;
        }
        private int _ValidationBoardBonus(int positionI, int positionJ)
        {
            var valueBonus = bonus[positionI, positionJ];
           
            return valueBonus;


        }

        public int ScoreGestion(char letter)
        {
            var lowerLetter = Char.ToLower(letter);
            var pts = Score.GetTheScoreOfTheLetter(lowerLetter);
          
            return pts;
        }
    }
}

