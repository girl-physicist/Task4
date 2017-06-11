using FileWatcherDAL.ContextFactory;
using FileWatcherDAL.Repositories;
using FileWatcherDAL.Models;
using FileWatcherModel;


namespace FileWatcherService.DataBase
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
                var newManager = new ManagerDAL { ManagerName = sale.ManagerName };
                var manager = _managerRepository.GetEntity(newManager, x => x.Id == newManager.Id);
                if (manager == null)
                {
                    _managerRepository.Add(newManager);
                    _managerRepository.SaveChanges();
                    manager = _managerRepository.GetEntity(newManager, x => x.Id == newManager.Id);
                }
                var newClient = new ClientDAL { ClientName = sale.ClientName };
                _clientRepository.Add(newClient);
                _clientRepository.SaveChanges();
                var client = _clientRepository.GetEntity(newClient,x => x.Id == newClient.Id);
                var newProduct = new ProductDAL { ProductName = sale.ProductName, ProductCost = sale.ProductCost };
                _productRepository.Add(newProduct);
                _productRepository.SaveChanges();
                var product = _productRepository.GetEntity(newProduct, x => x.Id == newClient.Id);
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
