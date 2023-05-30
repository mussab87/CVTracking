using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Domain.Entities { }

public class UserPassword
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key, Column(Order = 0)]
    public int Id { get; set; }
    public string UserId { get; set; }
    public DateTime PasswordChange { get; set; }
    public string OldPassword { get; set; }
    public string NewPassword { get; set; }
}

