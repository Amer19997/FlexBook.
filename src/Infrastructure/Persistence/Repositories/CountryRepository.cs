using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using FlexBook.Application.Common.Helpers;
using FlexBook.Domain.Entities.LookUps;
using FlexBook.Domain.Repositories;

namespace FlexBook.Infrastructure.Persistence.Repositories;
public class CountryRepository : Repository<Country>, ICountryRepository
{
    public CountryRepository(FlexBookDbContext dbContext, IOptions<AppSettings> appSettings) : base(dbContext)
    {

    }
}


public class UnivesityRepository : Repository<University>, IUnivesityRepository
{
    private readonly FlexBookDbContext _context;
    public UnivesityRepository(FlexBookDbContext dbContext) : base(dbContext)
    {
        _context = dbContext;
    }
    public async Task<Guid> AddAsync(University university)
    {
        await _context.AddAsync(university);
        return university.Id;
    }

}

public class DepartmentRepository : Repository<Department>, IDepartmentRepository
{
    
    private readonly FlexBookDbContext _context;
    public DepartmentRepository(FlexBookDbContext dbContext) : base(dbContext)
    {
        _context = dbContext;
    }
    public async Task<Guid> AddAsync(Department department)
    {
        await _context.AddAsync(department);
        return department.Id;
    }
}
