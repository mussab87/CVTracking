using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Domain.Entities { }

public class UserTransaction
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key, Column(Order = 0)]
    public int Id { get; set; }
    public string UserId { get; set; }
    public DateTime? LogginDateTime { get; set; }
    public DateTime? LoggedOutDateTime { get; set; }

}

