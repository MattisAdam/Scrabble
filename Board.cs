using static System.Formats.Asn1.AsnWriter;

namespace Scrable
{
    public class Board
    {
        private char[,] grid = new char[15, 15];
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
            for (int i = 0; i < 196; i++)
            {
                int placementI;
                int placementJ;
                placementI = bonusI.Next(15);
                placementJ = bonusJ.Next(15);
                multiple = bonusMulti.Next(2, 5);
                //TODO : FIND HOW TO CONVERT EASYER 
                var t = multiple.ToString();
                grid[placementI, placementJ] = t.ToCharArray()[0];
            }
        }
        public void PlaceLetter(Player player)
        {
            
            int positionI;
            int positionJ;
            int valueBonus = 1;
            positionJ = _TargetPosition("Choose a horizontal position");
            positionI = _TargetPosition("Choose a vertical position");
            Console.WriteLine($"case : {positionI}, {positionJ} Value : {grid[positionI, positionJ]}");
            if (grid[positionI, positionJ] == ' ' || grid[positionI, positionJ] == '2' || grid[positionI, positionJ] == '3' || grid[positionI, positionJ] == '4')
            {
                var check = int.TryParse(grid[positionI, positionJ].ToString(), out valueBonus);
                
                Console.WriteLine();
                Console.WriteLine($"la case {positionI}, {positionJ} vaut {valueBonus} fois, score mis a jour..");
                //Console.WriteLine($"after : {grid[positionI, positionJ]}");
            }
            else
            {
                Console.WriteLine($"la case {positionI}, {positionJ} est deja occupé !");
                PlaceLetter(player);
            }
            Console.WriteLine($"Score : ");
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
                            if (grid[(i - 1) / 2, (k - 1) / 2] == '2') { Console.ForegroundColor = ConsoleColor.Yellow; }
                            if (grid[(i - 1) / 2, (k - 1) / 2] == '3') { Console.ForegroundColor = ConsoleColor.Green; }
                            if (grid[(i - 1) / 2, (k - 1) / 2] == '4') { Console.ForegroundColor = ConsoleColor.Red; }
                            if(grid[(i - 1) / 2, (k - 1) / 2] == ' ') { Console.ForegroundColor = ConsoleColor.Cyan; }
                            Console.Write($" {grid[(i - 1) / 2, (k - 1) / 2]}");
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
    }
}

