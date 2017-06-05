using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileWatcherDAL.ContextFactory;
using FileWatcherDAL.Repositories;
using FileWatcherDAL.Models;
using FileWatcherModel;

namespace FileWatcherService.DataBase
{
    public class DatabaseHandler
    {

        private readonly IRepository<ManagerDTO, Manager> _managerRepository;
        private readonly IRepository<ClientDTO, Client> _clientRepository;
        private readonly IRepository<ProductDto, Product> _productRepository;
        private readonly IRepository<OrderDTO, Order> _orderRepository;


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
                var newManager = new ManagerDTO { ManagerName = sale.ManagerName };
                var manager = _managerRepository.GetEntity(newManager);
                if (manager == null)
                {
                    _managerRepository.Add(newManager);
                    _managerRepository.SaveChanges();
                    manager = _managerRepository.GetEntity(newManager);
                }

                var newClient = new ClientDTO { ClientName = sale.ClientName };
                _clientRepository.Add(newClient);
                _clientRepository.SaveChanges();
                var client = _clientRepository.GetEntity(newClient);

                var newProduct = new ProductDto { ProductName = sale.ProductName, ProductCost = sale.ProductCost };
                _productRepository.Add(newProduct);
                _productRepository.SaveChanges();
                var product = _productRepository.GetEntity(newProduct);
                var saleInfo = new OrderDTO
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
