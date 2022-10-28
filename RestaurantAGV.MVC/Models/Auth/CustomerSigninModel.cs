using System.ComponentModel.DataAnnotations;

namespace RestaurantAGV.MVC.Models.Auth;

public class CustomerSigninModel {

    [Required(ErrorMessage = "Please enter your credencial.")]
    [DataType(DataType.Text)]
    [MaxLength(4)]
    [RegularExpression("^[A-Z]{4}$",ErrorMessage = "Please enter only uppercase character")]
    public string? Credencial {get;set;}

    [Required]
    public string? ReturnUrl {get;set;}

    
    public string? ErrorMessage {get;set;}
}