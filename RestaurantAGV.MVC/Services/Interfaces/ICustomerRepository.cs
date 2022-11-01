using RestaurantAGV.MVC.Models.Entities;
namespace RestaurantAGV.MVC.Services.Interfaces;

public interface ICustomerRepository{
    
    Task<IList<Customer>?> RetrieveAsync();
    Task<Customer?> RetrieveByIdAsync(string id);
    Task<Customer?> CreateAsync(Customer customer);
    Task<Customer?> UpdateAsync(Customer customer);
    Task<bool> DeleteAsync(string id);


}