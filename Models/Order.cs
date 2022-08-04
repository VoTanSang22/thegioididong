using System.ComponentModel.DataAnnotations;
namespace thegioididong.Models
{
    public class Order
    {
        [Key]
        public int Id_Order { get; set; }
        public string address { get; set; }
        public string Name_Cus { get; set; }
        public string phone { get; set; }   
        public ICollection<Order_Detail> Details { get; set; }
    }
}
