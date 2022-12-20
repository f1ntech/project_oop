using Project.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloApp.MVVM
{
    public interface IFileService
    {
        List<History> Open(string filename);
        void Save(List<History> historyList, string filename);
    }
}
