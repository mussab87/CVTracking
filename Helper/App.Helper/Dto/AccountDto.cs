
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace App.Helper.Dto { }
public class AccountDto
{
    [Required(ErrorMessage = "Username Field Required")]
    [Remote(action: "IsUsernameInUse", controller: "SuperAdmin")]
    [Display(Name = "Username")]
    public required string Username { get; set; }

    [Required(ErrorMessage = "Password Field Required")]
    [DataType(DataType.Password)]
    [Display(Name = "Password")]
    public required string Password { get; set; }

    [DataType(DataType.Password)]
    [Display(Name = "Confirm Password")]
    [System.ComponentModel.DataAnnotations.Compare("Password",
        ErrorMessage = "Password and Confirm Password not match")]
    public required string ConfirmPassword { get; set; }

    [Required(ErrorMessage = "First Name Field Required")]
    [Display(Name = "First Name")]
    public required string FirstName { get; set; }

    [Required(ErrorMessage = "Last Name Field Required")]
    [Display(Name = "Last Name")]
    public required string LastName { get; set; }

    [Display(Name = "First Name Arabic")]
    public string? FirstNameArabic { get; set; }

    [Display(Name = "Last Name Arabic")]
    public string? LastNameArabic { get; set; }

    [Required(ErrorMessage = "Phone Number Field Required")]
    [Display(Name = "Phone Number")]
    public required string PhoneNumber { get; set; }

    [Required]
    [EmailAddress]
    [Remote(action: "IsEmailInUse", controller: "SuperAdmin")]
    public required string Email { get; set; }

    [Required(ErrorMessage = "User Status Field Required")]
    [Display(Name = "User Status")]
    public required bool UserStatus { get; set; }

    public List<IdentityRole>? Roles { get; set; }

}

