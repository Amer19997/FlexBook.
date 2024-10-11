using MediatR;
using Microsoft.EntityFrameworkCore;
using FlexBook.Domain.Entities;
using FlexBook.Domain.Entities.LookUps;
using FlexBook.Domain.Entities.UsersAggregate;
using FlexBook.Infrastructure.Persistence.Interceptors;
using FlexBook.Domain.Entities.Catalog;
using System.Reflection.Emit;
using FlexBook.Domain.Entities.Authorization;
using Microsoft.Extensions.Configuration;

namespace FlexBook.Infrastructure.Persistence;
public class FlexBookDbContext : DbContext
{
    private readonly IConfiguration _configuration;

    private readonly IMediator _mediator;
    private readonly AuditableEntitySaveChangesInterceptor _auditableEntitySaveChangesInterceptor;

    public FlexBookDbContext(
        IConfiguration configuration,
        DbContextOptions<FlexBookDbContext> options,
        AuditableEntitySaveChangesInterceptor auditableEntitySaveChangesInterceptor)
        : base(options)
    {
        _auditableEntitySaveChangesInterceptor = auditableEntitySaveChangesInterceptor;
        _configuration = configuration;


    }

    public DbSet<User> Users { get; set; } = default!;
    public DbSet<Country> Country { get; set; } = default!;
    public DbSet<University> University { get; set; } = default!;
    public DbSet<Faculty> Faculty { get; set; } = default!;
    public DbSet<Department> Department { get; set; } = default!;
    public DbSet<Course> Courses { get; set; } = default!;
    public DbSet<InterestsList> InterestsList { get; set; } = default!;
    public DbSet<UserInterstes> UserInterstes { get; set; } = default!;
    public DbSet<Section> Sections { get; set; }
    public DbSet<Lesson> Lessons { get; set; }
    public DbSet<Topic> Topics { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Permission> Permissions { get; set; }
    public DbSet<RolePermission> RolePermissions { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        base.OnModelCreating(builder);
        //// User -> Role (many-to-one relationship)
        //builder.Entity<User>()
        //    .HasOne(u => u.Role)
        //    .WithMany(r => r.Users)
        //    .HasForeignKey(u => u.RoleId)
        //    .OnDelete(DeleteBehavior.Restrict);

        //// RolePermission -> Role (many-to-one relationship)
        //builder.Entity<RolePermission>()
        //    .HasOne(rp => rp.Role)
        //    .WithMany(r => r.RolePermissions)
        //    .HasForeignKey(rp => rp.RoleId);

        //// RolePermission -> Permission (many-to-one relationship)
        //builder.Entity<RolePermission>()
        //    .HasOne(rp => rp.Permission)
        //    .WithMany(p => p.RolePermissions)
        //    .HasForeignKey(rp => rp.PermissionId);

        //// Composite key for RolePermission (RoleId, PermissionId)
        //builder.Entity<RolePermission>()
        //    .HasKey(rp => new { rp.RoleId, rp.PermissionId });
        // Pass the configuration to the DataSeeder
        DataSeeder.Seed(builder, _configuration);

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(_auditableEntitySaveChangesInterceptor);
 
    }


}
