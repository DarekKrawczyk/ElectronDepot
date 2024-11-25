using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Server.Models
{
    public class Project
    {
        #region Primary Key
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProjectID { get; set; }
        #endregion
        #region Foreign Keys
        [Required]
        [ForeignKey(nameof(User))]
        public int UserID { get; set; }
        public User? User { get; set; }

        public ICollection<ProjectComponent> ProjectComponents { get; set; } = new List<ProjectComponent>();
        #endregion
        #region Fields
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Name { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public string? Description { get; set; }
        
        [Required]
        public DateTime CreatedAt { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public string ImageURI { get; set; }
        #endregion
    }
}
