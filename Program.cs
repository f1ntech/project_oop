using Example2.Services;
using HelloApp.MVVM;
using Project.Data;
using Project.Service.Base;

namespace Project
{
    public class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new(new DBContext(), @"/Users/artembabenko/Desktop/Project-1/Project/Data/JsonFile/History");
            menu.StartGame();
        }       
    }
}