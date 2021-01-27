﻿using Book_Program.Models;
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
        public AuthorBookController(IRepository<Author_Book> repository)
        {
            this.repository = repository;
        }
        [HttpPost]
        public string Register(Author_Book author_Book)
        {
            repository.Insert(author_Book);
            repository.Save();
            return author_Book.id + " register...";
        }
        [HttpDelete]
        public string Un_Register(int id)
        {
            repository.Delete(id);
            repository.Save();
            return $"the author_book with id :{id} is deleted...";
        }
    }
}
