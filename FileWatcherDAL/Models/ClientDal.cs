using System.Collections.Generic;

namespace FileWatcherDAL.Models
{
    public class ClientDAL : DAL
    {
        public string ClientName { get; set; }
        public ICollection<OrderDAL> OrderSet { get; set; }
    }
}
