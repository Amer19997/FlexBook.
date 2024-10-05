using FlexBook.Domain.Repositories;

namespace FlexBook.Domain
{
    public interface IUnitOfWork : IDisposable
    {
        public IUserRepository Users { get; }
        public ICountryRepository CountryRepository { get;  }
        public IUnivesityRepository UnivesityRepository { get; }
        public IFacultyRepository FacultyRepository { get; }
        public ICouresRepository CouresRepository {  get; }
        public IDepartmentRepository DepartmentRepository { get; }
        public IInterestsListRepository InterestsListRepository { get; }
        public ITopicRepository TopicRepository { get; }

        Task<int> CommitAsync(CancellationToken cancellationToken);
    }
}
