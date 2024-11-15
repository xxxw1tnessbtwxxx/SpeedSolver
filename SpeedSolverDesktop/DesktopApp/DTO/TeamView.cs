namespace DesktopApp.DTO;

public class TeamView
{
    public string TeamName { get; set; }
    public bool isModerator { get; set; } = false;
    public int MemberCount { get; set; } = 0;
}