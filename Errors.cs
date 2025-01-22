namespace Scrable
{
    internal class Errors
    {
        public static int  NumberOfPlayer(string messageError = " (!) Do not choose more than four players and less than two players (!) ")
        {
            int numberPlayers = Game.AskNumbersOfPlayers();
            while (!(numberPlayers <= 5 && numberPlayers >= 2))
            {
                Console.WriteLine(" (!) Do not choose more than four players and less than two players (!) ");
                numberPlayers = Game.AskNumbersOfPlayers();
            }
           return numberPlayers;
        }
    }
}
