using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileWatcherDAL.Models
{
  public  class ManagerDAL
    {
       
            public int Id { get; set; }
            public string ManagerName { get; set; }
            public ICollection<OrderDAL> OrderSet { get; set; }
        
    }
}
