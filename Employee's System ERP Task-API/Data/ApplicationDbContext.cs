using EmployeeSystemERPTaskAPI.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Security.AccessControl;

namespace EmployeeSystemERPTaskAPI.Data
{
    public class ApplicationDbContext: IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<LocalUser> LocalUsers { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<LanguageLevel> LanguageLevels { get; set; }
        public DbSet<LineOfBusiness> LineOfBusinesses { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Account_LineOfBusiness> account_LineOfBusinesses { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeLangLevel> EmployeeLangLevels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account_LineOfBusiness>().HasKey(gp => new
            {
                gp.AccountId,
                gp.LineOfBusinessId
            });

            modelBuilder.Entity<Account_LineOfBusiness>().HasOne(n => n.Account).WithMany(n => n.Account_LineOfBusiness).HasForeignKey(n => n.AccountId);
            modelBuilder.Entity<Account_LineOfBusiness>().HasOne(n => n.LineOfBusiness).WithMany(n => n.Account_LineOfBusiness).HasForeignKey(n => n.LineOfBusinessId);

            modelBuilder.Entity<EmployeeLangLevel>().HasKey(gp => new
            {
                gp.EmployeeId,
                gp.LanguageLevelId
            });

            modelBuilder.Entity<EmployeeLangLevel>().HasOne(n => n.Employee).WithMany(n => n.EmployeeLangLevels).HasForeignKey(n => n.EmployeeId);
            modelBuilder.Entity<EmployeeLangLevel>().HasOne(n => n.LanguageLevel).WithMany(n => n.EmployeeLangLevels).HasForeignKey(n => n.LanguageLevelId);


            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Language>().HasData(
               new Language
               {
                   Id = 1,
                   Name = "English"
               },
               new Language
               {
                   Id = 2,
                   Name = "Italian"
               },
               new Language
               {
                   Id = 3,
                   Name = "French"
               }
               );
            modelBuilder.Entity<LanguageLevel>().HasData(
               new LanguageLevel
               {
                   Id = 1,
                   Name = "B1"
               },
               new LanguageLevel
               {
                   Id = 2,
                   Name = "B2"
               },
               new LanguageLevel
               {
                   Id = 3,
                   Name = "C1"
               }
               );
            modelBuilder.Entity<LineOfBusiness>().HasData(
               new LineOfBusiness
               {
                   Id = 1,
                   Name = "Basic"
               },
               new LineOfBusiness
               {
                   Id = 2,
                   Name = "Technical Support"
               },
               new LineOfBusiness
               {
                   Id = 3,
                   Name = "Inbound"
               }
               );
            modelBuilder.Entity<Account>().HasData(
              new Account
              {
                  Id = 1,
                  Name = "TE Data"
              },
              new Account
              {
                  Id = 2,
                  Name = "Telecom Egypt"
              }              
              );
            modelBuilder.Entity<Account_LineOfBusiness>().HasData(
             new Account_LineOfBusiness
             {
                 AccountId = 1,
                 LineOfBusinessId = 1
             },
             new Account_LineOfBusiness
             {
                 AccountId = 1,
                 LineOfBusinessId = 2
             },
              new Account_LineOfBusiness
              {
                  AccountId = 2,
                  LineOfBusinessId = 3
              }
             );
            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    Id=1,
                    Name="salah",
                    BirthDate= new DateTime(2000, 4, 23),
                    AccountId=1,
                    LanguageId=2,
                    NationalId=300054896214789,
                }
                );
            modelBuilder.Entity<EmployeeLangLevel>().HasData(
               new EmployeeLangLevel
               {
                   EmployeeId = 1,
                   LanguageLevelId = 2,
               });


        }

    }
}
