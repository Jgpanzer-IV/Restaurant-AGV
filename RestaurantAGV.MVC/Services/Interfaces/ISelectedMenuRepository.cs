using RestaurantAGV.MVC.Models.Entities;
namespace RestaurantAGV.MVC.Services.Interfaces;

public interface ISelectedMenuRepository{
    
    Task<IList<SelectedMenu>?> RetrieveAsync();
    Task<SelectedMenu?> RetrieveByIdAsync(int id);
    Task<SelectedMenu?> CreateAsync(SelectedMenu selectedMenu);
    Task<SelectedMenu?> UpdateAsync(SelectedMenu selectedMenu);
    Task<bool> DeleteAsync(int id);


}