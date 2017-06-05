using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileWatcherDAL.Models
{
    public class ClientDTO
    {
        public int Id { get; set; }
        public string ClientName { get; set; }
        public ICollection<OrderDTO> OrderSet { get; set; }
    }
}
