using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileWatcherDAL.Models
{
   public class Manager
    {
        public int Id { get; set; }
        public string ManagerName { get; set; }
        public ICollection<Order> OrderSet { get; set; }
    }
}
