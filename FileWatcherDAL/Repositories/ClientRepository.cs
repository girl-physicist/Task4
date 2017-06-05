using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using FileWatcherDAL.ContextFactory;
using FileWatcherDAL.Models;
using FileWatcherModel;


namespace FileWatcherDAL.Repositories
{
    public class CilentRepository : GenericDALRepository<ClientDTO, Client, SaleInfoEntities>
    {
        public CilentRepository(IDataContextFactory<SaleInfoEntities> factory)
            : base(factory)
        {
        }
        //public override FileWatcherModel.Client ToEntity(Client source)
        //{
        //    return new FileWatcherModel.Client()
        //    {
        //        ClientName = source.ClientName
        //    };
        //}
        //public override Client ToObject(FileWatcherModel.Client source)
        //{
        //    return new Client()
        //    {
        //        ClientName = source.ClientName
        //    };
        //}
        public override void Update(ClientDTO obj)
        {
            var entity = _context.ClientSet.FirstOrDefault(x => x.Id == obj.Id);
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
        //public override void Remove(Client obj)
        //{
        //    var entity = _context.ClientSet.FirstOrDefault(x => x.Id == obj.Id);
        //    if (entity != null)
        //    {
        //        _context.ClientSet.Remove(entity);
        //    }
        //    else
        //    {
        //        //Add try/catch
        //        throw new ArgumentException("Incorrect argument!!!");
        //    }
        //}

        //public override void SaveChanges()
        //{
        //    _context.SaveChanges();
        //}
        public override Client GetEntity(ClientDTO source)
        {
            var entity = _context.ClientSet.FirstOrDefault(x => x.ClientName == source.ClientName);
            return entity;
        }

        public override Client GetEntityNameById(int id)
        {
            var entity = _context.ClientSet.FirstOrDefault(x => x.Id == id);
            return entity;
        }

        public override void Remove(ClientDTO obj)
        {
            throw new NotImplementedException();
        }

        //public override IEnumerable<Client> Items
        //{
        //    get
        //    {
        //        return _context.ClientSet.Select(x =>ToObject(x));
        //    }
        //}
    }
}
