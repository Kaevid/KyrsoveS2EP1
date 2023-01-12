using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace KyrsoveS2EP1
{
    class Program
    {
        static int UserID;
        static int GameID;
        static void Main(string[] args)
        {
            Save save = new Save();
            Account Player1 = new Account();
            Account Player2 = new Account();

            JsonTextReader readingFile = new JsonTextReader(new StreamReader("C:\\Acc.json"));
            JsonSerializer serialize = new JsonSerializer();
            save.Accounts = serialize.Deserialize<List<Account>>(readingFile);
            readingFile.Close();
            readingFile = new JsonTextReader(new StreamReader("C:\\Game.json"));
            save.GameList = serialize.Deserialize<List<GameStats>>(readingFile);
            readingFile.Close();

            UserID = save.Accounts.Count;
            GameID = save.GameList.Count;

            Console.WriteLine("F1-Вiйти в акаунт першого гравця");
            Console.WriteLine("F2-Створити акаунт для першого гравця");
            string firstname = "";
            authorizationPlayer1:
            ConsoleKey key = Console.ReadKey().Key;
            switch (key)
            {
                case ConsoleKey.F1:
                    Console.WriteLine("\nВхiд в акаунт другого гравця: ");
                    Console.Write("Введiть iм'я гравця: ");
                    firstname = Console.ReadLine();
                    for (int i = 0; i < save.Accounts.Count; i++)
                    {
                        if (firstname == save.Accounts[i].UserName)
                        {
                            enterPassword:
                                Console.Write("Введiть пароль: ");
                                string password = Console.ReadLine();
                                Hash hash = new Hash(); 
                                password = hash.GetHash(password);
                                if(password == save.Accounts[i].Password)
                                {
                                    Player1 = new Account(save.Accounts[i].UserName, save.Accounts[i].Password, save.Accounts[i].UserID);
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Неправильни пароль.");
                                    goto enterPassword;
                                }
                        }
                        else if (i == save.Accounts.Count - 1)
                        {
                            Console.WriteLine("\nНема такого гравця. ");
                            Console.Write("\nВведiть iм'я гравця: ");
                            firstname = Console.ReadLine();
                            i = -1;
                        }
                    }
                    break;
                case ConsoleKey.F2:
                    Console.WriteLine("\nСтворення акаунту для першого гравця: ");
                    Console.Write("Введiть iм'я гравця: ");
                    string name = Console.ReadLine();
                    for (int i = 0; i < save.Accounts.Count; i++)
                    {
                        if(name == save.Accounts[i].UserName)
                        {
                            Console.WriteLine("Таке iм'я гравця вже є.");
                            Console.Write("\nВведiть iнше iм'я гравця: ");
                            name = Console.ReadLine();
                            i = 0;
                        }
                    }
                    Console.Write("Введiть пароль: ");
                    string password1 = Console.ReadLine();
                    Hash hash1 = new Hash();
                    password1 = hash1.GetHash(password1);
                    UserID++;
                    save.Accounts.Add(Player1 = new Account(name, password1, UserID));
                    break;
                default:
                    Console.WriteLine("Не та кнопка");
                    goto authorizationPlayer1;
            }

            Console.WriteLine("\nF1-Вiйти в акаунт другого гравця");
            Console.WriteLine("F2-Створити акаунт для другого гравця");

            authorizationPlayer2:
            key = Console.ReadKey().Key;
            switch (key)
            {
                case ConsoleKey.F1:
                    Console.WriteLine("\nВхiд в акаунт другого гравця: ");
                    Console.Write("Введiть iм'я гравця: ");
                    string name = Console.ReadLine();
                    for (int i = 0; i < save.Accounts.Count; i++)
                    {
                        if (name == save.Accounts[i].UserName && name != firstname)
                        {
                        enterPassword:
                            Console.Write("Введiть пароль: ");
                            string password2 = Console.ReadLine();
                            Hash hash2 = new Hash();
                            password2 = hash2.GetHash(password2);
                            if (password2 == save.Accounts[i].Password)
                            {
                                Player2 = new Account(save.Accounts[i].UserName, save.Accounts[i].Password, save.Accounts[i].UserID);
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Неправильни пароль.");
                                goto enterPassword;
                            }
                        }
                        else if (i == save.Accounts.Count - 1 || name == firstname)
                        {
                            Console.WriteLine("\nНема такого гравця. ");
                            Console.Write("\nВведiть iм'я гравця: ");
                            name = Console.ReadLine();
                            i = -1;
                        }
                    }
                    break;
                case ConsoleKey.F2:
                    Console.WriteLine("\nСтворення акаунту для другого гравця: ");
                    Console.Write("Введiть iм'я гравця: ");
                    string name2 = Console.ReadLine();
                    for (int i = 0; i < save.Accounts.Count; i++)
                    {
                        if (name2 == save.Accounts[i].UserName)
                        {
                            Console.WriteLine("Таке iм'я гравця вже є.");
                            Console.Write("\nВведiть iнше iм'я гравця: ");
                            name2 = Console.ReadLine();
                            i = 0;
                        }
                    }
                    Console.Write("Введiть пароль: ");
                    string password = Console.ReadLine();
                    Hash hash = new Hash();
                    password = hash.GetHash(password);
                    UserID++;
                    save.Accounts.Add(Player2 = new Account(name2, password, UserID));
                    break;
                default:
                    Console.WriteLine("Не та кнопка");
                    goto authorizationPlayer2;
            }

            menu:
            Console.Clear();
            Console.WriteLine("F1-Грати в Хрестики Нулики");
            Console.WriteLine("F2-Статистика першого гравця");
            Console.WriteLine("F3-Статистика другого гравця");
            Console.WriteLine("F4-Вивисти список профiлiв");
            Console.WriteLine("F5-Зберегти i вийти");
            key = Console.ReadKey().Key;
            switch (key) {
                case ConsoleKey.F1:
                    Game game = new Game();
                    GameID++;
                    save.GameList.Add(game.StartGame(Player1, Player2, 25, GameID, save));
                    goto menu;
                case ConsoleKey.F2:
                    Console.Clear();
                    Console.WriteLine($"Статистика {(Player1.UserName)}: ");
                    save.PrintGameList(Player1);
                    Console.Write("Натиснiть Любу кнопку щоб продовжити");
                    Console.ReadKey();
                    goto menu;
                case ConsoleKey.F3:
                    Console.Clear();
                    Console.WriteLine($"Статистика {(Player2.UserName)}: ");
                    save.PrintGameList(Player2);
                    Console.Write("Натиснiть Любу кнопку щоб продовжити");
                    Console.ReadKey();
                    goto menu;
                case ConsoleKey.F4:
                    save.PrintAccountList();
                    Console.Write("Натиснiть Любу кнопку щоб продовжити");
                    Console.ReadKey();
                    goto menu;
                case ConsoleKey.F5:
                    
                    File.WriteAllText("C:\\Acc.json", string.Empty);
                    File.AppendAllText("C:\\Acc.json", JsonConvert.SerializeObject(save.Accounts));
                    File.WriteAllText("C:\\Game.json", string.Empty);
                    File.AppendAllText("C:\\Game.json", JsonConvert.SerializeObject(save.GameList));
                    break;
                default:
                    Console.WriteLine("Не та кнопка");
                    goto menu;
            }
        }
    }
}
