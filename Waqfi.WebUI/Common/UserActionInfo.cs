namespace WebUI.Common;

public record UserActionInfo
{
    public Guid UserId { get; set; }
    public string Name { get; set; }
    public bool IsActive { get; set; }
    public List<string> Roles { get; set; }
    public string Token { get; set; }


}
