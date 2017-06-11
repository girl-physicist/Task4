using System.Collections.Generic;

namespace FileWatcherDAL.Models
{
    public class ProductDAL
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ProductCost { get; set; }
        public ICollection<OrderDAL> OrderSet { get; set; }
    }
}
