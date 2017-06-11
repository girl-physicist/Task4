using FileWatcherDAL.ContextFactory;
using FileWatcherDAL.Models;
using FileWatcherDAL.Repositories;
using FileWatcherModel;

namespace FileWatcherManager
{
    public class DatabaseHandler
    {
        private readonly IRepository<ManagerDAL, Manager> _managerRepository;
        private readonly IRepository<ClientDAL, Client> _clientRepository;
        private readonly IRepository<ProductDAL, Product> _productRepository;
        private readonly IRepository<OrderDAL, Order> _orderRepository;

        public DatabaseHandler()
        {
            _managerRepository = new ManagerRepository(new FileWatcherContextFactory());
            _clientRepository = new CilentRepository(new FileWatcherContextFactory());
            _productRepository = new ProductRepository(new FileWatcherContextFactory());
            _orderRepository = new OrderRepository(new FileWatcherContextFactory());
        }

        public void AddToDatabase(SaleInfo sale)
        {
            lock (this)
            {
                var newManager = new ManagerDAL {ManagerName = sale.ManagerName};
                var manager = _managerRepository.GetEntity(newManager, x => x.ManagerName == newManager.ManagerName);
                if (manager == null)
                {
                    _managerRepository.Add(newManager);
                    _managerRepository.SaveChanges();
                    manager = _managerRepository.GetEntity(newManager, x => x.ManagerName == newManager.ManagerName);
                }
                var newClient = new ClientDAL {ClientName = sale.ClientName};
                var client = _clientRepository.GetEntity(newClient, x => x.ClientName == newClient.ClientName);
                if (client == null)
                {
                    _clientRepository.Add(newClient);
                    _clientRepository.SaveChanges();
                    client = _clientRepository.GetEntity(newClient, x => x.ClientName == newClient.ClientName);
                }

                var newProduct = new ProductDAL {ProductName = sale.ProductName, ProductCost = sale.ProductCost};
                var product = _productRepository.GetEntity(newProduct, x => x.ProductName == newProduct.ProductName);
                if(product == null)
                {
                    _productRepository.Add(newProduct);
                    _productRepository.SaveChanges();
                    product = _productRepository.GetEntity(newProduct, x => x.ProductName == newProduct.ProductName);
                }
                var saleInfo = new OrderDAL
                {
                    OrderDate = sale.SaleDate,
                    Manager_Id = manager.Id,
                    Client_Id = client.Id,
                    Product_Id = product.Id
                };
                _orderRepository.Add(saleInfo);
                _orderRepository.SaveChanges();
            }
        }
    }
}
