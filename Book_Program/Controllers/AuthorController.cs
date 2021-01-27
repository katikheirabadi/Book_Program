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
    public class AuthorController : ControllerBase
    {
        private readonly IRepository<Author> repository;
        public AuthorController(IRepository<Author> repository)
        {
            this.repository = repository;
        }
        [HttpPost]
        public string Create(Author author)
        {
            var result = repository.Insert(author);
            repository.Save();
            return author.id+ result;
        }
        [HttpGet("{id}")]
        public Author Get(int id)
        {
            if (repository.GetAll().Where(a => a.id == id).ToList().Count != 0)
                return repository.Get(id);
            return null;
        }
        [HttpGet]
        public List<Author> GetAll()
        {
            return repository.GetAll();
        }
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            if (repository.GetAll().Where(a => a.id == id).ToList().Count != 0)
            {
                try
                {
                    var result = repository.Delete(id);
                    repository.Save();
                    return result;
                }
                catch
                {
                    return "There is a dependency for this author in Author-Book table ....";

                }
            }
            return "Not found any author with this id for delete";

        }
        [HttpPut]
        public string Update(Author author)
        {
            try
            {
                var end = repository.Update(author);
                repository.Save();
                return end;
            }
            catch (Exception)
            {
                return " Not found any author with this id for update";
            }
        }
    }
}
