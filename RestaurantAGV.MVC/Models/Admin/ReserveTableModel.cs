using RestaurantAGV.MVC.Models.Elements;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace RestaurantAGV.MVC.Models.Admin;

public class ReserveTableModel{

    public IList<TableCard>? Tables {get;set;}
    public IList<SelectListItem>? AddressList {get;set;}

}