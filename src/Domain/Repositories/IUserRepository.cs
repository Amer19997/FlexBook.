using FlexBook.Domain.Entities.UsersAggregate;

namespace FlexBook.Domain.Repositories;
public interface IUserRepository : IRepository<User>
{
    Task<IEnumerable<User>> GetSignUpRequests(int skip, int take);
  
    Task<bool> CheckEmailExist(string email,Guid? userId);

    Task<bool> CheckIfExistUser();
    void UpdateUser(User Model);
    Task<User?> GetUser(string email, string password);
    
    Task<User?> GetActiveUserByEmail(string email);
    Task<User?> GetUserByEmail(string email);
    Task<User?> GetUserAndHisRolesByEmail(string email);
    Task<bool> CheckEmailIsFound(string email);
    // New method to get user by email or name
    Task<User?> GetUserByEmailOrNameAsync(string emailOrName);
}
