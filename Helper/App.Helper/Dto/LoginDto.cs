using System.ComponentModel.DataAnnotations;

namespace App.Helper.Dto { }

public class LoginDto
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Username Required Field")]
    public required string Username { get; set; }

    [Required(ErrorMessage = "Password Required Field")]
    [DataType(DataType.Password)]
    public required string Password { get; set; }
    public bool? RememberMe { get; set; }

    public string? a { get; set; }
    public int? result { get; set; }

    public string? ReturnUrl { get; set; }
}

