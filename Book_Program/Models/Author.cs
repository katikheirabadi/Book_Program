using Book_Program.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book_Program.Models
{
    public class Author : IEntity
    {
        public int id { get; set; }
        public string FullName { get; set; }
        public List<Author_Book> author_Books { get; set; }
    }
}
