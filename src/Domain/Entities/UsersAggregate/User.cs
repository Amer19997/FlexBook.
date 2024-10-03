using FlexBook.Domain.Entities.LookUps;

namespace FlexBook.Domain.Entities.UsersAggregate;
public class User : AuditableDomainEntity<User, Guid>
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string MobileNumber { get; private set; }
    public string Email { get; private set; }
    public DateTime? LastModifiedStatus { get; set; }
    public DateTimeOffset RegisterAt { get; private set; }
    public UserStatus Status { get; private set; }
    public string Password { get; private set; }
    public bool IsSuperAdmin { get; private set; }
    public UserTypeEnum UserType { get; private set; }
    public int? CountryId { get; private set; }
    public Guid? UniversityId { get; private set; }
    public Guid? DepartmentId { get; private set; }
    public Guid? FacultyId { get; private set; }


    public Country Country { get; private set; }
    public University University { get; private set; }
    public Faculty Faculty { get; private set; }
    public Department Department { get; private set; }

    
    public List<UserInterstes> UserInterstesList { get; set; }
    private User()
    {

    }

    private User(Guid id, string firstName, string lastName, string mobileNumber, string email, DateTimeOffset registerAt, UserStatus status, int countryId, Guid? universityId, Guid? facultyId, Guid? departmentId, UserTypeEnum userType,string password)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        RegisterAt = registerAt;
        Status = status;
        MobileNumber = mobileNumber;
        Created = DateTime.Now;
        CountryId = countryId;
        UniversityId = universityId;
        FacultyId = facultyId;
        DepartmentId = departmentId;
        UserType = userType;
        Password = password;
    }

    public static User Init(string firstName, string lastName, string mobileNumber, string email, int countryId, Guid? universityId, Guid? facultyId, Guid? departmentId, UserTypeEnum userType,string password)
    => new User(Guid.NewGuid(), firstName, lastName, mobileNumber, email, DateTimeOffset.Now, UserStatus.Pending, countryId, universityId, facultyId, departmentId, userType, password);

    public User UpdateUserStatus(UserStatus userStatus, LookUpStatus? lookUpStatus)
    {
        this.Status = userStatus;
        this.University.LookUpStatus = lookUpStatus ?? LookUpStatus.Pending;
        this.Faculty.LookUpStatus = lookUpStatus ?? LookUpStatus.Pending;
        this.Department.LookUpStatus = lookUpStatus ?? LookUpStatus.Pending;

        return this;
    }

    public User UpdateLastModifyStatusStatus(DateTime LastModify)
    {
        this.LastModifiedStatus = LastModify;
        return this;
    }

    public User UpdateUser(string firstname, string lastName, string countryCode, string mobileNumber, string email, DateTime? LastModiStatus)
    {
        this.FirstName = FirstName;
        this.LastName = lastName;
        this.MobileNumber = string.IsNullOrEmpty(mobileNumber) ? string.Empty : mobileNumber;
        this.Email = email;
        this.LastModifiedStatus = LastModiStatus;
        return this;
    }


    public User UpdateUserPassword(string password, bool status)
    {
        if (!status)
            this.Status = UserStatus.Active;

        this.Password = password;
        return this;
    }
}
