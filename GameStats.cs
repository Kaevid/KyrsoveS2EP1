using System;
using System.Collections.Generic;
using System.Text;

namespace KyrsoveS2EP1
{
    class GameStats
    {
        public Winner IsP1 { get; set; }
        public string PlaerX { get; set; }
        public string PlaerO { get; set; }
        public int GameID { get; set; }
        public int Rating { get; set; }

        public GameStats(Winner isp1, string x, string o, int gameID, int rating)
        {
            IsP1 = isp1;
            PlaerX = x;
            PlaerO = o;
            GameID = gameID;
            Rating = rating;
        }
    }
}
