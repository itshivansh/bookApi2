using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cgi_tollgate_assignment_book_api.Models
{
    public class Book
    {
        /*
         * This model class should have five properties
         * BookId - int (Should be a primary and auto-generated).
         * BookName - string
         * AuthorName - string
         * Genre - string
         * Price - int
         */
        public int BookId { get; set; }
        public string BookName { get; set; }
        public string AuthorName { get; set; }
        public string Genre { get; set; }
        public int Price { get; set; }
    }
}
