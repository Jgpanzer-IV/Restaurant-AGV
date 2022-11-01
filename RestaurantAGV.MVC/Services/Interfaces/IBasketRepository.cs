using RestaurantAGV.MVC.Models.Entities;
namespace RestaurantAGV.MVC.Services.Interfaces;

public interface IBasketRepository{
    
    Task<IList<Basket>?> RetrieveAsync();
    Task<Basket?> RetrieveByIdAsync(int id);
    Task<Basket?> CreateAsync(Basket basket);
    Task<Basket?> UpdateAsync(Basket basket);
    Task<bool> DeleteAsync(int id);


}