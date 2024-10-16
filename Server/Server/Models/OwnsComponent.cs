using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Server.Models
{
    public class OwnsComponent
    {
        #region Primary Key
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OwnsComponentID { get; set; }
        #endregion
        #region Foreign Keys
        [Required]
        [ForeignKey(nameof(User))]
        public int UserID { get; set; }
        public User? User { get; set; }

        [Required]
        [ForeignKey(nameof(Component))]
        public int ComponentID { get; set; }
        public Component? Component { get; set; }
        #endregion
        #region Fields
        public int Quantity { get; set; }
        #endregion
    }
}
