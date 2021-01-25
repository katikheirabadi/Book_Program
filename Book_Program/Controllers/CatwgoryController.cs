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
    public class CatwgoryController : ControllerBase
    {
        private readonly IRepository<Category> repository;
        public CatwgoryController(IRepository<Category> repository)
        {
            this.repository = repository;
        }
        [HttpPost]
        public void Create(Category category)
        {
            repository.Insert(category);
            repository.Save();
        }
        [HttpGet("{id}")]
        public Category Get(int id)
        {
            return repository.Get(id);
        }
        [HttpGet]
        public List<Category> GetAll()
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
        public string Update(Category category)
        {
           var end= repository.Update(category);
            repository.Save();
            return end;
            
        }
    }
}
