using System;
using System.Linq;
using FileWatcherDAL.ContextFactory;
using FileWatcherDAL.Models;
using FileWatcherModel;

namespace FileWatcherDAL.Repositories
{
    public class ProductRepository : GenericDALRepository<ProductDAL, Product, SaleInfoEntities>
    {
        public ProductRepository(IDataContextFactory<SaleInfoEntities> factory) : base(factory)
        {
        }
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
    }
}
