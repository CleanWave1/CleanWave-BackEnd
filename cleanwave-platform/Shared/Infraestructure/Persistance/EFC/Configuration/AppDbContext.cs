using cleanwave_platform.Accounts;
using cleanwave_platform.iam.Domain.Model.Aggregates;
using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;

namespace cleanwave_platform.Shared.Infraestructure.Persistance.EFC.Configuration;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        base.OnConfiguring(builder);
        //Enable Audit Fields Interceptors
        builder.AddCreatedUpdatedInterceptor();
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        //Account Context
        builder.Entity<Account>().HasKey(a => a.Id);
        builder.Entity<Account>().Property(a => a.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Account>().OwnsOne(a => a.PersonSuscription, s =>
        {
            s.WithOwner().HasForeignKey("Id");
            s.Property(p => p.TypeSuscription).HasColumnName("TypeSuscription");
            s.Property(p => p.Price).HasColumnName("Price");
        });
        builder.Entity<Account>().OwnsOne(a => a.Name, s =>
        {
            s.WithOwner().HasForeignKey("Id");
            s.Property(p => p.Name).HasColumnName("Name");
            s.Property(p => p.LastName).HasColumnName("LastName");
        });
        builder.Entity<Account>().OwnsOne(a => a.Email, s =>
        {
            s.WithOwner().HasForeignKey("Id");
            s.Property(p => p.Email).HasColumnName("Email");
        });
        builder.Entity<Account>().Property(a => a.Password).IsRequired().HasColumnName("Password");
        builder.Entity<Account>().Property(a => a.TypeAccount).IsRequired().HasColumnName("TypeAccount");
        builder.Entity<Account>().Property(a => a.Phone).HasColumnName("Phone");
        
        //iam context
        builder.Entity<User>().HasKey(u => u.Id);
        builder.Entity<User>().Property(u => u.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<User>().Property(u => u.Username).IsRequired();
        builder.Entity<User>().Property(u => u.PasswordHash).IsRequired();
    }
    
}