using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using FileWatcherDAL.Models;
using AutoMapper;
using FileWatcherDAL.ContextFactory;
using FileWatcherModel;

namespace FileWatcherDAL.Repositories
{
    public class OrderRepository : GenericDALRepository<OrderDAL, Order, SaleInfoEntities>
    {
        public override void Update(OrderDAL obj)
        {
            var entity = _context.Set<Order>().FirstOrDefault(x => x.Id == obj.Id);
            if (entity != null)
            {
                entity.OrderDate = obj.OrderDate;
                entity.Manager_Id = obj.Manager_Id;
                entity.Client_Id = obj.Client_Id;
                entity.Product_Id = obj.Product_Id;
            }
            else
            {
                throw new ArgumentException("Incorrect argument!!!");
            }
        }
       public OrderRepository(IDataContextFactory<SaleInfoEntities> factory) : base(factory)
        {
        }
    }
}
