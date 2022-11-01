using RestaurantAGV.MVC.Models.Entities;
namespace RestaurantAGV.MVC.Services.Interfaces;

public interface IPurchasedMenuRepository{
    
    Task<IList<PurchasedMenu>?> RetrieveAsync();
    Task<PurchasedMenu?> RetrieveByIdAsync(int id);
    Task<PurchasedMenu?> CreateAsync(PurchasedMenu purchasedMenu);
    Task<PurchasedMenu?> UpdateAsync(PurchasedMenu purchasedMenu);
    Task<bool> DeleteAsync(int id);


}