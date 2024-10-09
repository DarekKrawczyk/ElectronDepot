using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Server.Models
{
    public class Component
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ComponentID { get; set; }

        [Required]
        [ForeignKey(nameof(Category))]
        public int CategoryID { get; set; }
        public Category? Category { get; set; }

        public ICollection<PurchaseItem> PurchaseItems { get; set; } = new List<PurchaseItem>();

        [Column(TypeName = "nvarchar(100)")]
        public string Name { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Manufacturer { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public string Description { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Location { get; set; }
    }
}
