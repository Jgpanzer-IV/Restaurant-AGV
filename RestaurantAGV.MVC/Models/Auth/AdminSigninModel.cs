using System.ComponentModel.DataAnnotations;

namespace RestaurantAGV.MVC.Models.Auth;

public class AdminSigninModel{

    [Required(ErrorMessage = "Please enter your email.")]
    [DataType(DataType.EmailAddress)]
    public string? Email {get;set;}

    [Required(ErrorMessage = "Please enter your password")]
    [DataType(DataType.Password)]
    public string? Password {get;set;}

    public string? ErrorMessage {get;set;}
}