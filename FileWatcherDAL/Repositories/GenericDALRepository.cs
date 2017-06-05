using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FileWatcherDAL.ContextFactory;
using FileWatcherDAL.Models;

namespace FileWatcherDAL.Repositories
{
    public abstract class GenericDALRepository<DTO, Entity, Context>
        : IRepository<DTO, Entity>
        where DTO : class
        where Context : System.Data.Entity.DbContext
        where Entity : class
    {
        protected Context _context;

        protected GenericDALRepository(IDataContextFactory<Context> factory)
        {
            _context = factory.ContextObject;
        }
        public Entity ToEntity(DTO source)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<DTO, Entity>());
            var entity = Mapper.Map<DTO, Entity>(source);
            return entity;
        }
        public DTO ToObject(Entity source)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Entity, DTO>());
            var Object = Mapper.Map<Entity, DTO>(source);
            return Object;
        }
        public void Add(DTO obj)
        {
           _context.Set<Entity>().Add(ToEntity(obj));
           _context.SaveChanges();
            
            //Entity entity = ToEntity(obj);

            //var temp = _context.Set<Entity>().Attach(entity);
            //if (temp != null)
            //{
            //    _context.Entry(temp).State = System.Data.Entity.EntityState.Detached;
            //}
            //else
            //{
            //    _context.Set<Entity>().Add(entity);
            //}
        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
        public IEnumerable<DTO> Items
        {
            get
            {
                var b = new List<DTO>();
                foreach (var a in _context.Set<Entity>().Select(x => x))
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
        public IEnumerable<Entity> FirstOrDefault(System.Linq.Expressions.Expression<Func<Entity, bool>> condition)
        {
            
          throw new NotImplementedException();
        }
        public abstract void Remove(DTO obj);
        //public virtual  void Remove(DTO obj)
        //{
        //   var entity = _context.Set<Entity>().FirstOrDefault(x => x.Id == obj.Id);
        //    if (entity != null)
        //    {
        //        _context.Set<Entity>().Remove(entity);
        //    }
        //    else
        //    {
        //        throw new ArgumentException("Incorrect argument!!!");
        //    }
        //}
        public abstract void Update(DTO obj);
        public abstract Entity GetEntity(DTO source);
        public abstract Entity GetEntityNameById(int id);

        
    }
}
