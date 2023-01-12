using System;
using System.Collections.Generic;
using System.Text;

namespace KyrsoveS2EP1
{
    class Game
    {
        Save save = new Save();
        private bool Winner;

        public GameStats StartGame(Account x, Account o, int rating, int GameID)
        {
            bool end = false, turn = true;
            while (end)
            {
                Console.WriteLine(x.UserName + "-грає за X\t" + "гра за O-" + o.UserName);
                if (turn)
                {
                    Console.WriteLine("Хід X");
                }
                else
                {
                    Console.WriteLine("Хід O");
                }
            }




            return new GameStats(Winner, x.UserName, o.UserName, GameID, rating);
        }
    }
}
