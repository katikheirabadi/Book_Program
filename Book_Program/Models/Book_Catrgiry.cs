using Book_Program.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book_Program.Models
{
    public class Book_Catrgiry: IEntity
    {
        public int id { get; set; }
        public int Categoryid { get; set; }
        public int Bookid { get; set; }
        public Category Category { get; set; }
        public Book Book { get; set; }
    }
}
