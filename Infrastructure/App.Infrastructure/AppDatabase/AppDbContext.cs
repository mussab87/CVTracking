using EllipticCurve.Utils;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure.AppDatabase { }

public class AppDbContext : AuditIdentityDbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<RootCompanyUsers>().HasKey(sc => new { sc.ApplicationUserId, sc.RootCompanyId });
        modelBuilder.Entity<RootCompanyForeignAgent>().HasKey(sc => new { sc.RootCompanyId, sc.ForeignAgentId });
        modelBuilder.Entity<RootCompanyLocalAgent>().HasKey(sc => new { sc.RootCompanyId, sc.LocalAgentId });
        modelBuilder.Entity<CVAttachment>().HasKey(sc => new { sc.CVId, sc.AttachmentId });

        //change AspNet Users tables names
        var entityTypes = modelBuilder.Model.GetEntityTypes();
        foreach (var entityType in entityTypes)
            modelBuilder.Entity(entityType.ClrType)
                   .ToTable(entityType.GetTableName().Replace("AspNet", ""));
    }

    public DbSet<UserPassword> UserPassword { get; set; }
    public DbSet<UserTransaction> UserTransaction { get; set; }

    public DbSet<AttachmentType> AttachmentTypes { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<CV> CVs { get; set; }
    public DbSet<CVAttachment> CVAttachments { get; set; }
    public DbSet<Attachment> Attachments { get; set; }
    public DbSet<CVStatus> CVStatuses { get; set; }
    public DbSet<ForeignAgent> ForeignAgents { get; set; }
    public DbSet<HRPool> HRPools { get; set; }
    public DbSet<LocalAgent> LocalAgents { get; set; }
    public DbSet<PreviousEmployment> PreviousEmployments { get; set; }
    public DbSet<RootCompany> RootCompanies { get; set; }
    public DbSet<RootCompanyForeignAgent> RootCompanyForeignAgents { get; set; }
    public DbSet<RootCompanyLocalAgent> RootCompanyLocalAgents { get; set; }
    public DbSet<RootCompanyUsers> RootCompanyUsers { get; set; }
    public DbSet<SelectedCv> SelectedCvs { get; set; }
}

