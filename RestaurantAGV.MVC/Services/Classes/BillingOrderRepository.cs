using RestaurantAGV.MVC.Models.Entities;
using RestaurantAGV.MVC.Services.Interfaces;
using RestaurantAGV.MVC.Database;
using Microsoft.EntityFrameworkCore;

namespace RestaurantAGV.MVC.Services.Classes;

public class BillingOrderRepository : IBillingOrderRepository
{
    private readonly RestaurantDbContext _dbContext;

    public BillingOrderRepository(RestaurantDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<BillOrder?> CreateAsync(BillOrder billOrder)
    {   
        return Task.Run(() => {
            if (_dbContext.BillOrders == null)
                return null;
            BillOrder addedEntity = _dbContext.BillOrders.Add(billOrder).Entity;
            int result = _dbContext.SaveChanges();
            return (result > 0 && addedEntity != null)? addedEntity:null;
        });
    }

    public Task<bool> DeleteAsync(int id)
    {
        return Task.Run(() => {
            if (_dbContext.BillOrders == null)
                return false;
            BillOrder deletedEntity = _dbContext.BillOrders.First(e => e.Id == id);
            _dbContext.BillOrders.Remove(deletedEntity);
            int result = _dbContext.SaveChanges();
            return (result > 1)? true:false;
        });
    }

    public Task<IList<BillOrder>?> RetrieveAsync()
    {
        return Task.Run(() => {
            if (_dbContext.BillOrders == null)
                return null;
            IList<BillOrder> billOrders = _dbContext.BillOrders.AsNoTracking().ToList();
            return (billOrders.Count > 0)? billOrders:null;
        });
    }

    public Task<BillOrder?> RetrieveByIdAsync(int id)
    {
        return Task.Run(() => {
            if (_dbContext.BillOrders == null)
                return null;
            BillOrder? billOrder = _dbContext.BillOrders.AsNoTracking().FirstOrDefault(e => e.Id == id);
            return billOrder;
        });
    }

    public Task<BillOrder?> UpdateAsync(BillOrder billOrder)
    {
        return Task.Run(() => {
            if (_dbContext.BillOrders == null)
                return null;
            BillOrder? updaedEntity = _dbContext.BillOrders.Update(billOrder).Entity;
            return updaedEntity;
        });
    }
}