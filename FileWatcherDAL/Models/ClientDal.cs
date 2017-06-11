using System.Collections.Generic;

namespace FileWatcherDAL.Models
{
    public class ClientDAL
    {
        public int Id { get; set; }
        public string ClientName { get; set; }
        public ICollection<OrderDAL> OrderSet { get; set; }
    }
}
