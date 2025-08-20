using Microsoft.EntityFrameworkCore;
using OrderAPI.DBContext;
using OrderAPI.Models;

namespace OrderAPI.Repositories;

public class OrderRepository(DbContextOptions<MySQLContext> context) : IOrderRepository
{
    public async Task<bool> AddOrder(Order order)
    {
        if (order == null) return false;

        await using var db = new MySQLContext(context);
        db.Orders.Add(order);
        db.SaveChanges();

        return true;
    }

    public async Task UpdateOrderPaymentStatus(long orderId, bool status)
    {
        await using var db = new MySQLContext(context);

        var order = db.Orders.FirstOrDefault(o => o.Id == orderId);
        if (order != null)
        {
            order.PaymentStatus = status;
            await db.SaveChangesAsync();
        }
    }
}
