using Project.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Service.Base
{
    public interface IHistoryService
    {
        public List<History> Get();
        public void Add(History history);
        public List<History> GetByName(string UserName);
    }
}
