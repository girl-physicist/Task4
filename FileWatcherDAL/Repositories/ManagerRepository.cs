using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileWatcherDAL.ContextFactory;
using FileWatcherDAL.Models;
using FileWatcherModel;
using Manager = FileWatcherModel.Manager;


namespace FileWatcherDAL.Repositories
{
  public  class ManagerRepository:GenericDALRepository<ManagerDTO, Manager, SaleInfoEntities>
    {
        public ManagerRepository(IDataContextFactory<SaleInfoEntities> factory) : base(factory)
        {
        }
        public override Manager GetEntity(ManagerDTO source)
        {
            var entity = _context.ManagerSet.FirstOrDefault(x => x.ManagerName == source.ManagerName);
            return entity;
        }

        public override Manager GetEntityNameById(int id)
        {
            var entity =_context.ManagerSet.FirstOrDefault(x => x.Id == id);
            return entity;
        }

        //public override IEnumerable<Manager> Items
        //{
        //    get
        //    {
        //        var b = new List<Manager>();
        //        foreach (var a in _context.ManagerSet.Select(x => x))
        //        {
        //            b.Add(ToObject(a));
        //        }
        //        return b;
        //    }
        //}

        //public override FileWatcherModel.Manager ToEntity(Manager source)
        //{
        //    return new FileWatcherModel.Manager()
        //    {
        //        ManagerName = source.ManagerName
        //    };
        //}

        public override void Update(ManagerDTO obj)
        {
            var entity = _context.ManagerSet.FirstOrDefault(x => x.ManagerName == obj.ManagerName);
            if (entity != null)
            {
                entity.ManagerName = obj.ManagerName;
            }
            else
            {
                throw new ArgumentException("Incorrect argument!!!");
            }
        }

        //public override Manager ToObject(FileWatcherModel.Manager source)
        //{
        //    return new Manager()
        //    {
        //        ManagerName = source.ManagerName
        //    };
        //}

        public override void Remove(ManagerDTO obj)
        {
            var entity = _context.ManagerSet.FirstOrDefault(x => x.Id == obj.Id);
            if (entity != null)
            {
                _context.ManagerSet.Remove(entity);
            }
            else
            {
                throw new ArgumentException("Incorrect argument!!!");
            }
        }

    }
}
