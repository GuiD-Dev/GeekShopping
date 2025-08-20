using Microsoft.EntityFrameworkCore;
using OrderAPI.Models;

namespace OrderAPI.DBContext;

public class MySQLContext : DbContext
{
    public MySQLContext(DbContextOptions<MySQLContext> options) : base(options) { }

    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }

}
