using RestaurantAGV.MVC.Models.Entities;
using RestaurantAGV.MVC.Services.Interfaces;
using RestaurantAGV.MVC.Database;
using Microsoft.EntityFrameworkCore;

namespace RestaurantAGV.MVC.Services.Classes;

public class TableRepository : ITableRepository
{   
    private readonly RestaurantDbContext _dbContext;

    public TableRepository(RestaurantDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<Table?> CreateAsync(Table table)
    {   
        return Task.Run(() => {
            if (_dbContext.Tables == null)
                return null;
            Table addedEntity = _dbContext.Tables.Add(table).Entity;
            int result = _dbContext.SaveChanges();
            return (result > 0 && addedEntity != null)? addedEntity:null;
        });
    }

    public Task<bool> DeleteAsync(int id)
    {
        return Task.Run(() => {
            if (_dbContext.Tables == null)
                return false;
            Table deletedEntity = _dbContext.Tables.First(e => e.Id == id);
            _dbContext.Tables.Remove(deletedEntity);
            int result = _dbContext.SaveChanges();
            return (result > 1)? true:false;
        });
    }

    public Task<IList<Table>?> RetrieveAsync()
    {
        return Task.Run(() => {
            if (_dbContext.Tables == null)
                return null;
            IList<Table> tables = _dbContext.Tables.AsNoTracking().ToList();
            return (tables.Count > 0)? tables:null;
        });
    }

    public Task<Table?> RetrieveByIdAsync(int id)
    {
        return Task.Run(() => {
            if (_dbContext.Tables == null)
                return null;
            Table? table = _dbContext.Tables.AsNoTracking().FirstOrDefault(e => e.Id == id);
            return table;
        });
    }

    public Task<Table?> UpdateAsync(Table table)
    {
        return Task.Run(() => {
            if (_dbContext.Tables == null)
                return null;
            Table? updaedEntity = _dbContext.Tables.Update(table).Entity;
            return updaedEntity;
        });
    }
}