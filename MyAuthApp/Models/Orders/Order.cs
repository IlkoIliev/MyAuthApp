using System.ComponentModel.DataAnnotations.Schema;

namespace MyAuthApp.Models.Orders
{
    public class Order
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }
    }
}
