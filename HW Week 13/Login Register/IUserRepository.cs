using HW_Week_13.Entitis;
using HW_Week_13.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Week_13.Login_Register
{
    public interface IUserRepository
    {
        public bool Register(User user);
        public User Login(string username, string password, RoleEnum role);
        public User GetById(int id);
        public void Logout();
    }
}
