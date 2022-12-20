using Project.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace HelloApp.MVVM
{
    public class JsonFileService : IFileService
    {
        public List<History>? Open(string filename)
        {
            List<History>? history = new List<History>();
            var jsonFormatter = new DataContractJsonSerializer(typeof(List<History>));
            using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
            {
                history = jsonFormatter.ReadObject(fs) as List<History>;
            }
            return history;
        }

        public void Save(List<History> historyList, string filename)
        {
            var jsonFormatter = new DataContractJsonSerializer(typeof(List<History>));
            using (FileStream fs = new FileStream(filename, FileMode.Create))
            {
                jsonFormatter.WriteObject(fs, historyList);
            }
        }
    }
}
