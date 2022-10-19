
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SYS.Domain.Entities;
using SYS.Domain.Entities.Identity;

namespace SYSAPP.Persistence.Contexts;

public class SYSAPPDBContext: IdentityDbContext<AppUser, AppRole, string>
{
    public SYSAPPDBContext(DbContextOptions<SYSAPPDBContext> options) : base(options)
    { }

    public DbSet<Home> Homes { get; set; }
    public DbSet<Owner> Owners { get; set; }
    public DbSet<Dept> Depties { get; set; }
    public DbSet<Dues> Dues { get; set; }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Home>()
            .HasKey(b => b.Id);

        base.OnModelCreating(builder);
    }
    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        //ChangeTracker : Entityler üzerinden yapılan değişiklerin ya da yeni eklenen verinin yakalanmasını sağlayan propertydir. Update operasyonlarında Track edilen verileri yakalayıp elde etmemizi sağlar.

        var datas = ChangeTracker
            .Entries<BaseEntity>();

        foreach (var data in datas)
        {
            _ = data.State switch
            {
                EntityState.Added => data.Entity.CreatedDate = DateTime.UtcNow,
                EntityState.Modified => data.Entity.UpdatedDate = DateTime.UtcNow,
                _ => DateTime.UtcNow
            };
        }

        return await base.SaveChangesAsync(cancellationToken);
    }
}