using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Server.Models
{
    public class ProjectComponent
    {
        #region Primary Key
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProjectComponentID { get; set; }
        #endregion
        #region Foreign Keys
        [Required]
        [ForeignKey(nameof(Component))]
        public int ComponentID { get; set; }
        public Component? Component { get; set; }

        [Required]
        [ForeignKey(nameof(Project))]
        public int ProjectID { get; set; }
        public Project? Project { get; set; }
        #endregion
        #region Fields
        public int Quantity { get; set; }
        #endregion
    }
}
