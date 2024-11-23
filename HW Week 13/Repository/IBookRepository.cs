using HW_Week_13.Entitis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Week_13.Repository
{
    public interface IBookRepository
    {
        public void BorrowBook(int bookId, User user);
        public void ReturnBook(int bookId);
        public List<Book> GetListOfLibraryBooks();
        public void GetListOfUserBooks(int personId);
        public Book GetBook(int bookId);
    }
}
