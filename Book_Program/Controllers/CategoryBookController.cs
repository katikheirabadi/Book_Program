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
    public class CategoryBookController : ControllerBase
    {
        private readonly IRepository<Book_Catrgiry> repository;
        public CategoryBookController(IRepository<Book_Catrgiry> repository)
        {
            this.repository = repository;
        }
        [HttpPost]
        public void Register(Book_Catrgiry bookcat)
        {
            repository.Insert(bookcat);
            repository.Save();
        }
        [HttpDelete]
        public void Un_Register(int id)
        {
            repository.Delete(id);
            repository.Save();
        }
    }
}
