using RestaurantAGV.MVC.Models.Entities;
namespace RestaurantAGV.MVC.Services.Interfaces;

public interface IPurchasedOrderRepository{
    
    Task<IList<PurchasedOrder>?> RetrieveAsync();
    Task<PurchasedOrder?> RetrieveByIdAsync(int id);
    Task<PurchasedOrder?> CreateAsync(PurchasedOrder purchasedOrder);
    Task<PurchasedOrder?> UpdateAsync(PurchasedOrder purchasedOrder);
    Task<bool> DeleteAsync(int id);


}