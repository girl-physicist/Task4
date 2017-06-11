using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FileWatcherDAL.Repositories
{
    public interface IRepository<T, K> : IDisposable
    {
        void Add(T obj);
        void Remove(T obj, Expression<Func<K, bool>> predicate);
        void SaveChanges();
        K ToEntity(T source);
        void Update(T obj);
        K GetEntity(T source, Expression<Func<K, bool>> predicate);
        K GetEntityNameById(int id, Expression<Func<K, bool>> predicate);
       IEnumerable<T> Items { get; }
        //K GetEntity(T source);
        //K GetEntityNameById(int id);
        //void Remove(T obj);
    }
}
