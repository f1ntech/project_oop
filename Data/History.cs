using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Data
{
    public class History
    {
        public string CrossUser { get; set; }
        public string ZeroUser { get; set; }
        public string[] Field { get; set; }
        public string Winner { get; set; }
        public DateTime date { get; set; }
        
        public override string ToString()
        {
            return $"\n|CrossUser: {CrossUser}| ZeroUser: {ZeroUser}| Winner: {Winner}|Date: {date}|\n{FieldToString()}";
        }
        private string FieldToString()
        {
            string temp="";
            for (int i = 0; i < Field.Length; i++)
            {
                if ((i+1)%3!=0)
                {
                    temp += Field[i];
                    temp += " ";
                }
                else
                {
                    temp += Field[i];
                    temp += "\n";
                }    
            }
            return temp;
        }
    }
}
