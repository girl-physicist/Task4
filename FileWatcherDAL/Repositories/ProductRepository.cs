using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileWatcherDAL.ContextFactory;
using FileWatcherDAL.Models;
using FileWatcherModel;



namespace FileWatcherDAL.Repositories
{
   public class ProductRepository:GenericDALRepository<ProductDto, Product, SaleInfoEntities>
    {
        public ProductRepository(IDataContextFactory<SaleInfoEntities> factory) : base(factory)
        {
        }

        
        public override void Update(ProductDto obj)
        {
            var entity = _context.ProductSet.FirstOrDefault(x => x.ProductName == obj.ProductName);
            if (entity != null)
            {
                entity.ProductName = obj.ProductName;
            }
            else
            {
                throw new ArgumentException("Incorrect argument!!!");
            }
        }

        public override Product GetEntity(ProductDto source)
        {
            var entity = _context.ProductSet.FirstOrDefault(x => x.ProductName == source.ProductName);
            return entity;
        }

        public override void Remove(ProductDto obj)
        {
            var entity = _context.ProductSet.FirstOrDefault(x => x.Id == obj.Id);
            if (entity != null)
            {
                _context.ProductSet.Remove(entity);
            }
            else
            {
                throw new ArgumentException("Incorrect argument!!!");
            }
        }
        public override Product GetEntityNameById(int id)
        {
            var entity = _context.ProductSet.FirstOrDefault(x => x.Id == id);
            return entity;
        }
    }
}
