using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileWatcherDAL.Models
{
  public  class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ProductCost { get; set; }
        public ICollection<Order> OrderSet { get; set; }
    }
}
