using System.ComponentModel.Design;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Security.Cryptography;
using System.Xml;

namespace Scrable
{
    public class GenerateBoard
    {
        private char[,] grid = new char[100,100];
        private int[,] bonus = new int[30, 30];
        public void InitBoard()
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
            int placementJ = Fonction.EnterNumber();
            int placementI = Fonction.EnterNumber();
            char letter = Fonction.EnterChar();
            
        }
        public void Display()
        {
            //PlaceWord();
            _createBoard();
        }
        private void _createBoard()
        {
            int horizontal = 50;
            int vertical = 20;

            for (int i = 0; i < vertical +1 ; i++)
            {
                grid = new char[horizontal, horizontal];
                if (i % 2 == 0)
                {
                    for (int k = 0; k < horizontal- 1; k++)
                    {
                        if (k % 2 == 0)
                        {
                            grid[i, k] = '+';
                        }
                        else
                        {
                            grid[i, k] = '-';
                        }
                        Console.Write(grid[i, k]);
                    }
                    


                }
                else
                {
                    for (int k = 0; k < horizontal; k++)
                    {
                        if (k % 2 == 0)
                        {
                            grid[i, k] = '|';
                        }
                        else
                                {
                            grid[i, k] = ' ';
                        }
                        Console.Write(grid[i, k]);
                        if (grid[(i - 1) / 2, (k - 1) / 2] != 0 && (grid[(i - 1) / 2, (k - 1) / 2] == '|'))
                        {
                            Console.Write($"|  {grid[(i - 1) / 2, (k - 1) / 2]}");
                        }
                    }
                    
                }
                Console.Write("\n");
                
            }
            
        }


    }
}










//int size = 31;

//for (int i = 0; i < size; i++)
//{
//    if (i % 2 == 0)
//    {
//        for (int j = 0; j < size; j++)
//        {
//            if (j % 2 == 0)
//            {
//                Console.Write("+");
//            }
//            else
//            {
//                for (; j < 4; j++)
//                    Console.Write('―');
//            }
//        }
//    }
//    else
//    {
//        for (int j = 0; j < size; j++)
//        {
//            if (j % 2 == 0)
//            {
//                Console.Write('|');
//            }
//            else
//            {
//                if (bonus[(i - 1) / 2, (j - 1) / 2] != 0)
//                {
//                    Console.Write(bonus[(i - 1) / 2, (j - 1) / 2]);
//                }
//                else
//                {
//                    Console.Write(" ");
//                }
//                if (grid[(i - 1) / 2, (j - 1) / 2] != 0 && (grid[(i - 1) / 2, (j - 1) / 2] == '|'))
//                {
//                    Console.Write($"|  {grid[(i - 1) / 2, (j - 1) / 2]}");
//                }
//            }
//        }
//    }
//    Console.Write("\n");
//}