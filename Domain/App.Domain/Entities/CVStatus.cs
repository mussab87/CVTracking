
namespace App.Domain.Entities { }

public class CVStatus : EntityBase
{
    /// <summary>
    /// 0- Free
    /// 1- InComplete Foreign Agent
    /// 2- Post to Admin
    /// 3- Send to Local Agent
    /// 4- Selected - 5 days in Local Agent
    /// 5- Processing - complete details in Local Agent
    /// 6- Employeed - Local Agent
    /// 6- Backout in Foreign Agent 
    /// 
    /// </summary>
    public int StatusNo { get; set; }
    public string Status { get; set; }
}

