using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlexBook.Domain.Entities.LookUps;

namespace FlexBook.Domain.Repositories;
public interface ICountryRepository:IRepository<Country>{}

public interface IUnivesityRepository : IRepository<University> 
{
    Task<Guid> AddAsync(University university);
}

public interface IDepartmentRepository : IRepository<Department> 
{
    Task<Guid> AddAsync(Department department);
}