using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Server.Models
{
    public class Supplier
    {
        #region Primary Key
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SupplierID { get; set; }
        #endregion
        #region Foreign Keys
        public ICollection<Purchase> Purchases { get; set; } = new List<Purchase>();
        #endregion
        #region Fields
        [Required]
        [Column(TypeName = "nvarchar(255)")]
        public string Name { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public string Website { get; set; }

        [Required]
        public byte[] Image { get; set; }
        #endregion
    }
}
