using MediatR;
using System.ComponentModel.DataAnnotations;

namespace App.Application.Features.UserRootCompany.Commands.AddUserToRootCompany { }

public class AddUserToRootCompanyRequest : IRequest<int>
{
    public string? ApplicationUserId { get; set; }
    [Display(Name = "Root Company")]
    public int RootCompanyId { get; set; }

    public ApplicationUser applicationUser { get; set; }
}

