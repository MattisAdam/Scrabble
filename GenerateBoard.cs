using System.Security.Cryptography;

namespace Scrable
{
    public class GenerateBoard
    {
        private char[,] grid = new char[15, 15];
        private int[,] bonus = new int[15, 15];
        public void InitBoard()
        {
            _createBoard();
            while (true)
            {
                Display();
                PlaceWord();
            }
            //_initialeBonus();
        }
        private void _initialeBonus()
        {
            Random bonusI = new Random();
            Random bonusJ = new Random();
            Random bonusMulti = new Random();
            int placementI;
            int placementJ;
            int multiple;
            for (int i = 0; i < 5; i++)
            {
                placementI = bonusI.Next(15);
                placementJ = bonusJ.Next(15);
                multiple = bonusMulti.Next(2, 5);
                Console.WriteLine();
                bonus[placementI, placementJ] = multiple;
            }
        }
        public void PlaceWord()
        {
            int positionI;
            int positionJ;
            Console.WriteLine("Place a word");
            char letter = Fonction.EnterChar();
            letter = char.ToUpper(letter);
            Console.WriteLine("");
            Console.WriteLine("Choose a horizontal position");
            positionJ = Fonction.EnterNumber();
            Console.WriteLine("Choose a vertical position");
            positionI = Fonction.EnterNumber();
            grid[positionI, positionJ] = letter;

        }
        public void Display()
        {
            int horizontal = 30;
            int vertical = 30;

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
                            if (bonus[(i - 1) / 2, (k - 1) / 2] != 0)
                            {
                                Console.Write(bonus[(i - 1) / 2, (k - 1) / 2]);

                            }
                            else
                            {

                                Console.Write($" {grid[(i - 1) / 2, (k - 1) / 2]}");


                            }
                        }
                    }
                }
                Console.Write("\n");
            }
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
    }
}

