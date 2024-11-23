using HW_Week_13.Entitis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Week_13.Service
{
    public interface ILibraryService
    {
        public void BorrowBook(int bookId, int personId);
        public void ReturnBook(int bookId, int personId);
        public List<Book> GetListOfLibraryBooks();
        public void GetListOfUserBooks(int personId);
    }
}
