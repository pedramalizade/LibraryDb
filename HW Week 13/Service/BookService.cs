using HW_Week_13.Entitis;
using HW_Week_13.Login_Register;
using HW_Week_13.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Week_13.Service
{
    public class BookService : ILibraryService
    {
        IUserRepository _userRepository;
        IBookRepository _bookRepository;
        public BookService()
        {
            _userRepository = new UserRepository();
            _bookRepository = new BookRepository();
        }
        public void BorrowBook(int bookId, int personId)
        {
            var user = _userRepository.GetById(personId);
            //var book = _bookRepository.GetBook(bookId);
            //user.Books.Add(book);
            
            _bookRepository.BorrowBook(bookId, user);
        }

        public List<Book> GetListOfLibraryBooks()
        {
            var List =  _bookRepository.GetListOfLibraryBooks();
            return List;
        }

        public void GetListOfUserBooks(int personId)
        {
             _bookRepository.GetListOfUserBooks(personId);
        }

        public void ReturnBook(int bookId, int personId)
        {
            //var user = _userRepository.GetById(personId);
            //var book = _bookRepository.GetBook(bookId);
            //user.Books.Remove(book);
            _bookRepository.ReturnBook(bookId);
        }
    }
}
