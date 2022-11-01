using RestaurantAGV.MVC.Models.Entities;
namespace RestaurantAGV.MVC.Services.Interfaces;

public interface ITableRepository{
    
    Task<IList<Table>?> RetrieveAsync();
    Task<Table?> RetrieveByIdAsync(int id);
    Task<Table?> CreateAsync(Table table);
    Task<Table?> UpdateAsync(Table table);
    Task<bool> DeleteAsync(int id);


}