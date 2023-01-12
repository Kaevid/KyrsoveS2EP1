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
    }
}
