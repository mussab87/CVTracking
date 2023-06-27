
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Domain.Entities { }

public class SelectedCv : EntityBase
{
    public int LocalAgentId { get; set; }
    [ForeignKey("LocalAgentId")]
    public LocalAgent LocalAgent { get; set; }

    public int HRPoolId { get; set; }
    [ForeignKey("HRPoolId")]
    public HRPool HRPool { get; set; }

    /// <summary>
    /// Selected - unless he make unselect the remove from SelectedCv
    /// 5 working days form selection date after that it will be return back into HRPool with status of free
    /// </summary>
    public int LocalAgentStatusId { get; set; }
    [ForeignKey("LocalAgentStatusId")]
    public CVStatus LocalAgentStatus { get; set; }
    public DateTime SelectedDateTime { get; set; }


    public string SponsorName { get; set; }
    public string SponsorIdNumber { get; set; }
    public string VisaNumber { get; set; }
    public string SponsorContact { get; set; }
    public DateTime? SponsorDateOfBirth { get; set; }

    /// <summary>
    /// after entering sponsor details it will be moved into Admin RootCompany for confirmation befor appear to ForeignAgent
    /// 0- pending confirmation
    /// 1- confirmed
    /// </summary>
    public bool RootAdminCompanyConfirmation { get; set; }
}

