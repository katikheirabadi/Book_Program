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
            return repository.Get(id);
        }
        [HttpGet]
        public List<Publication> GetAll()
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
        public Publication Update(Publication publication)
        {
            var end = repository.Update(publication);
            repository.Save();
            return end;
        }
    }
}
