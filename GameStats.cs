using System;
using System.Collections.Generic;
using System.Text;

namespace KyrsoveS2EP1
{
    class GameStats
    {
        //Змінна в якій зберігається хто виграв true-хрестики, false-нолики
        public bool IsP1 { get; set; }
        public string PlaerX { get; set; }
        public string PlaerO { get; set; }
        //За кого грав гравець хрестики чи нулики
        public int GameID { get; set; }
        public int Rating { get; set; }

        public GameStats(bool isp1, string x, string o, int gameID, int rating)
        {
            IsP1 = isp1;
            PlaerX = x;
            PlaerO = o;
            GameID = gameID;
            Rating = rating;
        }
    }
}
