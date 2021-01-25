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
        public void Create(Author author)
        {
            repository.Insert(author);
            repository.Save();
        }
        [HttpGet("{id}")]
        public Author Get(int id)
        {
            return repository.Get(id);
        }
        [HttpGet]
        public List<Author> GetAll()
        {
            return repository.GetAll();
        }
        [HttpDelete]
        public string Delete(int id)
        {
            repository.Delete(id);
            repository.Save();
            return "delete...";
        }
        [HttpPut]
        public string Update(Author author)
        {
          var end=  repository.Update(author);
            repository.Save();
            return end;
        }
    }
}
