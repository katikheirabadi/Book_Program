using Book_Program.Models;
using Book_Program.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public string Create(Publication Publication)
        {
            var result = repository.Insert(Publication);
            repository.Save();
            return Publication.id + result;
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
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            if (repository.GetAll().Where(p => p.id == id).ToList().Count != 0)
            {
                try
                {
                    var result = repository.Delete(id);
                    repository.Save();
                    return result;
                }
                catch
                {
                    return "There is a dependency for this publication in Book table ....";

                }
            }
            return "Not found any publication with this id for delete";
        }
        [HttpPut]
        public string Update(Publication publication)
        {
            try
            {
                var end = repository.Update(publication);
                repository.Save();
                return end;
            }
            catch (Exception)
            {
                return " Not found any publication with this id for update";
            }


        }
        [HttpGet("searchbyid")]
        public List<Publication> search()
        {
            //var publication = repository.GetAll().Where(Publication => Publication.id == id).FirstOrDefault();
            //if (publication == null)
            //    return;
           return  repository.GetQuery().Include(b => b.books).ToList();
        }
    }
}
