using HW_Week_13.DbContextt;
using HW_Week_13.Entitis;
using HW_Week_13.Enum;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Week_13.Login_Register
{
    public class UserRepository : IUserRepository
    {
        User LoggedIn = null;
        private readonly AppDbContext _appDbContext;

        public UserRepository()
        {
            _appDbContext = new AppDbContext();
        }

        public User GetById(int id)
        {
            return _appDbContext.Users.FirstOrDefault(u => u.Id == id);
        }

        public User Login(string username, string password, RoleEnum role)
        {
            var user = _appDbContext.Users.FirstOrDefault(t => t.UserName == username && t.Password == password);
            if (user != null)
            {
                InMemoryDb.OnlineUser = user;
                return user;

            }
            else
            {
                Console.WriteLine("Cannot LogIn!");
                return null;
            }
        }

        public void Logout()
        {
            InMemoryDb.OnlineUser = null;
        }

        public bool Register(User user)
        {
            var username = _appDbContext.Users.FirstOrDefault(t => t.UserName == user.UserName && t.Password == user.Password);
            if (username != null)
            {
                return false;
            }
            _appDbContext.Users.Add(user);
            InMemoryDb.OnlineUser = user;
            _appDbContext.SaveChanges();
            return true;
        }
    }
}
