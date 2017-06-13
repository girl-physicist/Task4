using System;
using System.Linq;
using FileWatcherDAL.ContextFactory;
using FileWatcherDAL.Models;
using FileWatcherModel;

namespace FileWatcherDAL.Repositories
{
    public class CilentRepository : GenericDALRepository<ClientDAL, Client, SaleInfoEntities>
    {
        public CilentRepository(IDataContextFactory<SaleInfoEntities> factory) : base(factory)
        {
        }
        public override void Update(ClientDAL obj)
        {
            var entity = _context.Set<Client>().FirstOrDefault(x => x.Id == obj.Id);
            if (entity != null)
            {
                entity.ClientName = obj.ClientName;
            }
            else
            {
                throw new ArgumentException("Incorrect argument!!!");
            }
        }
    }
}
