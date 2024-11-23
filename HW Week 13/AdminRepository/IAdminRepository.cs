using HW_Week_13.Entitis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Week_13.AdminRepository
{
    public interface IAdminRepository
    {
        public List<Book> ShowListOfBooks();
        public List<User> ShowListOfUsers();
        public void UpdateUser(int UserId);

    }
}
