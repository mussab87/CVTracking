using Microsoft.AspNetCore.Identity;

namespace App.Domain.UserSecurity { }

public class ApplicationUser : IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string FirstNameArabic { get; set; }
    public string LastNameArabic { get; set; }
    public override string UserName { get => base.UserName; set => base.UserName = value; }
    public bool? FirstLogin { get; set; }
    public bool? MaxMonthLock { get; set; }
    public bool? MonthLockStatus { get; set; }
    public bool? UserStatus { get; set; }

    public string CreatedBy { get; set; }
    public DateTime CreatedDate { get; set; }
    public string LastModifiedBy { get; set; }
    public DateTime? LastModifiedDate { get; set; }

    public int? RootCompanyId { get; set; }
}

