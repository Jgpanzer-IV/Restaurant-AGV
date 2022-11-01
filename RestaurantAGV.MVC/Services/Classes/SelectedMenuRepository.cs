using RestaurantAGV.MVC.Models.Entities;
using RestaurantAGV.MVC.Services.Interfaces;
using RestaurantAGV.MVC.Database;
using Microsoft.EntityFrameworkCore;

namespace RestaurantAGV.MVC.Services.Classes;

public class SelectedMenuRepository : ISelectedMenuRepository
{   
    private readonly RestaurantDbContext _dbContext;

    public SelectedMenuRepository(RestaurantDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<SelectedMenu?> CreateAsync(SelectedMenu menu)
    {   
        return Task.Run(() => {
            if (_dbContext.SelectedMenus == null)
                return null;
            SelectedMenu? addedEntity = _dbContext.SelectedMenus.Add(menu).Entity;
            int result = _dbContext.SaveChanges();
            return (result > 0 && addedEntity != null)? addedEntity:null;
        });
    }

    public Task<bool> DeleteAsync(int id)
    {
        return Task.Run(() => {
            if (_dbContext.SelectedMenus == null)
                return false;
            SelectedMenu? deletedEntity = _dbContext.SelectedMenus.FirstOrDefault(e => e.Id == id);
            if (deletedEntity == null)
                return false;
            _dbContext.SelectedMenus.Remove(deletedEntity);
            int result = _dbContext.SaveChanges();
            return (result > 1)? true:false;
        });
    }

    public Task<IList<SelectedMenu>?> RetrieveAsync()
    {
        return Task.Run(() => {
            if (_dbContext.SelectedMenus == null)
                return null;
            IList<SelectedMenu> selectedMenus = _dbContext.SelectedMenus.AsNoTracking().ToList();
            return (selectedMenus.Count > 0)? selectedMenus:null;
        });
    }

    public Task<SelectedMenu?> RetrieveByIdAsync(int id)
    {
        return Task.Run(() => {
            if (_dbContext.SelectedMenus == null)
                return null;
            SelectedMenu? selectedMenu = _dbContext.SelectedMenus.Include(e => e.Basket).AsNoTracking().FirstOrDefault(e => e.Id == id);
            return selectedMenu;
        });
    }

    public Task<SelectedMenu?> UpdateAsync(SelectedMenu selectedMenu)
    {
        return Task.Run(() => {
            if (_dbContext.SelectedMenus == null)
                return null;
            SelectedMenu? updaedEntity = _dbContext.SelectedMenus.Update(selectedMenu).Entity;
            return updaedEntity;
        });
    }
}