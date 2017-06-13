namespace FileWatcherDAL.Models
{
    public class OrderDAL : DAL
    {
        public string OrderDate { get; set; }
        public int Product_Id { get; set; }
        public int Client_Id { get; set; }
        public int Manager_Id { get; set; }
    }
}
