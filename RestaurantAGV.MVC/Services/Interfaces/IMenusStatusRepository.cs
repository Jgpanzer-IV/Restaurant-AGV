using RestaurantAGV.MVC.Models.Entities;
namespace RestaurantAGV.MVC.Services.Interfaces;

public interface IMenusStatusRepository{
    
    Task<IList<MenusStatus>?> RetrieveAsync();
    Task<MenusStatus?> RetrieveByIdAsync(int id);
    Task<MenusStatus?> CreateAsync(MenusStatus menu);
    Task<MenusStatus?> UpdateAsync(MenusStatus menu);
    Task<bool> DeleteAsync(int id);


}