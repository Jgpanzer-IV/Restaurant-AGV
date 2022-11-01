using RestaurantAGV.MVC.Models.Entities;
namespace RestaurantAGV.MVC.Services.Interfaces;

public interface IBillingOrderRepository{
    
    Task<IList<BillOrder>?> RetrieveAsync();
    Task<BillOrder?> RetrieveByIdAsync(int id);
    Task<BillOrder?> CreateAsync(BillOrder billOrder);
    Task<BillOrder?> UpdateAsync(BillOrder billOrder);
    Task<bool> DeleteAsync(int id);


}