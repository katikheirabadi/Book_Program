using Book_Program.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book_Program.Models
{
    public class Category: IEntity
    {
        public int id { get; set; }
        public string Name { get; set; }
        public List<Book_Catrgiry> book_Catrgiries { get; set; }
    }
}
