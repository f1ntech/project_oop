using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Data
{
    public class User
    {
        public string? UserName { get; set; }
        public string? Side { get; set;}

        public User(string UserName)
        {
            this.UserName = UserName;
        }

        public override string ToString()
        {
            return $"| UserName:{UserName}|\n";
        }
    }
}
