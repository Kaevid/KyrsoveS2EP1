using System;
using System.Collections.Generic;
using System.Text;

namespace KyrsoveS2EP1
{
    class Account
    {
        public string UserName { get; set; }
        public int UserID { get; set; }
        public int Rating { get; set; }
        public string Password { get; set; }

        public Account() { }
        public Account(string name, string password, int id)
        {
            UserName = name;
            UserID = id;
            Password = password;
            Rating = 100;
        }
    }
}
