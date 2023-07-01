using MediatR;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace App.Application.Features.UpdateRootCompany.Commands.UpdateSelectedCvMusanedData { }

public class UpdateSelectedCvMusanedDataRequest : IRequest<int>
{
    public int HRPoolId { get; set; }
    public int CVId { get; set; }
    public int ForeignId { get; set; }
    public int selectedCvId { get; set; }
    public string ModifiedById { get; set; }

    public string MusanedNumber { get; set; }
    public DateTime? ContractDate { get; set; }
}

