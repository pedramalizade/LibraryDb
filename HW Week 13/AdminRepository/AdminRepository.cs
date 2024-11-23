using HW_Week_13.DbContextt;
using HW_Week_13.Entitis;
using HW_Week_13.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Week_13.AdminRepository
{
    public class AdminRepository : IAdminRepository
    {
       
        AppDbContext _DbContext;
        public AdminRepository()
        {
            _DbContext = new AppDbContext();
        }
        public List<Book> ShowListOfBooks()
        {
            var books = _DbContext.Books.ToList();
            return books;
        }

        public List<User> ShowListOfUsers()
        {
            var users = _DbContext.Users.ToList();
            return users;
        }

        public void UpdateUser(int UserId)
        {
            var user = _DbContext.Users.FirstOrDefault(u => u.Id == UserId);
            user.UserName = "Hasan";
            _DbContext.SaveChanges();
        }
    }
}
