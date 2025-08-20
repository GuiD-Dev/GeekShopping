using OrderAPI.Models;

namespace OrderAPI.Repositories;

public interface IOrderRepository
{
    Task<bool> AddOrder(Order order);
    Task UpdateOrderPaymentStatus(long orderId, bool paid);
}
