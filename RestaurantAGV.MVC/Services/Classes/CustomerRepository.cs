using RestaurantAGV.MVC.Models.Entities;
using RestaurantAGV.MVC.Services.Interfaces;
using RestaurantAGV.MVC.Database;
using Microsoft.EntityFrameworkCore;

namespace RestaurantAGV.MVC.Services.Classes;

public class CustomerRepository : ICustomerRepository
{   
    private readonly RestaurantDbContext _dbContext;

    public CustomerRepository(RestaurantDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<Customer?> CreateAsync(Customer customer)
    {   
        return Task.Run(() => {
            if (_dbContext.Customers == null)
                return null;
            Customer addedEntity = _dbContext.Customers.Add(customer).Entity;
            int result = _dbContext.SaveChanges();
            return (result > 0 && addedEntity != null)? addedEntity:null;
        });
    }

    public Task<bool> DeleteAsync(string id)
    {
        return Task.Run(() => {
            if (_dbContext.Customers == null)
                return false;
            Customer deletedEntity = _dbContext.Customers.First(e => e.Id == id);
            _dbContext.Customers.Remove(deletedEntity);
            int result = _dbContext.SaveChanges();
            return (result > 1)? true:false;
        });
    }

    public Task<IList<Customer>?> RetrieveAsync()
    {
        return Task.Run(() => {
            if (_dbContext.Customers == null)
                return null;
            IList<Customer> customers = _dbContext.Customers
                .AsNoTracking()
                .ToList();
            return (customers.Count > 0)? customers:null;
        });
    }

    public Task<Customer?> RetrieveByIdAsync(string id)
    {
        return Task.Run(() => {
            if (_dbContext.Customers == null)
                return null;
            Customer? customer = _dbContext.Customers
                .Include(e => e.Table)
                .Include(e => e.BillOrder)
                .Include(e => e.Basket)
                .Include(e => e.PurchasedOrders)
                .AsNoTracking()
                .FirstOrDefault(e => e.Id == id);
            return customer;
        });
    }

    public Task<Customer?> UpdateAsync(Customer customer)
    {
        return Task.Run(() => {
            if (_dbContext.Customers == null)
                return null;
            Customer? updaedEntity = _dbContext.Customers.Update(customer).Entity;
            return updaedEntity;
        });
    }
}