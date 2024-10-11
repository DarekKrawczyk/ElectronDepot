using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Server.Models
{
    public class Component
    {
        #region Primary Key
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ComponentID { get; set; }
        #endregion
        #region Foreign Keys
        [Required]
        [ForeignKey(nameof(Category))]
        public int CategoryID { get; set; }
        public Category? Category { get; set; }

        [Required]
        [ForeignKey(nameof(User))]
        public int UserID { get; set; }
        public User? User { get; set; }

        public ICollection<PurchaseItem> PurchaseItems { get; set; } = new List<PurchaseItem>();
        public ICollection<ProjectComponent> ProjectComponents { get; set; } = new List<ProjectComponent>();
        #endregion
        #region Fields
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Manufacturer { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public string? Description { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string? Location { get; set; }

        public int Quantity { get; set; }
        #endregion
    }
}
