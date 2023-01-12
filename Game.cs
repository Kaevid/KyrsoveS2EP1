using System;
using System.Collections.Generic;
using System.Text;

namespace KyrsoveS2EP1
{
    public enum Winner
    {
        WinX,
        WinO,
        Nichua
    }
    class Game
    {
        Save save = new Save();
        private Winner winner;

        public GameStats StartGame(Account x, Account o, int rating, int GameID, Save save)
        {
            Console.Clear();
            bool end = false, boolTurn = true;
            string[,] field = new string[3, 3]
            {
                 { "1", "2", "3" },
                 { "4", "5", "6" },
                 { "7", "8", "9" }
            };
            winner = Winner.Nichua;
            for (int i = 0; i < 9; i++)
            {
                Console.WriteLine(x.UserName + "-грає за X\t" + o.UserName + "-грає за O");
                if (boolTurn)
                {
                    Console.WriteLine("Хiд X");
                }
                else
                {
                    Console.WriteLine("Хiд O");
                }
                DrawField(field);
                end = Final(field, "X");
                if (!end)
                {
                    end = Final(field, "O");
                }
                if (end)
                {
                    break;
                }
                boolTurn = Turn(field, boolTurn);
                if(i == 8)
                {
                    end = Final(field, "X");
                    if (!end)
                    {
                        end = Final(field, "O");
                    }
                    break;
                }
                Console.Clear();
            }
            if (winner != Winner.Nichua)
            {
                bool isP1 = true;
                save.Accounts[x.UserID - 1].Rating += rating;
                save.Accounts[o.UserID - 1].Rating -= rating;
                if (winner == Winner.WinO)
                {
                    isP1 = false;
                    save.Accounts[x.UserID - 1].Rating -= rating * 2;
                    save.Accounts[o.UserID - 1].Rating += rating * 2;
                }
                Console.WriteLine($"Виграв гравець {(isP1 ? x.UserName : o.UserName)}");
            }
            else
            {
                Console.WriteLine("Нiчия");
            }
            Console.Write("Натиснiть Любу кнопку щоб продовжити");
            Console.ReadKey();
            return new GameStats(winner, x.UserName, o.UserName, GameID, rating);
        }

        private void DrawField(string[,] field)
        {
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("|---|-|---|-|---|");
                for (int j = 0; j < 3; j++)
                {
                    Console.Write("| " + field[i, j] + " | ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("|---|-|---|-|---|");
        }
        private bool Turn(string[,] field, bool hid)
        {
            turnN:
            Console.WriteLine("Оберiть комiрку в яку ви хочете поставити хрестик");
            Console.Write("Ведiть номер вiльної ячейки");
            ConsoleKey key = Console.ReadKey().Key;
            if(key == ConsoleKey.D1)
            {
                if (field[0, 0] == "1")
                {
                    field[0, 0] = hid ? "X" : "O";
                }
                else
                {
                    Console.WriteLine("\nЦя комiрка вже зайнята!");
                    goto turnN;
                }

            }
            else if (key == ConsoleKey.D2)
            {
                if (field[0, 1] == "2")
                {
                    field[0, 1] = hid ? "X" : "O";
                }
                else
                {
                    Console.WriteLine("\nЦя комiрка вже зайнята!");
                    goto turnN;
                }
            }
            else if (key == ConsoleKey.D3)
            {
                if (field[0, 2] == "3")
                {
                    field[0, 2] = hid ? "X" : "O";
                }
                else
                {
                    Console.WriteLine("\nЦя комiрка вже зайнята!");
                    goto turnN;
                }
            }
            else if (key == ConsoleKey.D4)
            {
                if (field[1, 0] == "4")
                {
                    field[1, 0] = hid ? "X" : "O";
                }
                else
                {
                    Console.WriteLine("\nЦя комiрка вже зайнята!");
                    goto turnN;
                }
            }
            else if (key == ConsoleKey.D5)
            {
                if (field[1, 1] == "5")
                {
                    field[1, 1] = hid ? "X" : "O";
                }
                else
                {
                    Console.WriteLine("\nЦя комiрка вже зайнята!");
                    goto turnN;
                }
            }
            else if (key == ConsoleKey.D6)
            {
                if (field[1, 2] == "6")
                {
                    field[1, 2] = hid ? "X" : "O";
                }
                else
                {
                    Console.WriteLine("\nЦя комiрка вже зайнята!");
                    goto turnN;
                }
            }
            else if (key == ConsoleKey.D7)
            {
                if (field[2, 0] == "7")
                {
                    field[2, 0] = hid ? "X" : "O";
                }
                else
                {
                    Console.WriteLine("\nЦя комiрка вже зайнята!");
                    goto turnN;
                }
            }
            else if (key == ConsoleKey.D8)
            {
                if (field[2, 1] == "8")
                {
                    field[2, 1] = hid ? "X" : "O";
                }
                else
                {
                    Console.WriteLine("\nЦя комiрка вже зайнята!");
                    goto turnN;
                }
            }
            else if (key == ConsoleKey.D9)
            {
                if (field[2, 2] == "9")
                {
                    field[2, 2] = hid ? "X" : "O";
                }
                else
                {
                    Console.WriteLine("\nЦя комiрка вже зайнята!");
                    goto turnN;
                }
            }
            else
            {
                Console.WriteLine("Нема такоi комiрки");
                goto turnN;
            }
            Console.WriteLine();
            return hid = hid ? false : true;
        }
        private bool Final(string[,] field, string XO)
        {
            Winner turn = Winner.WinX;
            if(XO == "O")
            {
                turn = Winner.WinO;
            }
            bool end = false;
            if (field[0, 0] == XO && field[0, 1] == XO && field[0, 2] == XO)
            {
                end = true;
                winner = turn;
            } else if (field[1, 0] == XO && field[1, 1] == XO && field[1, 2] == XO) {
                end = true;
                winner = turn;
            }
            else if (field[2, 0] == XO && field[2, 1] == XO && field[2, 2] == XO)
            {
                end = true;
                winner = turn;
            }
            else if (field[0, 0] == XO && field[1, 0] == XO && field[2, 0] == XO)
            {
                end = true;
                winner = turn;
            }
            else if (field[0, 1] == XO && field[1, 1] == XO && field[2, 1] == XO)
            {
                end = true;
                winner = turn;
            }
            else if (field[0, 2] == XO && field[1, 2] == XO && field[2, 2] == XO) 
            {
                end = true;
                winner = turn;
            }
            else if (field[0, 2] == XO && field[1, 1] == XO && field[2, 0] == XO)
            {
                end = true;
                winner = turn;
            }
            else if (field[0, 0] == XO && field[1, 1] == XO && field[2, 2] == XO)
            {
                end = true;
                winner = turn;
            }

            return end;
        }
    }
}
