using MediatR;
using Microsoft.EntityFrameworkCore;
using FlexBook.Domain.Entities;
using FlexBook.Domain.Entities.LookUps;
using FlexBook.Domain.Entities.UsersAggregate;
using FlexBook.Infrastructure.Persistence.Interceptors;

namespace FlexBook.Infrastructure.Persistence;
public class FlexBookDbContext : DbContext
{
    private readonly IMediator _mediator;
    private readonly AuditableEntitySaveChangesInterceptor _auditableEntitySaveChangesInterceptor;

    public FlexBookDbContext(
        DbContextOptions<FlexBookDbContext> options,
        AuditableEntitySaveChangesInterceptor auditableEntitySaveChangesInterceptor)
        : base(options)
    {
        _auditableEntitySaveChangesInterceptor = auditableEntitySaveChangesInterceptor;
       
    }

    public DbSet<User> Users { get; set; } = default!;
    public DbSet<Country> Country { get; set; } = default!;
    public DbSet<University> University { get; set; } = default!;
    public DbSet<Faculty> Faculty { get; set; } = default!;
    public DbSet<Department> Department { get; set; } = default!;
    public DbSet<Course> Courses { get; set; } = default!;
    public DbSet<InterestsList> InterestsList { get; set; } = default!;
    public DbSet<UserInterstes> UserInterstes { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        base.OnModelCreating(builder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(_auditableEntitySaveChangesInterceptor);
    }

   
}
