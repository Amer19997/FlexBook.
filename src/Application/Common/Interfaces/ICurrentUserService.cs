namespace FlexBook.Application.Common.Interfaces;

public interface ICurrentUserService
{
    string? UserId { get; }
    string? profieId { get; }
    Guid GetUserRoleId(); // Fetch the current user's Role ID (optional)

}
