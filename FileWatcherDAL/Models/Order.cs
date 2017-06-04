using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileWatcherDAL.Models
{
   public class Order
    {
        public int Id { get; set; }
        public string OrderDate { get; set; }
        public int Product_Id { get; set; }
        public int Client_Id { get; set; }
        public int Manager_Id { get; set; }
        
    }
}
