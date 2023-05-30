
namespace App.Domain.Entities { }

public class SelectedCv : EntityBase
{
    public LocalAgent LocalAgent { get; set; }
    public HRPool HRPoolID { get; set; }
    /// <summary>
    /// Selected - unless he make unselect the remove from SelectedCv
    /// 5 working days form selection date after that it will be return back into HRPool with status of free
    /// </summary>
    public CVStatus LocalAgentStatus { get; set; }
    public DateTime SelectedDateTime { get; set; }


    public string SponsorName { get; set; }
    public string SponsorIdNumber { get; set; }
    public string VisaNumber { get; set; }
    public string SponsorContact { get; set; }

    /// <summary>
    /// after entering sponsor details it will be moved into Admin RootCompany for confirmation befor appear to ForeignAgent
    /// 0- pending confirmation
    /// 1- confirmed
    /// </summary>
    public bool RootAdminCompanyConfirmation { get; set; }
}

