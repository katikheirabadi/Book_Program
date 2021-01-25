﻿using Book_Program.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book_Program.Models
{
    public class Author_Book : IEntity
    {
        public int id { get; set; }
        public int Bookid { get; set; }
        public int Authorid { get; set; }
        public Book Book { get; set; }
        public Author Author { get; set; }
    }
}
