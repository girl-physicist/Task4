//------------------------------------------------------------------------------
// <auto-generated>
//    Этот код был создан из шаблона.
//
//    Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//    Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FileWatcherModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class Client
    {
        public Client()
        {
            this.OrderSet = new HashSet<Order>();
        }
    
        public int Id { get; set; }
        public string ClientName { get; set; }
    
        public virtual ICollection<Order> OrderSet { get; set; }
    }
}
