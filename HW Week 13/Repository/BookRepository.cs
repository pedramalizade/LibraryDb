using HW_Week_13.Configs;
using HW_Week_13.DbContextt;
using HW_Week_13.Entitis;
using HW_Week_13.Login_Register;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HW_Week_13.Repository
{
    public class BookRepository : IBookRepository
    {
        IUserRepository _userRepository;
        AppDbContext _DbContext;

        public BookRepository()
        {
            _userRepository = new UserRepository();
            _DbContext = new AppDbContext();
        }

        public void BorrowBook(int bookId, User user)
        {
            var targetBook = _DbContext.Books.FirstOrDefault(b => b.Id == bookId);
            targetBook.IsBorrowed = true;
            targetBook.UserId = user.Id;
            targetBook.User = user;
            _DbContext.SaveChanges();
        }

        public Book GetBook(int bookId)
        {
            return _DbContext.Books.FirstOrDefault(u => u.Id == bookId);
        }

        public List<Book> GetListOfLibraryBooks()
        {
            var ListBook = _DbContext.Books.ToList();
            return ListBook;
        }

        public void GetListOfUserBooks(int personId)
        {
            //var user = _DbContext.Users.Include(u=>u.Books).FirstOrDefault(u => u.Id == personId);
            //if (user == null)
            //{
            //    Console.WriteLine("User Not Found. ");
            //    return;
            //}
            //Console.WriteLine($"Books Borrowed by {user.Name}: ");
            var ListBook = _DbContext.Books.ToList();
            foreach (var book in ListBook)
            {
                if (book.IsBorrowed && book.UserId == personId)
                {
                    var x = ($"__Id = {book.Id} || Name = {book.Title} || Price = {book.Price} || DateTime = {book.Borrowdate}");
                    Console.WriteLine(x);
                }
            }
            //var user = _userRepository.GetById(personId);
            //var Books = _DbContext.Books.ToList();
            //var result = $"{user}'s Books Are : {Books}";

        }

        public void ReturnBook(int bookId)
        {
            var targetBook = _DbContext.Books.FirstOrDefault(b => b.Id == bookId);
            targetBook.IsBorrowed = false;
            targetBook.User = null;
            targetBook.UserId = null;
            _DbContext.SaveChanges();
        }
    }
}
