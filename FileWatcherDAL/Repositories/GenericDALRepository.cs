using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using FileWatcherDAL.ContextFactory;

namespace FileWatcherDAL.Repositories
{
    public abstract class GenericDALRepository<T, K, Context> : IRepository<T, K>
        where T : class
        where K : class
        where Context : System.Data.Entity.DbContext
    {
        protected Context _context;
        protected GenericDALRepository(IDataContextFactory<Context> factory)
        {
            _context = factory.ContextObject;
        }
        public K ToEntity(T source)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<T, K>());
            var entity = Mapper.Map<T, K>(source);
            return entity;
        }
        public T ToObject(K source)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<K, T>());
            var Object = Mapper.Map<K, T>(source);
            return Object;
        }
        public void Add(T obj)
        {
            _context.Set<K>().Add(ToEntity(obj));
        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
        public IEnumerable<T> Items
        {
            get
            {
                var b = new List<T>();
                foreach (var a in _context.Set<K>().Select(x => x))
                {
                    b.Add(ToObject(a));
                }
                return b;
            }
        }
        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
                _context = null;
                //GC.SuppressFinalize(this);
            }
        }
        // destructor
        ~GenericDALRepository()
        {
            if (_context != null)
            {
                Dispose();
            }
        }
        public virtual void Remove(T obj, Expression<Func<K, bool>> predicate)
        {
            var entity = _context.Set<K>().FirstOrDefault(predicate);
            if (entity != null)
            {
                _context.Set<K>().Remove(entity);
            }
            else
            {
                throw new ArgumentException("Incorrect argument!!!");
            }
        }
        public virtual K GetEntity(T obj, Expression<Func<K, bool>> predicate)
        {
            return _context.Set<K>().FirstOrDefault(predicate);
        }
        public abstract void Update(T obj);
    }
}