


using RestaurantAGV.MVC.Models.Entities;
using RestaurantAGV.MVC.Services.Interfaces;
using RestaurantAGV.MVC.Database;
using Microsoft.EntityFrameworkCore;

namespace RestaurantAGV.MVC.Services.Classes;

public class MenusStatusRepository : IMenusStatusRepository
{   
    private readonly RestaurantDbContext _dbContext;

    public MenusStatusRepository(RestaurantDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<MenusStatus?> CreateAsync(MenusStatus menu)
    {   
        return Task.Run(() => {
            if (_dbContext.MenusStatus == null)
                return null;
            MenusStatus addedEntity = _dbContext.MenusStatus.Add(menu).Entity;
            int result = _dbContext.SaveChanges();
            return (result > 0 && addedEntity != null)? addedEntity:null;
        });
    }

    public Task<bool> DeleteAsync(int id)
    {
        return Task.Run(() => {
            if (_dbContext.MenusStatus == null)
                return false;
            MenusStatus deletedEntity = _dbContext.MenusStatus.First(e => e.Id == id);
            _dbContext.MenusStatus.Remove(deletedEntity);
            int result = _dbContext.SaveChanges();
            return (result > 1)? true:false;
        });
    }

    public Task<IList<MenusStatus>?> RetrieveAsync()
    {
        return Task.Run(() => {
            if (_dbContext.MenusStatus == null)
                return null;
            IList<MenusStatus> menus = _dbContext.MenusStatus.AsNoTracking().ToList();
            return (menus.Count > 0)? menus:null;
        });
    }

    public Task<MenusStatus?> RetrieveByIdAsync(int id)
    {
        return Task.Run(() => {
            if (_dbContext.MenusStatus == null)
                return null;
            MenusStatus? menu = _dbContext.MenusStatus.Include(e => e.PurchasedMenu).AsNoTracking().FirstOrDefault(e => e.Id == id);
            return menu;
        });
    }

    public Task<MenusStatus?> UpdateAsync(MenusStatus menu)
    {
        return Task.Run(() => {
            if (_dbContext.MenusStatus == null)
                return null;
            MenusStatus? updaedEntity = _dbContext.MenusStatus.Update(menu).Entity;
            int result = _dbContext.SaveChanges();

            return (result > 0)? updaedEntity:null;
        });
    }
}