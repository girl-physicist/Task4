using System;
using System.Linq;
using FileWatcherDAL.Models;
using FileWatcherDAL.ContextFactory;
using FileWatcherModel;

namespace FileWatcherDAL.Repositories
{
    public class OrderRepository : GenericDALRepository<OrderDAL, Order, SaleInfoEntities>
    {
        public OrderRepository(IDataContextFactory<SaleInfoEntities> factory) : base(factory)
        {
        }
        public override void Update(OrderDAL obj)
        {
            var entity = _context.Set<Order>().FirstOrDefault(x => x.Id == obj.Id);
            if (entity != null)
            {
                entity.OrderDate = obj.OrderDate;
                entity.Manager_Id = obj.Manager_Id;
                entity.Client_Id = obj.Client_Id;
                entity.Product_Id = obj.Product_Id;
            else
            {
                throw new ArgumentException("Incorrect argument!!!");
            }
        }
    }
}
