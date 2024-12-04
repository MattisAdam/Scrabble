using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Channels;

namespace Scrable
{
    public class Game
    {
        private GenerateBoard _board = new GenerateBoard();
        private List<Player> _players = new List<Player>();
        
        
        int maxPlayers = 4;
       

        public void InitGame()
        {
            LettersBag.InitLettersBag();

            var namePlayer = new Name(" ");
            namePlayer.InitPlayersName();
            _board.InitBoard();
            Random getRandomPositionOnLettersBag = new Random();
            int randomPosition = getRandomPositionOnLettersBag.Next(LettersBag.NumberPiecesInBag());
            ValideWords.LoadWords("J:/Various/Home/NEW_Personal_Files/LEF/Scrable/DictionnaryLoader.txt");

            




            //ShowNamesPlayersOnTheList();

            //Donner une main aux joueurs (player.Hand)
            //1.Aller piocher 7 lettres dans Letters (LettersBag), mettre a jour le dictionnaire avec le nombre de lettre qu'il reste
            //2. Les donner aux joueurs (Player.Hand)
            _board.Display();
            

        }

        
        
        


        public void ShowLettersForOnePlayer()
        {
        }
    }
    }


