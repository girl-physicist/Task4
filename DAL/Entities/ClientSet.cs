namespace DAL.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ClientSet")]
    public class ClientSet
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string ClientName { get; set; }
    }
}
