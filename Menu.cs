using Example2.Services;
using HelloApp.MVVM;
using Project.Data;
using Project.Service.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class Menu
    {
        IUserService _userService;
        IFileService _fileService;
        IHistoryService _historyService;
        DBContext _dBContext;
        string _filePath;

        public Menu(DBContext dBContext, string filePath)
        {
            _filePath = filePath;
            _dBContext = dBContext;
            _userService = new UserService(_dBContext);
            _fileService = new JsonFileService();
            _historyService = new HistoryService(_fileService.Open(_filePath));
        }

        public void StartGame()
        {
            while (true)
            {
                Console.Write(new string('-',50));
                Console.WriteLine("\nTo play = 1");
                Console.WriteLine("See the history of the games = 2");
                Console.WriteLine("View the game history of a particular player = 3");
                Console.WriteLine(new string('-', 50));


                int choice = 0;
                while (true)
                {
                    Console.Write("Your choice: ");
                    string temp = Console.ReadLine();
                    if (int.TryParse(temp,out choice))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Incorrect action selected");
                    }                        
                }                
                switch (choice)
                {
                    case 1:
                        Play();
                        break;
                    case 2:
                        SeeHistory();
                        break;
                    case 3:
                        HistoryOfPlayer();
                        break;
                    default:
                        break;
                }
            }
        }
        private void Play()
        {
            while (true)
            {
                Console.WriteLine("\nChoose who plays");
                User ZeroUser;
                User CroosUser;
                foreach (var item in _userService.Get())
                {
                    Console.Write(item.ToString());
                }
                Console.WriteLine();
                

                while (true)
                {
                    Console.Write("Zero Player: ");
                    ZeroUser = _userService.GetUserName(Console.ReadLine());
                    if (ZeroUser == null)
                    {
                        Console.WriteLine("No player found");
                    }
                    else { break; }
                }
                
                
                while (true)
                {
                    Console.Write("Croos Player: ");
                    CroosUser = _userService.GetUserName(Console.ReadLine());
                    if (ZeroUser == null)
                    {
                        Console.WriteLine("No player found");
                    }
                    else { break; }
                }
                
                Console.WriteLine("Game start");
                Game game = new(ZeroUser, CroosUser);


                while (game.End == false)
                {
                    int i = 0, j = 0;
                    Console.WriteLine($"\nPlayer:{game.CurentSide.UserName} \nSide: {game.CurentSide.Side}");
                    game.PrintField();

                    while (true)
                    {
                        Console.WriteLine("Input Row");
                        string temp = Console.ReadLine();

                        if (int.TryParse(temp, out i))
                        {
                            if (i > 0 && i <= 3)
                            {
                                i--;
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Goes out of bounds");
                            }
                        }
                        else
                        {
                            Console.WriteLine("No number entered");
                        }
                    }

                    while (true)
                    {
                        Console.WriteLine("Input Colum");
                        string temp = Console.ReadLine();

                        if (int.TryParse(temp, out j))
                        {
                            if (j > 0 && j <= 3)
                            {
                                j--;
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Goes out of bounds");
                            }
                        }
                        else
                        {
                            Console.WriteLine("No number entered");
                        }
                    }                   
                    game.Choice(i, j);
                }

                var History = game.CreateHistory();
                _historyService.Add(History);

                _fileService.Save(_historyService.Get(), _filePath);
                break;
            }
        }
        private void SeeHistory()
        {
            if (_historyService.Get().Count != 0)
            {
                foreach (var item in _historyService.Get())
                {
                    Console.WriteLine(item.ToString());
                }
            }
            else
            {
                Console.WriteLine("\nNo game has been played\n");
            }
        }
        private void HistoryOfPlayer()
        {
            Console.WriteLine("\nChoose whose story you want to watch");
            foreach (var item in _userService.Get())
            {
                Console.Write(item.ToString());
            }
            User user;
            while (true)
            {
                Console.Write("User Name:");
                user = _userService.GetUserName(Console.ReadLine());
                if (user == null)
                {
                    Console.WriteLine("No player found");
                }
                else { break; }
            }

            var history = _historyService.GetByName(user.UserName);
            if (history != null) 
            {
                if (history.Count == 0)
                {
                    Console.WriteLine($"\n{user.UserName} has not played any games");
                }
                foreach (var item in history)
                {
                    Console.WriteLine(item.ToString());
                }
            }
            else
            {
                Console.WriteLine("No player found");
            }            
        }
    }
}
