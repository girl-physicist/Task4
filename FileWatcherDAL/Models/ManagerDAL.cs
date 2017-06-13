using System.Collections.Generic;

namespace FileWatcherDAL.Models
{
    public class ManagerDAL : DAL
    {
        public string ManagerName { get; set; }
        public ICollection<OrderDAL> OrderSet { get; set; }
    }
}
