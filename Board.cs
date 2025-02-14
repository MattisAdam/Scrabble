namespace Scrable
{
    public class Board
    {
        private char[,] grid;
        private  int[,] bonus;
        public Board()
        {
            grid = new char[15, 15];
            bonus = new int[15, 15];
        }
        public void InitBoard()
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
        public void PlaceWord(string word, Player player)
        {
            _placeLetter(player, word);
        }

        private void _placeLetter(Player player, string word)
        {
            int i = 0;
            int totalPointOnTheBoard = 0;
            var verif = true;
            var ptsLetter = 0;
            int orientation = 0;
            while (verif == true)
            {
                int positionJ = _targetPosition("Choose a horizontal position");
                int positionI = _targetPosition("Choose a vertical position");
                try
                {
                    verif = _validationBoard(0, positionJ);


                     orientation = Fonction.HorizontalOrVertical();
                }
                catch (Exception e) {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(e.Message);
                    Console.ResetColor();
                }
                foreach (var _letter in word)
                {
                    ptsLetter = ScoreLetter.GetTheScoreOfTheLetter(_letter);
                    
                    if (orientation == 1)
                    {
                        int ptsBonus = _validationBoardBonus(0, positionJ + i);
                        if (ptsBonus != 0) { totalPointOnTheBoard += ptsBonus * ptsLetter ; }
                        else { totalPointOnTheBoard += ptsLetter ; }
                        grid[0, positionJ + i] = _letter ;
                        i++;
                    }
                    else if (orientation == 2)
                    {
                        int ptsBonus = _validationBoardBonus(0 + i, positionJ);
                        if (ptsBonus != 0) { totalPointOnTheBoard += ptsBonus * ptsLetter ; }
                        else { totalPointOnTheBoard += ptsLetter ; }
                        grid[0 + i, positionJ] = _letter;
                        i++;
                    }
                    
                }
                Console.WriteLine();
                player.getScore(totalPointOnTheBoard);
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
        private int _targetPosition(string message) { return Fonction.EnterNumber(message);}
        private bool _validationBoard(int positionI, int positionJ)
        {
            bool check = false;
            if (grid[positionI, positionJ] != ' ')
            {
                Console.WriteLine("This place was already taken buddy, choose another position");
                check = true;
            }
            return check;
        }
        private int _validationBoardBonus(int positionI, int positionJ) { return bonus[positionI, positionJ]; }
    }
}

