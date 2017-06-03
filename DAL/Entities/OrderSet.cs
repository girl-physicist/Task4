namespace DAL.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("OrderSet")]
    public class OrderSet
    {
        [Key]
        public int IdOrder { get; set; }

        [Required]
        public string OrderDate { get; set; }

        public int ManagerId { get; set; }

        public int ClientId { get; set; }
    }
}
