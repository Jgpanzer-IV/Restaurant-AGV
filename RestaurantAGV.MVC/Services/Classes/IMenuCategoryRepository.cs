using RestaurantAGV.MVC.Models.Entities;
using RestaurantAGV.MVC.Services.Interfaces;
using RestaurantAGV.MVC.Database;
using Microsoft.EntityFrameworkCore;

namespace RestaurantAGV.MVC.Services.Classes;

public class MenuCategortRepository : IMenuCategoryRepository
{   
    private readonly RestaurantDbContext _dbContext;

    public MenuCategortRepository(RestaurantDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<MenuCategory?> CreateAsync(MenuCategory menuCategory)
    {   
        return Task.Run(() => {
            if (_dbContext.MenuCategories == null)
                return null;
            MenuCategory addedEntity = _dbContext.MenuCategories.Add(menuCategory).Entity;
            int result = _dbContext.SaveChanges();
            return (result > 0 && addedEntity != null)? addedEntity:null;
        });
    }

    public Task<bool> DeleteAsync(int id)
    {
        return Task.Run(() => {
            if (_dbContext.MenuCategories == null)
                return false;
            MenuCategory deletedEntity = _dbContext.MenuCategories.First(e => e.Id == id);
            _dbContext.MenuCategories.Remove(deletedEntity);
            int result = _dbContext.SaveChanges();
            return (result > 1)? true:false;
        });
    }

    public Task<IList<MenuCategory>?> RetrieveAsync()
    {
        return Task.Run(() => {
            if (_dbContext.MenuCategories == null)
                return null;
            IList<MenuCategory> menuCategories = _dbContext.MenuCategories.Include(e => e.Menus).AsNoTracking().ToList();
            return (menuCategories.Count > 0)? menuCategories:null;
        });
    }

    public Task<MenuCategory?> RetrieveByIdAsync(int id)
    {
        return Task.Run(() => {
            if (_dbContext.MenuCategories == null)
                return null;
            MenuCategory? customer = _dbContext.MenuCategories.AsNoTracking().FirstOrDefault(e => e.Id == id);
            return customer;
        });
    }

    public Task<MenuCategory?> UpdateAsync(MenuCategory menuCategory)
    {
        return Task.Run(() => {
            if (_dbContext.MenuCategories == null)
                return null;
            MenuCategory? updaedEntity = _dbContext.MenuCategories.Update(menuCategory).Entity;
            return updaedEntity;
        });
    }
}