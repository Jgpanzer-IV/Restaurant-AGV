using RestaurantAGV.MVC.Models.Entities;
using RestaurantAGV.MVC.Services.Interfaces;
using RestaurantAGV.MVC.Database;
using Microsoft.EntityFrameworkCore;

namespace RestaurantAGV.MVC.Services.Classes;

public class PurchasedMenuRepository : IPurchasedMenuRepository
{   
    private readonly RestaurantDbContext _dbContext;

    public PurchasedMenuRepository(RestaurantDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<PurchasedMenu?> CreateAsync(PurchasedMenu pruchasedMenu)
    {   
        return Task.Run(() => {
            if (_dbContext.PurchasedMenues == null)
                return null;
            PurchasedMenu? addedEntity = _dbContext.PurchasedMenues.Add(pruchasedMenu).Entity;
            int result = _dbContext.SaveChanges();
            return (result > 0 && addedEntity != null)? addedEntity:null;
        });
    }

    public Task<bool> DeleteAsync(int id)
    {
        return Task.Run(() => {
            if (_dbContext.PurchasedMenues == null)
                return false;
            PurchasedMenu? deletedEntity = _dbContext.PurchasedMenues.FirstOrDefault(e => e.Id == id);
            if (deletedEntity == null)
                return false;
            _dbContext.PurchasedMenues.Remove(deletedEntity);
            int result = _dbContext.SaveChanges();
            return (result > 1)? true:false;
        });
    }

    public Task<IList<PurchasedMenu>?> RetrieveAsync()
    {
        return Task.Run(() => {
            if (_dbContext.PurchasedMenues == null)
                return null;
            IList<PurchasedMenu> purchasedMenus = _dbContext.PurchasedMenues.AsNoTracking().ToList();
            return (purchasedMenus.Count > 0)? purchasedMenus:null;
        });
    }

    public Task<PurchasedMenu?> RetrieveByIdAsync(int id)
    {
        return Task.Run(() => {
            if (_dbContext.PurchasedMenues == null)
                return null;
            PurchasedMenu? purchasedMenu = _dbContext.PurchasedMenues
                .Include(e => e.Basket)
                .Include(e => e.PurchasedOrder)
                .Include(e => e.Menu)
                .Include(e => e.Cook)
                .AsNoTracking().FirstOrDefault(e => e.Id == id);
            return purchasedMenu;
        });
    }

    public Task<PurchasedMenu?> UpdateAsync(PurchasedMenu puchasedMenu)
    {
        return Task.Run(() => {
            if (_dbContext.PurchasedMenues == null)
                return null;

            puchasedMenu.IsFinish = _dbContext.MenusStatus?.Where(e => e.PurchasedMenuId == puchasedMenu.Id && e.IsFinish == true).Count() == puchasedMenu.Quantity;
            PurchasedMenu? updaedEntity = _dbContext.PurchasedMenues.Update(puchasedMenu).Entity;
            int result = _dbContext.SaveChanges();
            return (result > 0)? updaedEntity:null;
        });
    }
}