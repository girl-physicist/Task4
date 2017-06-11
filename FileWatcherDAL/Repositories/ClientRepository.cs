using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using FileWatcherDAL.ContextFactory;
using FileWatcherDAL.Models;
using FileWatcherModel;


namespace FileWatcherDAL.Repositories
{
    public class CilentRepository : GenericDALRepository<ClientDAL, Client, SaleInfoEntities>
    {

        public override void Update(ClientDAL obj)
        {
            var entity = _context.Set<Client>().FirstOrDefault(x => x.Id == obj.Id);
            if (entity != null)
            {
                entity.ClientName = obj.ClientName;
            }
            else
            {
                //Add try/catch
                throw new ArgumentException("Incorrect argument!!!");
            }
        }


        public CilentRepository(IDataContextFactory<SaleInfoEntities> factory) : base(factory)
        {
        }
    }
}
