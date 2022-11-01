using RestaurantAGV.MVC.Models.Entities;
using RestaurantAGV.MVC.Services.Interfaces;
using RestaurantAGV.MVC.Database;
using Microsoft.EntityFrameworkCore;

namespace RestaurantAGV.MVC.Services.Classes;

public class MenuRepository : IMenuRepository
{   
    private readonly RestaurantDbContext _dbContext;

    public MenuRepository(RestaurantDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<Menu?> CreateAsync(Menu menu)
    {   
        return Task.Run(() => {
            if (_dbContext.Menues == null)
                return null;
            Menu addedEntity = _dbContext.Menues.Add(menu).Entity;
            int result = _dbContext.SaveChanges();
            return (result > 0 && addedEntity != null)? addedEntity:null;
        });
    }

    public Task<bool> DeleteAsync(int id)
    {
        return Task.Run(() => {
            if (_dbContext.Menues == null)
                return false;
            Menu deletedEntity = _dbContext.Menues.First(e => e.Id == id);
            _dbContext.Menues.Remove(deletedEntity);
            int result = _dbContext.SaveChanges();
            return (result > 1)? true:false;
        });
    }

    public Task<IList<Menu>?> RetrieveAsync()
    {
        return Task.Run(() => {
            if (_dbContext.Menues == null)
                return null;
            IList<Menu> menus = _dbContext.Menues.AsNoTracking().ToList();
            return (menus.Count > 0)? menus:null;
        });
    }

    public Task<Menu?> RetrieveByIdAsync(int id)
    {
        return Task.Run(() => {
            if (_dbContext.Menues == null)
                return null;
            Menu? menu = _dbContext.Menues.Include(e => e.MenuCategory).AsNoTracking().FirstOrDefault(e => e.Id == id);
            return menu;
        });
    }

    public Task<Menu?> UpdateAsync(Menu menu)
    {
        return Task.Run(() => {
            if (_dbContext.Menues == null)
                return null;
            Menu? updaedEntity = _dbContext.Menues.Update(menu).Entity;
            return updaedEntity;
        });
    }
}