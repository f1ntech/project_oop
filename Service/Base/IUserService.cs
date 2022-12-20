using Project.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Service.Base
{
    public interface IUserService
    {
        public List<User> Get();
        public void Add(User user);
        public User GetUserName(string userName);
    }
}
