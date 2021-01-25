using Book_Program.Models;
using Book_Program.Models.Search;
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
    public class BookController : ControllerBase
    {
        private readonly IRepository<Book> repository;
        public BookController(IRepository<Book> repository)
        {
            this.repository = repository;
        }
        [HttpPost]
        public void Create(Book book)
        {
            repository.Insert(book);
            repository.Save();
        }
        [HttpGet("{id}")]
        public Book Get(int id)
        {
            return repository.Get(id);
        }
        [HttpGet]
        public List<Book> GetAll()
        {
            return repository.GetAll();
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            repository.Delete(id);
            repository.Save();
            
        }
        [HttpPut]
        public string Update(Book book)
        {
            var end = repository.Update(book);
            repository.Save();
            return end;

        }
        [HttpPost("Search")]
        public OUTPUT_BOOKLIST Search(search_model search)
        {
            var allbooks = repository.GetAll();
            var endList = new OUTPUT_BOOKLIST();
           
            if (search.publication != null)
            {
                endList.books = allbooks.Where(b => b.Publication.Name == search.publication).ToList();
            }
            if (search.categories != null)
            {
                var bookcategory = new List<List<Book_Catrgiry>>();
                foreach (var book in allbooks)
                    bookcategory.Add(book.book_Catrgiries);

                for(int i=0; i<bookcategory.Count;i++)
                {
                    for(int j=0;j<bookcategory[i].Count;j++)
                    {
                        var categoryname = bookcategory[i][j].Category.Name;
                        if (search.categories.Contains(categoryname))
                        {
                            var exist = allbooks.Where(b => b.book_Catrgiries.Contains(bookcategory[i][j])).ToList();
                            foreach (var book in exist)
                                if (!endList.books.Contains(book))
                                    endList.books.Add(book);
                        }

                    }
                }
            }
            if(search.authors != null)
            {
                var boocauthor = new List<List<Author_Book>>();
                foreach (var book in allbooks)
                    boocauthor.Add(book.author_Books);

                for (int i = 0; i < boocauthor.Count; i++)
                {
                    for (int j = 0; j < boocauthor[i].Count; j++)
                    {
                        var authorname = boocauthor[i][j].Author.FullName;
                        if (search.authors.Contains(authorname))
                        {
                            var exist = allbooks.Where(b => b.author_Books.Contains(boocauthor[i][j])).ToList();
                            foreach (var book in exist)
                                if (!endList.books.Contains(book))
                                    endList.books.Add(book);
                        }

                    }
                }
            }

            return endList;
        }
    }
}
