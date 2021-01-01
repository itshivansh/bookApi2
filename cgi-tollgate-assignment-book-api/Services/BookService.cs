using cgi_tollgate_assignment_book_api.DAL;
using cgi_tollgate_assignment_book_api.Exceptions;
using cgi_tollgate_assignment_book_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cgi_tollgate_assignment_book_api.Services
{
    public class BookService : IBookService
    {
        /*
        Use constructor Injection to inject all required dependencies.
        */
        private readonly IBookRepository repo;
        public BookService(IBookRepository _repo)
        {
            repo = _repo;
        }

        /*
	    * This method should be used to save a new book.
	    */
        public Book AddBook(Book book)
        {
            var b= repo.AddBook(book);
            return b;
        }

        /* This method should be used to delete an existing book.
         * Throw BookNotFoundException in case book not found based on specified bookId. 
         */
        public bool DeleteBook(int id)
        {
            bool b = repo.DeleteBook(id);
            if (b)
            {
                return true;
            }
            else
            {
                throw new BookNotFoundException($"Book with id: {id} does not exists");
            }
        }

        /* This method should be used to get a book by bookId. 
         * Throw BookNotFoundException in case book not found based on specified bookId.
         */
        public Book GetBookById(int id)
        {
            Book b = repo.GetBookById(id);
            if(b!=null)
            {
                return b;
            }
            else
            {
                throw new BookNotFoundException($"Book with id: {id} does not exists");

            }
        }

        /* This method should be used to get a book all books. */
        public List<Book> GetBooks()
        {
            List<Book> b = repo.GetBooks();
            return b;
        }

        /* This method should be used to update a book by bookId.
         * Throw BookNotFoundException in case book not found based on specified bookId. 
         */
        public bool UpdateBook(int id, Book book)
        {
            bool b = repo.UpdateBook(id, book);
            if (b ==false)
            {
                throw new BookNotFoundException($"Book with id: {id} does not exists");
            }
            else
            {
                return true;
            }
        }
    }
}
