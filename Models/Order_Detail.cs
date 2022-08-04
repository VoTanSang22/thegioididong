using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace thegioididong.Models
{
    public class Order_Detail
    {
        [Key]
        public int Id_D_Order { get; set; }
        [Required]
        [ForeignKey("Order")]
        public int Id_Order { get; set; }

        [Required]
        [ForeignKey("Product")]
        public int Id_pro { get; set; }
        public int amount { get; set; }
        public Order Order { get; set; }
        
        public Product Product { get; set; }
    }
}
