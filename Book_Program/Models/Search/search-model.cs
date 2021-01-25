using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book_Program.Models.Search
{
    public class search_model
    {
        public List<string> authors { get; set; }
        public List<string> categories { get; set; }
        public string publication { get; set; }
    }
    public class OUTPUT_BOOKLIST
    {
        public List<Book> books { get;set; }
    }
}
