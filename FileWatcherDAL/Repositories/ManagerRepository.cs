using System;
using System.Linq;
using FileWatcherDAL.ContextFactory;
using FileWatcherDAL.Models;
using FileWatcherModel;


namespace FileWatcherDAL.Repositories
{
    public class ManagerRepository : GenericDALRepository<ManagerDAL, Manager, SaleInfoEntities>
    {
        public ManagerRepository(IDataContextFactory<SaleInfoEntities> factory) : base(factory)
        {
        }
        public override void Update(ManagerDAL obj)
        {
            var entity = _context.Set<Manager>().FirstOrDefault(x => x.ManagerName == obj.ManagerName);
            if (entity != null)
            {
                entity.ManagerName = obj.ManagerName;
            }
            else
            {
                throw new ArgumentException("Incorrect argument!!!");
            }
        }
    }
}
