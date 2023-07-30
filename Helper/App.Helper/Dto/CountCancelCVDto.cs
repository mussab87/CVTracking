using System.Net.Mail;
using System.Net.NetworkInformation;

namespace App.Helper.Dto { }
public class CountCancelCVDto
{
    public int? RootCompanyId { get; set; }
    public int? LocalAgentId { get; set; }
    public int? ForeignAgentId { get; set; }
    public string ForeignAgentName { get; set; }
    public int? HRPoolId { get; set; }
    public int? CVId { get; set; }
    public int? SelectedId { get; set; }
    public string ApplicantName { get; set; }
    public string ApplicantPersonalImg { get; set; }
    public string CVStatus { get; set; }
    public string LocalSelectedStatus { get; set; }
    public DateTime? CancellationDateTime { get; set; }

    public string CancelledReason { get; set; }
    public string SponsorName { get; set; }
    public string SponsorContact { get; set; }
    public string SponsorVisaNumber { get; set; }
    public string SponsorDateofBirth { get; set; }
    public string SponsorIdNumber { get; set; }

}

