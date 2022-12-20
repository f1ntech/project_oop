using Project.Data;
using Project.Service.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Example2.Services
{
    public class UserService : IUserService
    {
        public DBContext DBContext_ { get; set; }
        public UserService(DBContext dBContext)
        {
            DBContext_ = dBContext;
        }
        public void Add(User user)
        {
            DBContext_.Users.Add(user);
        }

        public List<User> Get()
        {
            return DBContext_.Users;
        }
        public User GetUserName(string userName)
        {
            foreach (var item in DBContext_.Users)
            {
                if (userName == item.UserName)
                {
                    return item;
                }
            };
            return null;
        }
    }
}
