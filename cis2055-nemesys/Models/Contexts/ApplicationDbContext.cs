using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace Nemesys.Models.Contexts
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser, IdentityRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            // Constructor passes options to base DbContext
        }

        // DbSet for Near Miss Report entity
        public DbSet<NearMissReport> NearMissReports { get; set; }


        // DbSet for Investigation entity
        public DbSet<Investigation> Investigations { get; set; }
        public object Reports { get; internal set; }

        // Override OnModelCreating to configure data seeding
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure seeding for Identity roles
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = "d234f58e-7373-4ee5-98f0-c17892784b05",
                    Name = "Admin",
                    ConcurrencyStamp = "1",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole
                {
                    Id = "1db56103-a3e2-4edc-afab-abde856cebe0",
                    Name = "User",
                    ConcurrencyStamp = "1",
                    NormalizedName = "USER"
                }
            );
            modelBuilder.Entity<Investigation>()
             .HasOne(i => i.NearMissReport)
             .WithMany(n => n.Investigations)
             .HasForeignKey(i => i.NearMissReportId)
             .OnDelete(DeleteBehavior.Cascade);

            // Seed admin user
            IdentityUser adminUser = new IdentityUser
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "admin@mail.com",
                NormalizedUserName = "ADMIN@MAIL.COM",
                Email = "admin@mail.com",
                NormalizedEmail = "ADMIN@MAIL.COM",
                LockoutEnabled = false,
                EmailConfirmed = true,
                PhoneNumber = ""
            };

            PasswordHasher<IdentityUser> passwordHasher = new PasswordHasher<IdentityUser>();
            adminUser.PasswordHash = passwordHasher.HashPassword(adminUser, "S@fePassw0rd1"); // Hash the password

            modelBuilder.Entity<IdentityUser>().HasData(adminUser);

            // Assign admin user to the "Admin" role
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "d234f58e-7373-4ee5-98f0-c17892784b05", // Admin role ID
                    UserId = adminUser.Id // Admin user ID
                }
            );

            // Configure seeding for Near Miss Report entities
            modelBuilder.Entity<NearMissReport>().HasData(
                new NearMissReport
                {
                    Id = 1,
                    Title = "Example Title",
                    DateOfReport = DateTime.UtcNow,
                    Location = "Example Location",
                    DateAndTimeSpotted = DateTime.UtcNow,
                    TypeOfHazard = "UnsafeAct",
                    Description = "Example Description",
                    Status = "Open",
                    ReporterEmail = "example@email.com",
                    ReporterPhone = "123-456-7890", // Example phone number
                    OptionalPhoto = "/images/seed2.jpg", // Example file path
                    Upvotes = 0, // Initial upvotes
                    UserId = "d234f58e-7373-4ee5-98f0-c17892784b05"
                }
                // Additional Near Miss Reports...
            );

            // Configure seeding for Investigation entities
            modelBuilder.Entity<Investigation>().HasData(
                new Investigation
                {
                    Id = 1,
                    NearMissReportId = 1, // Corresponds to the Near Miss Report above
                    Description = "Example Investigation Description",
                    DateOfAction = DateTime.UtcNow,
                    InvestigatorEmail = "investigator@email.com",
                    InvestigatorPhone = "987-654-3210",
                    
                  
                    // Additional properties...
                }
            );
        }
    }
}
