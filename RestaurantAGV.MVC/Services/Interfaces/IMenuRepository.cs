using RestaurantAGV.MVC.Models.Entities;
namespace RestaurantAGV.MVC.Services.Interfaces;

public interface IMenuRepository{
    
    Task<IList<Menu>?> RetrieveAsync();
    Task<Menu?> RetrieveByIdAsync(int id);
    Task<Menu?> CreateAsync(Menu menu);
    Task<Menu?> UpdateAsync(Menu menu);
    Task<bool> DeleteAsync(int id);


}