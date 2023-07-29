
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace App.Domain.Entities { }

public class CancelReason : EntityBase
{
    public string CancelReasonEnglish { get; set; }
    public string CancelReasonArabic { get; set; }
    public bool? Status { get; set; }
}

