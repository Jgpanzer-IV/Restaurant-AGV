using RestaurantAGV.MVC.Models.Entities;
namespace RestaurantAGV.MVC.Services.Interfaces;

public interface IMenuCategoryRepository{
    
    Task<IList<MenuCategory>?> RetrieveAsync();
    Task<MenuCategory?> RetrieveByIdAsync(int id);
    Task<MenuCategory?> CreateAsync(MenuCategory menuCategory);
    Task<MenuCategory?> UpdateAsync(MenuCategory menuCategory);
    Task<bool> DeleteAsync(int id);


}