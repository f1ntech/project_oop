using System.Net.NetworkInformation;
using System.Reflection;

namespace Project.Data
{
    public class Game
    {
        public bool End { get; set; }
        public User? CurentSide { get; set; }

        private User? _zeroUser;
        private User? _croosUser;
        private string[,] field  = {{ ".", ".", "." },{ ".", ".", "." }, { ".", ".", "." } };       
        private string _status;

        public Game(User ZeroUser,User CroosUser)
        {
            _zeroUser = ZeroUser;
            ZeroUser.Side = "0";
            _croosUser = CroosUser;
            CroosUser.Side = "X";
            CurentSide = _croosUser;
        }
        
        public void Choice(int i, int j)
        {
            if (End == false)
            {
                if (PlaceCheck(field) == true)
                {
                    if (OccupiedSeat(i, j) == false)
                    {
                        field[i, j] = CurentSide.Side;

                        if (GameOverCheck(field, CurentSide.Side) == true)
                        {
                            Console.WriteLine($"|Player {CurentSide.UserName} win Side:{CurentSide.Side} |");
                            End = true;
                        }
                        if (PlaceCheck(field) == false)
                        {
                            Console.WriteLine("Nobody");
                            End = true;
                        }
                        if (End == false)
                        {
                            if (CurentSide.Side == _croosUser.Side)
                            {
                                CurentSide = _zeroUser;
                            }
                            else
                            {
                                CurentSide = _croosUser;
                            }
                        }                        
                    }
                    else
                    {
                        Console.WriteLine("The place is occupied");
                    }
                }
                else
                {
                    End = true;
                    _status = "Nobody";
                    Console.WriteLine("Nobody");
                }
            }
            else
            {
                Console.WriteLine("Game over");
                Console.WriteLine($"{CurentSide.Side} win");
            }

        }
        private bool OccupiedSeat(int i ,int j)
        {
            if (field[i, j] == ".")
            {
                return false;
            }
            return true;
        }
        private bool GameOverCheck(string[,] field, string answer)
        {
            return ColumnCheck(field, answer) || LineCheck(field, answer) || MainDiagonalCheck(field, answer) || SideDiagonalCheck(field, answer);
        }
        private bool PlaceCheck(string[,] field)
        {
            foreach (var item in field)
            {
                if (item == ".")
                {
                    return true;
                }
            }
            return false;
        }
        private bool ColumnCheck(string[,] field, string answer)
        {
            bool win = false;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (field[i, j] == answer)
                    {
                        win = true;
                    }
                    else
                    {
                        win = false;
                        break;
                    }
                }
                if (win == true)
                {
                    return win;
                }
            }
            return win;
        }
        private bool LineCheck(string[,] field, string answer)
        {
            bool win = false;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (field[j, i] == answer)
                    {
                        win = true;
                    }
                    else
                    {
                        win = false;
                        break;
                    }
                }
                if (win == true)
                {
                    return win;
                }
            }
            return win;
        }
        private bool MainDiagonalCheck(string[,] field, string answer)
        {
            bool win = false;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (i == j)
                    {
                        if (field[j, i] == answer)
                        {
                            win = true;
                        }
                        else
                        {
                            win = false;
                            break;
                        }
                    }
                }
                if (win == false)
                {
                    break;
                }
            }
            return win;
        }
        private bool SideDiagonalCheck(string[,] field, string answer)
        {
            bool win = false;
            for (int i = 0; i < 3; i++)
            {
                if (field[i, field.GetLength(0) - 1 - i] == answer)
                {
                    win = true;
                }
                else
                {
                    win = false;
                    break;
                }
            }
            return win;
        }
        public void PrintField()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write($"{field[i, j]} ");
                }
                Console.WriteLine();
            }
        }
        public History CreateHistory()
        {
            var History  = new History();
            History.ZeroUser = _zeroUser.UserName;
            History.CrossUser = _croosUser.UserName;
            History.Winner = (_status == "Nobody")?"Nobody":CurentSide.UserName;
            History.Field = toArray(field);
            History.date = DateTime.Now;

            return History;
        }
        private string[] toArray(string[,] field)
        {
            string[] fieldn= new string[9];
            int i = 0;
            foreach (var item in field)
            {
                fieldn[i++] = item;
            }
            return fieldn;
        }
    }
}
