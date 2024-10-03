using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using FlexBook.Application.Common.Helpers;
using FlexBook.Application.Common.Interfaces;
using FlexBook.Domain.Common;
using FlexBook.Domain.Entities.UsersAggregate;
using FlexBook.Domain.Enums;
using FlexBook.Domain.Repositories;

namespace FlexBook.Infrastructure.Persistence.Repositories;
public class UserRepository : Repository<User>, IUserRepository
{
    private readonly FlexBookDbContext _context;
    private readonly ICurrentUserService _currentUserService;
    private readonly AppSettings _appSettings;
    private readonly IAccountService _accountService;
    public UserRepository(FlexBookDbContext dbContext, ICurrentUserService currentUserService , IOptions<AppSettings> appSettings, IAccountService accountService) : base(dbContext)
    {
        _context = dbContext;
        _currentUserService = currentUserService;
        _appSettings = appSettings.Value;
        _accountService = accountService;
    }


    public async Task<IEnumerable<User>> GetSignUpRequests(int skip, int take)
        =>await _context.Users.Where(m => m.Status == UserStatus.Pending)
                              .OrderBy(m=>m.Created)
                              .Include(m=>m.Country)
                              .Include(m=>m.University)
                              .Include(m => m.Faculty)
                              .Include(m => m.Department)
                              .Skip(((skip - 1) * take))
                              .Take(take)
                              .ToListAsync() ;
  

    public async Task<bool> CheckEmailExist(string email, Guid? userId)
    {
        return await _context.Users.AnyAsync(a => a.Email == email && (a.Id==userId || userId==null));
    }
     

    public void  UpdateUser(User Model)
    => _context.Users.Update(Model);


    public async Task<bool> CheckIfExistUser()
    => await _context.Users.AnyAsync();

    
    public async Task<User?> GetUser(string email, string password)
        => await _context.Users.Where(x => x.Email == email && x.Password == password && x.Status==UserStatus.Active).FirstOrDefaultAsync();

    public async Task<bool> CheckEmailIsFound(string email)
        => await _context.Users.AnyAsync(x => x.Email == email);

    public async Task<User?> GetActiveUserByEmail(string email)
        => await _context.Users.FirstOrDefaultAsync(x => x.Email == email && (x.Status == UserStatus.Active));

    public async Task<User?> GetUserByEmail(string email)
        => await _context.Users.FirstOrDefaultAsync(x => x.Email == email && (x.Status == UserStatus.Active || x.Status == UserStatus.Pending));

    public async Task<User?> GetUserAndHisRolesByEmail(string email)
        => await _context.Users.Where(x => x.Email == email && x.Status == UserStatus.Active).FirstOrDefaultAsync();

    
    
}
