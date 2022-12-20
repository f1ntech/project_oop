using Project.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Service.Base
{
    public class HistoryService : IHistoryService
    {
        private List<History> _histories;

        public HistoryService(List<History> histories)
        {
            _histories = histories;
        }

        public void Add(History history)
        {
            _histories.Add(history);
        }

        public List<History> Get()
        {
            return _histories;
        }
        public List<History> GetByName(string UserName)
        {
            return _histories.Where(x => x.ZeroUser == UserName || x.CrossUser== UserName).ToList();
        }
    }
}
