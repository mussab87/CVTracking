
namespace App.Helper.Dto { }
public class UserAgentDto
{
    public UserAgentDto()
    {
        usersAgents = new List<UserAgent>();
    }

    public int foreignAgentId { get; set; }
    public List<UserAgent> usersAgents { get; set; }
}

