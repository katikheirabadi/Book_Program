using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book_Program.Models
{
    public class Publication
    {
        public int id { get; set; }
        public string Name { get; set; }
        public List<Book> books { get; set; }

    }
}
