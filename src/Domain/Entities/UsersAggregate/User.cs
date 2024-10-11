using System;
using System.Collections.Generic;
using FlexBook.Domain.Entities.LookUps;

namespace FlexBook.Domain.Entities.UsersAggregate
{
    public class User : AuditableDomainEntity<User, Guid>
    {
        // General user properties
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

        // Lookup relationships
        public int? CountryId { get; private set; }
        public Guid? UniversityId { get; private set; }
        public Guid? DepartmentId { get; private set; }
        public Guid? FacultyId { get; private set; }

        public Country Country { get; private set; }
        public University University { get; private set; }
        public Faculty Faculty { get; private set; }
        public Department Department { get; private set; }

        // Properties specific to students
        public string? AcademicYear { get; set; }    // Specific to Students
        public string? StudyLevel { get; set; }      // Specific to Students

        // Properties specific to instructors
        public Guid? SpecializationId { get; set; } // Specific to Instructors

        // Interests and relationships
        public List<UserInterstes> UserInterstesList { get; set; }
        public Guid? RoleId { get; set; }
        public Role Role { get; set; }

        // Private constructor for EF Core
        private User() { }

        // Full parameter constructor for creating new instances
        public User(Guid id, string firstName, string lastName, string mobileNumber, string email, DateTimeOffset registerAt, UserStatus status, int countryId, Guid? universityId, Guid? facultyId, Guid? departmentId, UserTypeEnum userType, string password)
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

            // Initialize student or instructor specific properties
            if (userType == UserTypeEnum.Student)
            {
                AcademicYear = null;
                StudyLevel = null;
            }
            else if (userType == UserTypeEnum.Instructor)
            {
                SpecializationId = null;
            }
        }

        // Static factory method to initialize a new user
        public static User Init(string firstName, string lastName, string mobileNumber, string email, int countryId, Guid? universityId, Guid? facultyId, Guid? departmentId, UserTypeEnum userType, string password)
        {
            return new User(Guid.NewGuid(), firstName, lastName, mobileNumber, email, DateTimeOffset.Now, UserStatus.Pending, countryId, universityId, facultyId, departmentId, userType, password);
        }

        // Method to update the user's status and look-up statuses
        public User UpdateUserStatus(UserStatus userStatus, LookUpStatus? lookUpStatus)
        {
            this.Status = userStatus;

            if (this.University != null)
                this.University.LookUpStatus = lookUpStatus ?? LookUpStatus.Pending;
            if (this.Faculty != null)
                this.Faculty.LookUpStatus = lookUpStatus ?? LookUpStatus.Pending;
            if (this.Department != null)
                this.Department.LookUpStatus = lookUpStatus ?? LookUpStatus.Pending;

            return this;
        }

        // Method to update the last modified status timestamp
        public User UpdateLastModifyStatus(DateTime lastModify)
        {
            this.LastModifiedStatus = lastModify;
            return this;
        }

        // Method to update user's basic information
        public User UpdateUser(string firstName, string lastName, string mobileNumber, string email, DateTime? lastModifiedStatus)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.MobileNumber = string.IsNullOrEmpty(mobileNumber) ? string.Empty : mobileNumber;
            this.Email = email;
            this.LastModifiedStatus = lastModifiedStatus;
            return this;
        }

        // Method to update the user's password
        public User UpdateUserPassword(string password, bool updateStatus)
        {
            this.Password = password;

            if (updateStatus && this.Status != UserStatus.Active)
                this.Status = UserStatus.Active;

            return this;
        }

        // Method to update academic information (for students)
        public User UpdateStudentAcademicInfo(string academicYear, string studyLevel)
        {
            if (this.UserType != UserTypeEnum.Student)
                throw new InvalidOperationException("Only students can have academic information.");

            this.AcademicYear = academicYear;
            this.StudyLevel = studyLevel;
            return this;
        }

        // Method to update specialization information (for instructors)
        public User UpdateInstructorSpecialization(Guid specializationId)
        {
            if (this.UserType != UserTypeEnum.Instructor)
                throw new InvalidOperationException("Only instructors can have specialization information.");

            this.SpecializationId = specializationId;
            return this;
        }
    }
}
