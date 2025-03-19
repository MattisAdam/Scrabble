using Scrabble;


namespace Scrable
{
    public class Game
    {
        public const int MaxLettersPerPlayer = 7;

        private Board _board;
        public List<Player> _players;

        LettersBag lettersBag;
        ScoreLetter Score;


        public Game()
        {
            _board = new Board();
            _players = new List<Player>();
            lettersBag = new LettersBag();
            Score = new ScoreLetter();
            
            _initPlayers();
            _board.Display();
        }

        public void Play()
        { 
            var nbRound = _nmbRoundPlay();
            int i = 0;
            while (nbRound != i)
            {
                Console.WriteLine($"Round {i + 1}");
                _roundPlay();
                i++;
            }
        }
        private static int _getNumbersOfplayers()
        {
            int maxPlayer = 5;
            int nmbPlayer = Fonction.EnterNumber($"How many players on the table ? Choose between 2 and {maxPlayer} players");
            while (nmbPlayer < 2 || nmbPlayer > 5)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Choose between 2 and {maxPlayer} players");
                Console.ResetColor();

                nmbPlayer = Fonction.EnterNumber($"How many players on the table ? Choose between 2 and {maxPlayer} players");
            }
            return nmbPlayer;
        }
        private void _initPlayers()
        {
            var numberOfPlayers = _getNumbersOfplayers();
            for (int i = 0; i < numberOfPlayers; i++)
            {
                var player = new Player();
                _players.Add(player);
            }
        }

        private void _roundPlay()
        {
            foreach (var _player in _players)
            {
                _player.PicklettersFromBag(lettersBag);
                Console.WriteLine();
                Console.WriteLine($"is {_player.Name}'s round");
                _player.ShowStatus();
                Console.WriteLine();
                var word = _player.ChooseWord();
                _board.PlaceWord(_player, word);
                _board.Display();
                _player.ShowStatus();
                Console.WriteLine();
                _player.PicklettersFromBag(lettersBag);
            }
        }

        private int _nmbRoundPlay()
        {
            return Fonction.EnterNumber("How many rounds do you want to play ?");
        }

    }
}

