using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book_Program.Repository
{
    public interface IRepository<T>
    {
        T Get(int id);
        List<T> GetAll();
        string Insert(T item);
        string Delete(int id);
        string Update(T item);
        void Save();
    }
}
