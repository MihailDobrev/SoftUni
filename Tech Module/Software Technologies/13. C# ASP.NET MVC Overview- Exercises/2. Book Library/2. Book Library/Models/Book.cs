using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _2.Book_Library.Models
{
    public class Book
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string AuthorId { get; set; }

        public ApplicationUser Author { get; set; }
    }
}