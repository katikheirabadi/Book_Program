using Book_Program.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book_Program.Models
{
    public class Book: IEntity
    {
        public int id { get; set; }
        public string Name { get; set; }
        public int PublicationId { get; set; }
        public string publisher { get; set; }
        public DateTime publishDate { get; set; }
        public string ISBN { get; set; }
        public Publication Publication { get; set; }
        public List<Book_Catrgiry>  Catrgiries { get; set; }
        public List<Author_Book>  Authors { get; set; }
    }
}
