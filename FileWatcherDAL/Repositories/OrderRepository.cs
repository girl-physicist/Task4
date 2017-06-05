using FileWatcherDAL.Models;
using AutoMapper;
using FileWatcherDAL.ContextFactory;
using FileWatcherModel;

namespace FileWatcherDAL.Repositories
{
    public class OrderRepository:GenericDALRepository<OrderDTO,Order,SaleInfoEntities>
    {
        public new void Add(OrderDTO order)
        {
            using (var dc = new SaleInfoEntities())
            {
                //var a = new FileWatcherModel.Order()
                //{
                //    Id = order.Id, OrderDate = order.OrderDate,Client_Id = order.Client_Id,
                //    Product_Id = order.Product_Id,Manager_Id = order.Manager_Id
                //};
                //dc.OrderSet.Add(a);
                //dc.SaveChanges();
                Mapper.Initialize(cfg =>cfg.CreateMap<OrderDTO, FileWatcherModel.Order>());
                dc.OrderSet.Add(Mapper.Map<OrderDTO, FileWatcherModel.Order>(order));
                dc.SaveChanges();
            }
        }

        public override void Remove(OrderDTO obj)
        {
            throw new System.NotImplementedException();
        }

        public override void Update(OrderDTO obj)
        {
            throw new System.NotImplementedException();
        }

        public override Order GetEntity(OrderDTO source)
        {
            throw new System.NotImplementedException();
        }

        public override Order GetEntityNameById(int id)
        {
            throw new System.NotImplementedException();
        }

        public OrderRepository(IDataContextFactory<SaleInfoEntities> factory) : base(factory)
        {
        }
    }
}
