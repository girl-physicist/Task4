using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileWatcherService.DataBase
{
   public class SaleInfo
    {
        public string ManagerName { get;  }
        public string SaleDate { get; }
        public string ClientName { get;}
        public string ProductName { get;  }
        public string ProductCost { get; }

        public SaleInfo(string managerName, string saleDate, string clientName, string productName, string productCost)
        {
            ManagerName = managerName;
            SaleDate = saleDate;
            ClientName = clientName;
            ProductName = productName;
            ProductCost = productCost;
        }
    }
}
