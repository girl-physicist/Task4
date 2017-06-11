﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileWatcherDAL.ContextFactory;
using FileWatcherDAL.Models;
using FileWatcherModel;



namespace FileWatcherDAL.Repositories
{
   public class ProductRepository:GenericDALRepository<ProductDAL, Product, SaleInfoEntities>
    {
        public override void Update(ProductDAL obj)
        {
            var entity = _context.Set<Product>().FirstOrDefault(x => x.ProductName == obj.ProductName);
            if (entity != null)
            {
                entity.ProductName = obj.ProductName;
            }
            else
            {
                throw new ArgumentException("Incorrect argument!!!");
            }
        }
        public ProductRepository(IDataContextFactory<SaleInfoEntities> factory) : base(factory)
        {
        }
    }
}
