using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Server.Models
{
    public class Category
    {
        #region Primary Key
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryID { get; set; }
        #endregion
        #region Foreign Keys
        public ICollection<Component> Components { get; set; } = new List<Component>();
        #endregion
        #region Fields
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Name { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public string? Description { get; set; }
        #endregion
    }
}
