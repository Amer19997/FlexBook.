using Microsoft.EntityFrameworkCore;
using Waqfi.LocalNIC.Entities;

namespace Waqfi.LocalNIC.Persistence;
public class NICDbContext : DbContext
{
    public NICDbContext(
    DbContextOptions<NICDbContext> options)
    : base(options)
    {

    }
    public DbSet<Society> Societies { get; set; } = default!;
    public DbSet<BoardChairman> BoardChairmans { get; set; } = default!;
    public DbSet<BoardMember> BoardMember { get; set; } = default!;
    public DbSet<CEO> CEOs { get; set; } = default!;
    public DbSet<Entities.Delegate> Delegates { get; set; } = default!;
    public DbSet<District> Districts { get; set; } = default!;
    public DbSet<GovernanceClassification> GovernanceClassifications { get; set; } = default!;
    public DbSet<QualitativeClassification> QualitativeClassifications { get; set; } = default!;

    public DbSet<SocialAccount> SocialAccounts { get; set; } = default!;
    public DbSet<ProviderAddress> ProviderAddresses { get; set; } = default!;
    public DbSet<ProviderContactDetails> ProviderContactDetails { get; set; } = default!;
    public DbSet<ProviderFinancialAccount> ProviderFinancialAccounts { get; set; } = default!;
    public DbSet<ProviderFile> ProviderFiles { get; set; } = default!;
    public DbSet<Region> Regions { get; set; } = default!;
    public DbSet<City> Cities { get; set; } = default!;
    public DbSet<Bank> Banks { get; set; } = default!;

    public DbSet<FirstSubclass> FirstSubclasses { get; set; } = default!;
    public DbSet<SecondSubclass> SecondSubclasses { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<ProviderAddress>().HasOne(p => p.City)
            .WithMany(p => p.ProviderAddresses)
            .HasForeignKey(p => p.CityId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.Entity<ProviderAddress>().HasOne(p => p.CityBase)
                .WithMany(p => p.ProviderAddressesBase)
                .HasForeignKey(p => p.CityBaseId)
               .OnDelete(DeleteBehavior.NoAction);

        builder.Entity<ProviderAddress>().HasOne(p => p.Region)
              .WithMany(p => p.ProviderAddresses)
              .HasForeignKey(p => p.RegionId)
             .OnDelete(DeleteBehavior.NoAction);

        builder.Entity<Society>().HasOne(p => p.SocialAccount)
        .WithOne(p => p.Society)
        .HasForeignKey<SocialAccount>(p => p.SocityId);

        builder.Entity<Bank>().OwnsOne(p => p.Name);
        builder.Entity<City>().OwnsOne(p => p.Name);
        builder.Entity<District>().OwnsOne(p => p.Name);
        builder.Entity<Region>().OwnsOne(p => p.Name);
        builder.Entity<Society>().OwnsOne(p => p.Name);
        builder.Entity<BoardChairman>().OwnsOne(p => p.MobileNumber);
        builder.Entity<BoardMember>().OwnsOne(p => p.MobileNumber);
        builder.Entity<CEO>().OwnsOne(p => p.MobileNumber);
        builder.Entity<Entities.Delegate>().OwnsOne(p => p.MobileNumber);

        builder.ApplyConfigurationsFromAssembly(GetType().Assembly);

        base.OnModelCreating(builder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }
}
