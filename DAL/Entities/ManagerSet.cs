namespace DAL.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ManagerSet")]
    public class ManagerSet
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string ManagerName { get; set; }
    }
}
