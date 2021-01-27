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
        public string Register(Book_Catrgiry bookcat)
        {
            var testbook = repository.GetAll().Where(ab => ab.Bookid == bookcat.Bookid).ToList().Count;
            var testcategory = repository.GetAll().Where(ab => ab.Categoryid == bookcat.Categoryid).ToList().Count;

            if (testcategory == 0)
                return "Not Found any author whit this id";
            if (testbook == 0)
                return "Not Found any book whit this id";

            repository.Insert(bookcat);
            repository.Save();
            return bookcat.id + " register...";
        }
        [HttpDelete]
        public string Un_Register(int id)
        {
            if (repository.GetAll().Where(cb => cb.id == id).ToList().Count != 0)
            {
                repository.Delete(id);
                repository.Save();
                return $"the category-book with id :{id} is deleted...";
            }
            return "Not Found any cattegory-book to un-register";
        }
    }
}
