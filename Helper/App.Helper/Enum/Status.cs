namespace App.Helper.Enum { }

public enum Status
{
    Free = 0,   //HRPool Foreign Agent
    InComplete = 1, //Foreign Agent
    PostToAdmin = 2, //RootCompany
    SendToLocal = 3, //Local Agent
    Selected = 4, //Local Agent
    Processing = 5, //complete details in Local Agent
    Employeed = 6, //Local Agent
    Backout = 7,   //Foreign Agent

}

