using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileWatcherDAL.Models
{
  public  class ProductDto
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ProductCost { get; set; }
        public ICollection<OrderDTO> OrderSet { get; set; }
    }
}
