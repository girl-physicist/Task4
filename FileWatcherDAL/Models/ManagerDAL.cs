using System.Collections.Generic;

namespace FileWatcherDAL.Models
{
    public class ManagerDAL
    {
        public int Id { get; set; }
        public string ManagerName { get; set; }
        public ICollection<OrderDAL> OrderSet { get; set; }
    }
}
