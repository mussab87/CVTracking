
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace App.Domain.Common { }

public abstract class CountryCityBase
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key, Column(Order = 0)]
    public int Id { get; protected set; }
    public string NameEnglish { get; set; }
    public string NameArabic { get; set; }
    public bool? Status { get; set; }

    public string? CreatedById { get; set; }
    public ApplicationUser CreatedBy { get; set; }
    public DateTime CreatedDate { get; set; }

    public string? LastModifiedById { get; set; }
    public ApplicationUser LastModifiedBy { get; set; }
    public DateTime? LastModifiedDate { get; set; }
}

