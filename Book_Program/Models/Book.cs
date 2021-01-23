﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book_Program.Models
{
    public class Book
    {
        public int id { get; set; }
        public string Name { get; set; }
        public int PublicationId { get; set; }
        public Publication Publication { get; set; }
        public List<Book_Catrgiry>  book_Catrgiries { get; set; }
        public List<Author_Book>  author_Books { get; set; }
    }
}