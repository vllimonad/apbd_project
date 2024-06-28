using Microsoft.EntityFrameworkCore;
using project.Models;
using Version = project.Models.Version;

namespace project.Data;

public class ApplicationContext: DbContext
{
    protected ApplicationContext()
    {
    }

    public ApplicationContext(DbContextOptions options) : base(options)
    {
    }
    
    public DbSet<Company> Companies { get; set; }
    public DbSet<Individual> Individuals { get; set; }
    public DbSet<Contract> Contracts { get; set; }
    public DbSet<Discount> Discounts { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Software> Softwares { get; set; }
    public DbSet<Version> Versions { get; set; }
    public DbSet<Employee> Employees { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<Company>().HasData(new List<Company>()
        {
            new() { Id = 1, Address = "Warsaw", PhoneNumber = "+82374982347", Email = "iunce@gamil.com", Name = "Company1", KRS = 128374493},
            new() { Id = 2, Address = "Gdansk", PhoneNumber = "+29479124984", Email = "83hdkjfr@gamil.com", Name = "Company2", KRS = 2849750727},
            new() { Id = 3, Address = "Berlin", PhoneNumber = "+28739418645", Email = "aoucn2@gamil.com", Name = "Company2", KRS = 259824905}
        });
        
        modelBuilder.Entity<Individual>().HasData(new List<Individual>()
        {
            new() { Id = 1, Address = "Rome", PhoneNumber = "+29840928565", Email = "iuwnb4f84b@gamil.com", FirstName = "name1", LastName = "surname1", PESEL = 29748384850},
            new() { Id = 2, Address = "London", PhoneNumber = "+39482209755", Email = "aibd7662@gamil.com", FirstName = "name2", LastName = "surname2", PESEL = 98347598375},
            new() { Id = 3, Address = "Vienna", PhoneNumber = "+98246950593", Email = "blvne784@gamil.com", FirstName = "name3", LastName = "surname3", PESEL = 92480370580}
        });
        
        modelBuilder.Entity<Discount>().HasData(new List<Discount>()
        {
            new() { Id = 1, Name = "Black Friday Discount", Value = 10, StartTime = DateTime.Today, EndTime = DateTime.Parse("2024-09-09")},
            new() { Id = 2, Name = "New Year Discount", Value = 15, StartTime = DateTime.Today, EndTime = DateTime.Parse("2024-12-23")},
            new() { Id = 3, Name = "Summer Discount", Value = 30, StartTime = DateTime.Today, EndTime = DateTime.Parse("2024-11-01")},
        });
        
        modelBuilder.Entity<Software>().HasData(new List<Software>()
        {
            new() { Id = 1, Name = "Software1", Category = "education", Description = "b b b b"},
            new() { Id = 2, Name = "Software2", Category = "science", Description = "a a a a"},
            new() { Id = 3, Name = "Software3", Category = "finances", Description = "c c c c"},
        });
        
        modelBuilder.Entity<Version>().HasData(new List<Version>()
        {
            new() { Id = 1, Name = "Version1", SoftwareId = 1},
            new() { Id = 2, Name = "Version2", SoftwareId = 1},
            new() { Id = 3, Name = "Version3", SoftwareId = 2},
            new() { Id = 4, Name = "Version4", SoftwareId = 3},
        });
        
        modelBuilder.Entity<Contract>().HasData(new List<Contract>()
        {
            new() { Id = 1, ClientId = 1, SoftwareId = 1, Price = 28497, Version = "first", IsSigned = false, StartDate = DateTime.Now, EndDate = DateTime.Parse("2024-07-07"), ClientType = ClientType.Company},
            new() { Id = 2, ClientId = 2, SoftwareId = 2, Price = 8575, Version = "first", IsSigned = false, StartDate = DateTime.Now, EndDate = DateTime.Parse("2024-07-07"), ClientType = ClientType.Company},
        });
        
        modelBuilder.Entity<Payment>().HasData(new List<Payment>()
        {
            new() { Id = 1, ContractId = 1, Amount = 8273, Date = DateTime.Parse("2024-07-01")},
            new() { Id = 2, ContractId = 1, Amount = 10394, Date = DateTime.Parse("2024-07-02")},
            new() { Id = 3, ContractId = 1, Amount = 2397, Date = DateTime.Parse("2024-07-03")},
            new() { Id = 4, ContractId = 2, Amount = 8575, Date = DateTime.Parse("2024-07-01")},
        });
    }
}