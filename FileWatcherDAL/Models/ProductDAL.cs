using System.Collections.Generic;

namespace FileWatcherDAL.Models
{
    public class ProductDAL : DAL
    {
        public string ProductName { get; set; }
        public string ProductCost { get; set; }
        public ICollection<OrderDAL> OrderSet { get; set; }
    }
}
