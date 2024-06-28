using cleanwave_platform.Accounts;
using cleanwave_platform.Profiles.Domain.Model.Aggregates;
using cleanwave_platform.Shared.Infraestructure.Persistence.EFC.Configuration.Extensions;
using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;

namespace cleanwave_platform.Shared.Infraestructure.Persistence.EFC.Configuration;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        base.OnConfiguring(builder);
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
        
        //Profiles Context
        builder.Entity<Customer>().HasKey(c => c.Id);
        builder.Entity<Customer>().Property(c => c.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Customer>().Property(c => c.Name).IsRequired().HasColumnName("Name");
        builder.Entity<Customer>().Property(c => c.LastName).IsRequired().HasColumnName("LastName");
        builder.Entity<Customer>().Property(c => c.Email).IsRequired().HasColumnName("Email");
        builder.Entity<Customer>().Property(c => c.Phone).IsRequired().HasColumnName("Phone");
        builder.Entity<Customer>().OwnsOne(c => c.Space, s =>
        {
            s.WithOwner().HasForeignKey("Id");
            s.Property(p => p.PropertyType).HasColumnName("PropertyType");
            s.Property(p => p.CleaningType).HasColumnName("CleaningType");
            s.Property(p => p.SpaceSize).HasColumnName("SpaceSize");
            s.Property(p => p.NumberRooms).HasColumnName("NumberRooms");
            s.Property(p => p.FloorType).HasColumnName("FloorType");
            s.Property(p => p.Instructions).HasColumnName("Instructions");
        });
        
        //Cleaning Entrepreneur Context
        builder.Entity<CleaningEntrepreneur>().HasKey(c => c.Id);
        builder.Entity<CleaningEntrepreneur>().Property(c => c.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<CleaningEntrepreneur>().Property(c => c.Name).IsRequired().HasColumnName("Name");
        builder.Entity<CleaningEntrepreneur>().Property(c => c.Email).IsRequired().HasColumnName("Email");
        builder.Entity<CleaningEntrepreneur>().Property(c => c.Username).IsRequired().HasColumnName("Username");

        //Apply SnakeCase Naming Convention
        builder.UseSnakeCaseWithPluralizedTableNamingConvention();
    }
}