﻿namespace Scrable
{
    public class Score
    {
        // do a dico with letter and point
        public void oui() 
        {
           var Game = new Game();
            for (var i = 0; i < Game._players.Count; i++)
            {
                Console.WriteLine(Game._players[i]);
                Console.WriteLine("Miaou");
            }
            
        }
    }
}
