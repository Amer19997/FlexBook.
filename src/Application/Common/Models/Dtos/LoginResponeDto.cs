namespace FlexBook.Application.Common.Models.Dtos;
public class LoginResponeDto
{
    public string Token { get; set; }
    public Guid Id { get; set; }
    public string Name { get; set; }
    public bool IsSuperAdmin { get; set; }
}
