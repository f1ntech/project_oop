using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Data
{
    public class DBContext
    {
        public List<User> Users { get; set; }

        public DBContext()
        {
            Users = new List<User>
            { 
                new User("Max"),
                new User("Artem"),
                new User("Sanya"),
            }; 
        }
    }
}
