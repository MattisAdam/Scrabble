namespace Scrable
{
    public class Name : Player
    {
        List<string> listPlayers = new List<string>();
        public Name(string name) : base(name) { }
        public void InitPlayersName()
        {
            var numberOfPlayers = GetNumbersOfplayers();
            AskNameOfPlayers(numberOfPlayers);
            ShowLettersForPlayers();

        }
        public int GetNumbersOfplayers()
        {
            var numberPlayers = 99999;
            numberPlayers = AskNumbersOfPlayers();
            while (!(numberPlayers <= 5 && numberPlayers >= 2))
            {
                Console.WriteLine(" (!) Do not choose more than four players and less than two players (!) ");
                numberPlayers = AskNumbersOfPlayers();
            }
            return numberPlayers;
        }
        public static int AskNumbersOfPlayers()
        {
            Console.WriteLine("How many players on the table ?");
            var numberPlayers = Fonction.EnterNumber();
            return numberPlayers;
        }
        public string AskNameOfPlayers(int numberOfPlayers)
        {
            string playerName = " ";
            for (int i = 0; i < numberOfPlayers; i++)
            {

                Console.Write($"what the player {i + 1}'s name ?\n");
                playerName = Fonction.EnterString();
                listPlayers.Add(playerName);
            }
            return playerName;
        }

        public void ShowNamesPlayersOnTheList()
        {
            //use only in case of debug
            Console.WriteLine("Here they are : ");
            for (int i = 0; i < listPlayers.Count; i++)
            {
                Console.Write(listPlayers[i]);
                if (i < listPlayers.Count - 1)
                {
                    Console.Write(',');
                }

            }
            Console.WriteLine(" ");
        }
        public void ShowLettersForPlayers()
        {


            for (int i = 0; i < listPlayers.Count(); i++)
            {
                var handPlayer = new Hand();
                Console.WriteLine(" ");
                Console.WriteLine($"Letters for {listPlayers[i]} : ");
                handPlayer.DisplayHand();

            }
        }


    }
}
