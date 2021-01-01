using cgi_tollgate_assignment_book_api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cgi_tollgate_assignment_book_api.DAL
{
    public class BookRepository : IBookRepository
    {
        /*
       Use constructor Injection to inject all required dependencies.
       */
        private readonly BookDataContext db;
        public BookRepository(BookDataContext _db)
        {
            db = _db;
        }
        /*
      * This method should be used to save a new book.
      */
        public Book AddBook(Book book)
        {
            db.Books.Add(book);
            db.SaveChanges();
            return book;
        }

        /*
       * This method should be used to delete an existing book.
       */
        public bool DeleteBook(int id)
        {
            Book book;
            book = db.Books.Find(id);
            if (book == null)
            {
                return false;
            }
            else
            {
                db.Books.Remove(book);
                db.SaveChanges();
                return true;
            }
        }

        /*
       * This method should be used to get a book base on specified bookId.
       */
        public Book GetBookById(int id)
        {
            Book b = null;
            b = db.Books.Find(id);
            return b;
        }

        /*
       * This method should be used to retreive all books.
       */
        public List<Book> GetBooks()
        {
            var book = db.Books.ToList();
            return book;
        }

        /*
       * This method should be used to update an existing book based on specified bookId.
       */
        public bool UpdateBook(int id, Book book)
        {
            var b = db.Books.Where(m => m.BookId == id).FirstOrDefault<Book>();
            if(b != null)
            {
                b.BookName = book.BookName;
                b.AuthorName = book.AuthorName;
                b.Genre = book.Genre;
                b.Price = book.Price;
                db.SaveChanges();
                return true;

            }
            else
            {
                return false;
            }
        }
    }
}
