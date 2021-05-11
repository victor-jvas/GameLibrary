using System.Collections.Generic;

namespace GameLibrary.Interfaces
{
    public interface IRepository<T>
    {
        List<T> List();
        void Insert(T entity);
        void Delete(int id);
        void Update(int id, T entity);
        int NextId();
    }
}