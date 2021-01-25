using Book_Program.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book_Program.Repository
{
    public class Repository<T> : IRepository<T> where T:class,IEntity
    {
        private readonly BooksContext booksContext;
        public Repository(BooksContext booksContext)
        {
            this.booksContext = booksContext;
        }
        public string Delete(int id)
        {
            var item = booksContext.Set<T>().FirstOrDefault(x => x.id == id);
            if (item == null) return "not found";
            booksContext.Remove(item);
            return item.id + " delete...";
        }

        public T Get(int id)
        {
            return booksContext.Set<T>().FirstOrDefault(x => x.id == id);
        }

        public List<T> GetAll()
        {
            return booksContext.Set<T>().ToList();
        }

        public string Insert(T item)
        {
            booksContext.Add(item);
            return item.id + " added...";
        }

        public void Save()
        {
            booksContext.SaveChanges();
        }

        public T Update(T item)
        {
            booksContext.Entry<T>(item).State = EntityState.Modified;
            booksContext.Update(item);
            return item;
        }
    }
}
