using Zekavit_Shared.DTO;
using Zekavit_Shared.Entity;

namespace Zekavit_MVC.Models
{
    public class OrderLastProcessModel
    {
        public OrderDTO _orderDTO { get; set; } = new OrderDTO();
        public List<Product> _product { get; set; } = new List<Product>();
    }
}
