using System;
using System.Collections.Generic;
using System.Text;

namespace KyrsoveS2EP1
{
    class Save
    {
        public List<Account> Accounts = new List<Account>();
        public List<GameStats> GameList = new List<GameStats>();
        public void PrintAccountList()
        {
            for (int i = 0; i < Accounts.Count; i++)
            {
                Console.WriteLine("\nIм'я: " + Accounts[i].UserName);
                Console.WriteLine("Пароль: " + Accounts[i].Password);
                Console.WriteLine("ID: " + Accounts[i].UserID);
                Console.WriteLine("Рейтинг: " + Accounts[i].Rating);
            }
        }
        public void PrintGameList(Account p1)
        {
            for(int i = 0; i < GameList.Count; i++)
            {
                if(p1.UserName == GameList[i].PlaerX || p1.UserName == GameList[i].PlaerO)
                {
                    Console.WriteLine("ID гри: " + GameList[i].GameID);
                    Console.WriteLine("Гравець Х: " + GameList[i].PlaerX);
                    Console.WriteLine("Гравець O: " + GameList[i].PlaerO);
                    Console.WriteLine("Рейтинг: " + GameList[i].Rating);
                    if (GameList[i].IsP1 == Winner.WinX)
                    {
                        Console.WriteLine("Результат: Виграли Х, Гравець " + GameList[i].PlaerX);
                    }else if(GameList[i].IsP1 == Winner.WinO)
                    {
                        Console.WriteLine("Результат: Виграли Х, Гравець " + GameList[i].PlaerO);
                    }
                    else
                    {
                        Console.WriteLine("Результат: Нiчiя");
                    }
                    Console.WriteLine("\n\n\n");
                }
            }
        }
    }
}
