namespace DatabaseHandler
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
