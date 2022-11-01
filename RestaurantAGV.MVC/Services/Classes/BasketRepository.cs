using RestaurantAGV.MVC.Models.Entities;
using RestaurantAGV.MVC.Services.Interfaces;
using RestaurantAGV.MVC.Database;
using Microsoft.EntityFrameworkCore;

namespace RestaurantAGV.MVC.Services.Classes;

public class BasketRepository : IBasketRepository
{
    private readonly RestaurantDbContext _dbContext;

    public BasketRepository(RestaurantDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<Basket?> CreateAsync(Basket basket)
    {   
        return Task.Run(() => {
            if (_dbContext.Baskets == null)
                return null;
            Basket addedEntity = _dbContext.Baskets.Add(basket).Entity;
            int result = _dbContext.SaveChanges();
            return (result > 0 && addedEntity != null)? addedEntity:null;
        });
    }

    public Task<bool> DeleteAsync(int id)
    {
        return Task.Run(() => {
            if (_dbContext.Baskets == null)
                return false;
            Basket deletedEntity = _dbContext.Baskets.First(e => e.Id == id);
            _dbContext.Baskets.Remove(deletedEntity);
            int result = _dbContext.SaveChanges();
            return (result > 1)? true:false;
        });
    }

    public Task<IList<Basket>?> RetrieveAsync()
    {
        return Task.Run(() => {
            if (_dbContext.Baskets == null)
                return null;
            IList<Basket> baskets = _dbContext.Baskets.AsNoTracking().ToList();
            return (baskets.Count > 0)? baskets:null;
        });
    }

    public Task<Basket?> RetrieveByIdAsync(int id)
    {
        return Task.Run(() => {
            if (_dbContext.Baskets == null)
                return null;
            Basket? basket = _dbContext.Baskets
                .Include(e => e.SelectedMenus) 
                .Include(e => e.PurchasedMenus)
                .AsNoTracking().FirstOrDefault(e => e.Id == id);
            return basket;
        });
    }

    public Task<Basket?> UpdateAsync(Basket basket)
    {
        return Task.Run(() => {
            if (_dbContext.Baskets == null)
                return null;
            Basket? updaedEntity = _dbContext.Baskets.Update(basket).Entity;
            return updaedEntity;
        });
    }
}