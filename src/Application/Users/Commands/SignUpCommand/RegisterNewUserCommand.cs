using MediatR;
using FlexBook.Application.Common.Models;

namespace FlexBook.Application.Users.Commands.SignUpCommand;
public class RegisterNewUserCommand :IRequest<TResponse<RegisterNewUserResult>>
{
    public string Email { get; set; }
    public string FirstName {  get; set; }
    public string LastName { get; set; }
    public string MobileNumber {  get; set; }
    public string Password { get; set; }
    public string VerifayPassword {  get; set; }
    public int CountryId {  get; set; }
    public Guid? UniversityId {  get; set; }
    public string UniversityName {  get; set; }
    public Guid? FacultyId {  get; set; }
    public string FacultyName { get; set; }
    public Guid? DepartmentId {  get; set; }
    public string DepartmentName { get; set; }
    public string Note { get; set; }
    public int UserType {  get; set; }
    public List<Guid> InterstesListId { get; set; }
}
