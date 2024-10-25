using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Server.Models
{
    public class PurchaseItem
    {
        #region Primary Key
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PurchaseItemID { get; set; }
        #endregion
        #region Foreign Keys
        [Required]
        [ForeignKey(nameof(Purchase))]
        public int PurchaseID { get; set; }
        public Purchase? Purchase { get; set; }

        [Required]
        [ForeignKey(nameof(Component))]
        public int ComponentID { get; set; }
        public Component? Component { get; set; }
        #endregion
        #region Fields
        public int Quantity { get; set; }
        public double PricePerUnit { get; set; }
        #endregion
    }
}
