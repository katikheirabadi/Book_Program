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
        public string Create(Category category)
        {
            var result = repository.Insert(category);
            repository.Save();
            return category.id + result;
        }
        [HttpGet("{id}")]
        public Category Get(int id)
        {
            if (repository.GetAll().Where(c => c.id == id).ToList().Count != 0)
                return repository.Get(id);
            return null;
        }
        [HttpGet]
        public List<Category> GetAll()
        {
            return repository.GetAll();
        }
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            if (repository.GetAll().Where(c => c.id == id).ToList().Count != 0)
            {
                try
                {
                    var result = repository.Delete(id);
                    repository.Save();
                    return result;
                }
                catch
                {
                    return "There is a dependency for this category in Book-Category table ....";
                }
            }
            return "Not found any category with this id for delete";
        }
        [HttpPut]
        public string Update(Category category)
        {
            try
            {
                var end = repository.Update(category);
                repository.Save();
                return end;
            }
            catch (Exception)
            {
                return " Not found any category with this id for update";
            }

        }
    }
}
