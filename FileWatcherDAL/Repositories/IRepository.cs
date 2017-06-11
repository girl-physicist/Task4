using System;
using System.Collections.Generic;
using System.Linq.Expressions;

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
        IEnumerable<T> Items { get; }
    }
}
