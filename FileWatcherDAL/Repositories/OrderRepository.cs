using FileWatcherDAL.Models;
using AutoMapper;

namespace FileWatcherDAL.Repositories
{
    public class OrderRepository
    {
        public void Add(Order order)
        {
            using (var dc = new FileWatcherModel.SaleInfoEntities())
            {
                //var a = new FileWatcherModel.Order()
                //{
                //    Id = order.Id, OrderDate = order.OrderDate,Client_Id = order.Client_Id,
                //    Product_Id = order.Product_Id,Manager_Id = order.Manager_Id
                //};
                //dc.OrderSet.Add(a);
                //dc.SaveChanges();
                Mapper.Initialize(cfg =>cfg.CreateMap<Order, FileWatcherModel.Order>());
                dc.OrderSet.Add(Mapper.Map<Order, FileWatcherModel.Order>(order));
                dc.SaveChanges();
            }
        }
    }
}
