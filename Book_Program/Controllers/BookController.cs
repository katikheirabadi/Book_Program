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
        private readonly IRepository<Publication> p_repository;
        private readonly IRepository<Author> a_repository;
        private readonly IRepository<Category> c_repository;
        private readonly IRepository<Author_Book> ab_repository;
        private readonly IRepository<Book_Catrgiry> cb_repository;
        public BookController(IRepository<Book> repository, IRepository<Publication> p_repository, IRepository<Book_Catrgiry> cb_repository, IRepository<Author_Book> ab_repository, IRepository<Category> c_repository, IRepository<Author> a_repository)
        {
            this.repository = repository;
            this.p_repository = p_repository;
            this.cb_repository = cb_repository;
            this.ab_repository = ab_repository;
            this.c_repository = c_repository;
            this.a_repository = a_repository;
        }
        [HttpPost]
        public string Create(Book book)
        {
            var result= repository.Insert(book);
            repository.Save();
            return book.id +result;
        }
        [HttpGet("{id}")]
        public Book Get(int id)
        {
            if(repository.GetAll().Where(b=>b.id==id).ToList().Count!=0)
               return repository.Get(id);
            return null;
        }
        [HttpGet]
        public List<Book> GetAll()
        {
            return repository.GetAll();
        }
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            if (repository.GetAll().Where(b => b.id == id).ToList().Count != 0)
            {
                var result = repository.Delete(id);
                repository.Save();
                return result;
            }
            return "Not found any book with this id for delete";
        }
        [HttpPut]
        public string Update(Book book)
        {
            try
            {
                var end = repository.Update(book);
                repository.Save();
                return end;
            }
            catch (Exception)
            {
                return " Not found any book with this id for update";
            }
           
        }
        [HttpPost("Search")]
        public OUTPUT_BOOKLIST Search(search_model search)
        {
            var end = new OUTPUT_BOOKLIST();
            var publication = p_repository.GetAll().Where(p => p.Name == search.publication).Select(p=> p.id).FirstOrDefault();
            var categories = c_repository.GetAll().Where(c => search.categories.Contains(c.Name)).Select(c=>c.id);
            var authors = a_repository.GetAll().Where(a => search.authors.Contains(a.FullName)).Select(a => a.id);

            var books = new List<Book>();
            if(publication!=0)
            {
                var pbooks = repository.GetAll().Where(b => b.PublicationId == publication).ToList();
                foreach (var book in pbooks)
                    if (!books.Contains(book))
                        books.Add(book);
            }
            if(categories != null)
            {
                var cb = cb_repository.GetAll().Where(cb => categories.Contains(cb.Categoryid)).Select(cb => cb.Bookid).ToList();
                var cbooks = repository.GetAll().Where(b => cb.Contains(b.id)).ToList();
                foreach (var book in cbooks)
                    if (!books.Contains(book))
                        books.Add(book);
            }
            if(authors != null)
            {
                var ab = ab_repository.GetAll().Where(cb => authors.Contains(cb.Authorid)).Select(ab => ab.Bookid).ToList();
                var abooks = repository.GetAll().Where(b => ab.Contains(b.id)).ToList();
                foreach (var book in abooks)
                    if (!books.Contains(book))
                        books.Add(book);
            }

            end.books = books.Select(b => new Result() { Name = b.Name, ISBN = b.ISBN, publishDate = b.publishDate, publisher = b.publisher, authors = b.Authors.Select(a => a.Author.FullName).ToList() }).ToList();
            return end;
        }
    }
}
