namespace DAL.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ProductSet")]
    public class ProductSet
    {
        [Key]
        public int IdProduct { get; set; }

        [Required]
        public string ProductName { get; set; }

        [Required]
        public string ProductCost { get; set; }

        public int OrderId { get; set; }
    }
}
