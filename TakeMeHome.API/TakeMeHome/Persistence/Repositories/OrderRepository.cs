using Microsoft.EntityFrameworkCore;
using TakeMeHome.API.TakeMeHome.Domain.Models;
using TakeMeHome.API.TakeMeHome.Domain.Repositories;
using TakeMeHome.API.TakeMeHome.Persistence.Contexts;

namespace TakeMeHome.API.TakeMeHome.Persistence.Repositories;

public class OrderRepository : BaseRepository, IOrderRepository
{
    public OrderRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Order>> ListAsync()
    {
        return await _context.Orders
            .Include(p => p.OrderStatus)
            .Include(p=>p.Product)
            .ToListAsync();
    }

    public async Task AddAsync(Order order)
    {
        await _context.Orders.AddAsync(order);
    }

    public async Task<Order> FindByIdAsync(int id)
    {
        return await _context.Orders
            .Include(p => p.OrderStatus)
            .Include(p=>p.Product)
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<IEnumerable<Order>> FindByOrderStatusId(int orderStatusId)
    {
        return await _context.Orders
            .Include(p => p.OrderStatus)
            .Include(p=>p.Product)
            .Where(p => p.OrderStatusId == orderStatusId)
            .ToListAsync();
    }

    public async Task<IEnumerable<Order>> FindyByUserId(int userId)
    {
        return await _context.Orders
            .Include(p => p.OrderStatus)
            .Where(p => p.UserId == userId)
            .ToListAsync();
    }

    public void Update(Order order)
    {
        _context.Orders.Update(order);
    }

    public void Remove(Order order)
    {
        _context.Orders.Remove(order);
    }
}