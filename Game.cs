﻿using System.Security.Cryptography;

namespace Scrable
{
    public class Game
    {
        private GenerateBoard _board = new GenerateBoard();
        private List<Player> _players = new List<Player>();
        public readonly static int MaxLettersPerPlayer = 7;

        public void InitGame()
        {
            LettersBag.InitLettersBag();
            InitPlayers();

            foreach (var player in _players) {
                Console.WriteLine(player.Name);
                player.Rack.DisplayRack();
            }

            _board.InitBoard();
            _board.Display();
        }

        public void InitPlayers()
        {
            var numberOfPlayers = GetNumbersOfplayers();
            var playerNames = AskNameOfPlayers(numberOfPlayers);
            foreach (var playerName in playerNames) {
                var player = new Player(playerName, new Rack());
                _players.Add(player);
            }
        }

        public int GetNumbersOfplayers()
        {
            int numberPlayers = Errors.NumberOfPlayer();
            return numberPlayers;
        }
        public static int AskNumbersOfPlayers()
        {
            Console.WriteLine("How many players on the table ?");
            var numberPlayers = Fonction.EnterNumber();
            return numberPlayers;
        }
        
        public List<string> AskNameOfPlayers(int numberOfPlayers)
        {
            var listPlayers = new List<string>();

            for (int i = 0; i < numberOfPlayers; i++)
            {
                Console.Write($"what the player {i + 1}'s name ?\n");
                var playerName = Fonction.EnterString();
                listPlayers.Add(playerName);
            }
            return listPlayers;
        }
    }
}