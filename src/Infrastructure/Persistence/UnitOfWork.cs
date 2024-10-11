using FlexBook.Domain;
using FlexBook.Domain.Repositories;
using FlexBook.Infrastructure.Persistence.Repositories;

namespace FlexBook.Infrastructure.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FlexBookDbContext FlexBookDbContext;

        public IUserRepository Users { get; }
        public ICountryRepository CountryRepository { get; set; }
        public IUnivesityRepository UnivesityRepository { get; set; }
        public IDepartmentRepository DepartmentRepository { get; set; }
        public IFacultyRepository FacultyRepository { get; set; }
        public ICouresRepository CouresRepository { get; set; }
        public IInterestsListRepository InterestsListRepository { get; set; }
        public ITopicRepository TopicRepository { get; set; }
        public RoleRepositoryInterface RoleRepository { get; set; }  // This fixes the missing property

        private bool _disposed = false;

        public UnitOfWork(FlexBookDbContext _context,
                          IUserRepository users,
                          ICountryRepository countryRepository,
                          IUnivesityRepository univesityRepository,
                          IFacultyRepository facultyRepository,
                          IDepartmentRepository departmentRepository,
                          ICouresRepository couresRepository,
                          ITopicRepository topicrepository,
                          IInterestsListRepository interestsListRepository,
                          RoleRepositoryInterface roleRepository
                          )
        {
            FlexBookDbContext = _context;
            Users = users;
            CountryRepository = countryRepository;
            UnivesityRepository = univesityRepository;
            DepartmentRepository = departmentRepository;
            FacultyRepository = facultyRepository;
            CouresRepository = couresRepository;
            InterestsListRepository = interestsListRepository;
            TopicRepository = topicrepository;
            RoleRepository = roleRepository;  // Assign the RoleRepository correctly
        }

        public async Task<int> CommitAsync(CancellationToken cancellationToken)
        {
            if (_disposed)
            {
                throw new ObjectDisposedException(this.GetType().FullName);
            }

            return await FlexBookDbContext.SaveChangesAsync(cancellationToken);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) return;

            if (disposing && FlexBookDbContext != null)
            {
                FlexBookDbContext.Dispose();
            }

            _disposed = true;
        }
    }
}
