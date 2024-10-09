using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Server.Models
{
    public class PurchaseItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PurchaseItemID { get; set; }

        [Required]
        [ForeignKey(nameof(Purchase))]
        public int PurchaseID { get; set; }
        public Purchase? Purchase { get; set; }

        public int Quantity { get; set; }
        public double PricePerUnit { get; set; }
    }
}
