using Zekavit_Shared;
using Zekavit_Shared.DTO;
using Zekavit_Shared.Entity;

namespace Zekavit_MVC.Services.Abstract
{
    public interface IOrderService
    {

        Task<ServiceResponse<Order>> CreateOrder(OrderDTO model, List<Product> _product);
        Task<ServiceResponse<List<Order>>> ListOrders();
        Task<ServiceResponse<Order>> GetOrderById(int id);
        Task<ServiceResponse<List<Order>>> MyOrders(string userId);
    }
}
