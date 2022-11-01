using RestaurantAGV.MVC.Models.Entities;
using RestaurantAGV.MVC.Services.Interfaces;
using RestaurantAGV.MVC.Database;
using Microsoft.EntityFrameworkCore;

namespace RestaurantAGV.MVC.Services.Classes;

public class PurchasedOrderRepository : IPurchasedOrderRepository
{   
    private readonly RestaurantDbContext _dbContext;

    public PurchasedOrderRepository(RestaurantDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<PurchasedOrder?> CreateAsync(PurchasedOrder pruchasedOrder)
    {   
        return Task.Run(() => {
            if (_dbContext.PurchasedOrders == null)
                return null;
            PurchasedOrder? addedEntity = _dbContext.PurchasedOrders.Add(pruchasedOrder).Entity;
            int result = _dbContext.SaveChanges();
            return (result > 0 && addedEntity != null)? addedEntity:null;
        });
    }

    public Task<bool> DeleteAsync(int id)
    {
        return Task.Run(() => {
            if (_dbContext.PurchasedOrders == null)
                return false;
            PurchasedOrder? deletedEntity = _dbContext.PurchasedOrders.FirstOrDefault(e => e.Id == id);
            if (deletedEntity == null)
                return false;
            _dbContext.PurchasedOrders.Remove(deletedEntity);
            int result = _dbContext.SaveChanges();
            return (result > 1)? true:false;
        });
    }

    public Task<IList<PurchasedOrder>?> RetrieveAsync()
    {
        return Task.Run(() => {
            if (_dbContext.PurchasedOrders == null)
                return null;
            IList<PurchasedOrder> purchasedOrders = _dbContext.PurchasedOrders.AsNoTracking().ToList();
            return (purchasedOrders.Count > 0)? purchasedOrders:null;
        });
    }

    public Task<PurchasedOrder?> RetrieveByIdAsync(int id)
    {
        return Task.Run(() => {
            if (_dbContext.PurchasedOrders == null)
                return null;
            PurchasedOrder? purchasedOrder = _dbContext.PurchasedOrders
                .Include(e => e.PurchasedMenus)
                .Include(e => e.Customer)
                .AsNoTracking().FirstOrDefault(e => e.Id == id);
            return purchasedOrder;
        });
    }

    public Task<PurchasedOrder?> UpdateAsync(PurchasedOrder puchasedOrder)
    {
        return Task.Run(() => {
            if (_dbContext.PurchasedOrders == null)
                return null;
            PurchasedOrder? updaedEntity = _dbContext.PurchasedOrders.Update(puchasedOrder).Entity;
            return updaedEntity;
        });
    }
}