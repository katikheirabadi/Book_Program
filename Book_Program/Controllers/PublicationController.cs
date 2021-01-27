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
    public class PublicationController : ControllerBase
    {
        private readonly IRepository<Publication> repository;
        public PublicationController(IRepository<Publication> repository)
        {
            this.repository = repository;
        }
        [HttpPost]
        public void Create(Publication Publication)
        {
            repository.Insert(Publication);
            repository.Save();
        }
        [HttpGet("{id}")]
        public Publication Get(int id)
        {
            if (repository.GetAll().Where(p => p.id == id).ToList().Count != 0)
                return repository.Get(id);
            return null;
        }
        [HttpGet]
        public List<Publication> GetAll()
        {
            return repository.GetAll();
        }
        [HttpDelete]
        public string Delete(int id)
        {
            if (repository.GetAll().Where(p => p.id == id).ToList().Count != 0)
            {
                var result = repository.Delete(id);
                repository.Save();
                return result;
            }
            return "Not found any publication with this id for delete";
        }
        [HttpPut]
        public string Update(Publication publication)
        {
            if (repository.GetAll().Where(p => p.id == publication.id).ToList().Count != 0)
            {
                var end = repository.Update(publication);
                repository.Save();
                return end;
            }
            return "Not found any publication with this id for update";

        }
    }
}
