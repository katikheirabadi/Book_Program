using Book_Program.Models;
using Book_Program.Models.Search;
using Book_Program.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book_Program.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IRepository<Book> repository;
        public BookController(IRepository<Book> repository)
        {
            this.repository = repository;
        }
        [HttpPost]
        public void Create(Book book)
        {
            repository.Insert(book);
            repository.Save();
        }
        [HttpGet("{id}")]
        public Book Get(int id)
        {
            return repository.Get(id);
        }
        [HttpGet]
        public List<Book> GetAll()
        {
            return repository.GetAll();
        }
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            repository.Delete(id);
            repository.Save();
            return "delete...";
        }
        [HttpPut]
        public Book Update(Book book)
        {
            var end = repository.Update(book);
            repository.Save();
            return end;
        }
        //[HttpPost("Search")]
        //public OUTPUT_BOOKLIST Search(search_model search)
        //{
        //    var allbooks = repository.GetAll();
        //    var endlist = new OUTPUT_BOOKLIST();
        //    if(search.publication!=null)
        //    {
        //        endlist.books= allbooks.Where(b => b.Publication.Name == search.publication).ToList();
        //    }

            
        //    return endlist;
        //}
    }
}
