using Book_Program.Models;
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
    public class AuthorBookController : ControllerBase
    {
        private readonly IRepository<Author_Book> repository;
        private readonly IRepository<Book> b_repository;
        private readonly IRepository<Author> a_repository;
        public AuthorBookController(IRepository<Author_Book> repository, IRepository<Author> a_repository, IRepository<Book> b_repository)
        {
            this.repository = repository;
            this.a_repository = a_repository;
            this.b_repository = b_repository;
        }
        [HttpPost]
        public string Register(Author_Book author_Book)
        {
            var testbook = b_repository.GetAll().Where(ab => ab.id == author_Book.Bookid).ToList().Count;
            var testauthor = a_repository.GetAll().Where(ab => ab.id == author_Book.Authorid).ToList().Count;

            if (testauthor == 0)
                return "Not Found any author with this id";
            if (testbook == 0)
                return "Not Found any book with this id";

            repository.Insert(author_Book);
            repository.Save();
            return author_Book.id + " register...";

        }
        [HttpDelete("{id}")]
        public string Un_Register(int id)
        {
            if (repository.GetAll().Where(ab => ab.id == id).ToList().Count != 0)
            {
                repository.Delete(id);
                repository.Save();
                return $"the author_book with id :{id} is deleted...";
            }
            return "Not Found any author-book to un-register";
        }
        [HttpGet]
        public List<Author_Book> GetAll()
        {
            return repository.GetAll();
        }
    }
}
