using AMI.EduWork.Data;
using AMI.EduWork.Domain;
using AMI.EduWork.Domain.Entities;
using AMI.EduWork.Domain.Helpers;
using Microsoft.AspNetCore.Identity;

namespace AMI.EduWork._2025.Data.Migrations
{
    public class DataSeeder
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DataSeeder(ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        Random random = new Random();
        string[] projectNames = new[] { "Apollo", "Orion", "Zenith", "Nova", "Quantum", "Atlas" };
        string[] descriptions = new[] {
            "Optimizing system performance.",
            "Developing next-gen features.",
            "Research and innovation phase.",
            "Team collaboration ongoing.",
            "Bug fixing and patching.",
            "Client delivery preparations."
        };

        public async Task SeedData()
        {
            await SeedRoles();
            await SeedUser();
            await SeedAdmin();
            await _context.SaveChangesAsync();
        }

        private async Task SeedRoles()
        {
            if (!await _roleManager.RoleExistsAsync("Admin"))
            {
                await _roleManager.CreateAsync(new IdentityRole("Admin"));
            }
            if (!await _roleManager.RoleExistsAsync("User"))
            {
                await _roleManager.CreateAsync(new IdentityRole("User"));
            }
        }

        private async Task SeedAdmin()
        {
            var adminEmail = "admin@gmail.com";
            var password = "Admin123!";

            var admin = await _userManager.FindByEmailAsync(adminEmail);

            if (admin == null)
            {
                admin = new ApplicationUser
                {
                    Email = adminEmail,
                    UserName = adminEmail,
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true,
                    PhoneNumber = "2222222"
                };

                var createResult = await _userManager.CreateAsync(admin, password);
                if (!createResult.Succeeded)
                {
                    Console.WriteLine("Admin creation failed:");
                    foreach (var error in createResult.Errors)
                        Console.WriteLine($" - {error.Description}");
                    return;
                }
            }

            _context.Add(new Contract
            {
                Id = Guid.NewGuid().ToString(),
                UserId = admin.Id,
                WorkingHour = 7,
                IsActive = true,
                HourlyRate = 20
            });

            var project = new Project
            {
                Id = Guid.NewGuid().ToString(),
                Name = projectNames[random.Next(projectNames.Length)],
                TypeOfProject = (byte)random.Next(0, 3),
                Description = descriptions[random.Next(descriptions.Length)]
            };
            _context.Add(project);

            var workDay = new WorkDay
            {
                Id = Guid.NewGuid().ToString(),
                Date = DateExtension.GetDateOnly(DateTime.Now)
            };
            _context.Add(workDay);

            var timeSpans = new (int startOffset, int endOffset, int type)[] {
                (-60, -30, 1),
                (-60, -30, 2),
                (-60, -30, 1),
            };

            foreach (var (startOffset, endOffset, type) in timeSpans)
            {
                _context.Add(new TimeSlice
                {
                    Id = Guid.NewGuid().ToString(),
                    WorkDayId = workDay.Id,
                    ProjectId = null,
                    Start = DateTime.Now.AddMinutes(startOffset),
                    End = DateTime.Now.AddMinutes(endOffset),
                    TypeOfSlice = (byte)type,
                    UserId = admin.Id
                });
            }

            _context.Add(new UserOnProject
            {
                Id = Guid.NewGuid().ToString(),
                UserId = admin.Id,
                ProjectId = project.Id,
                ProjectRole = "manager",
                RoleStartDate = DateTime.Now,
                RoleEndDate = DateTime.Now.AddMinutes(60)
            });

            _context.Add(new SickLeave
            {
                Id = Guid.NewGuid().ToString(),
                UserId = admin.Id,
                StartDate = DateOnly.FromDateTime(DateTime.Now),
                EndDate = DateOnly.FromDateTime(DateTime.Now.AddDays(5)),
                Year = 2025
            });

            var vacation = new AnnualVacation
            {
                Id = Guid.NewGuid().ToString(),
                UsedVacation = 8,
                Year = 2025,
                PlannedVacation = 5,
                AvailableVacation = 9,
                UserId = admin.Id
            };
            _context.Add(vacation);

            _context.Add(new Vacation
            {
                Id = Guid.NewGuid().ToString(),
                AnnualVacationId = vacation.Id,
                StartDate = DateOnly.FromDateTime(DateTime.Now),
                EndDate = DateOnly.FromDateTime(DateTime.Now.AddDays(5))
            });

            if (!await _userManager.IsInRoleAsync(admin, "Admin"))
            {
                await _userManager.AddToRoleAsync(admin, "Admin");
            }
        }

        private async Task SeedUser()
        {
            var userEmail = "test1@gmail.com";
            var password = "Test123!";

            var user = await _userManager.FindByEmailAsync(userEmail);

            if (user == null)
            {
                user = new ApplicationUser
                {
                    Email = userEmail,
                    UserName = userEmail,
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true,
                    PhoneNumber = "1111111"
                };

                var createResult = await _userManager.CreateAsync(user, password);
                if (!createResult.Succeeded)
                {
                    Console.WriteLine("User creation failed:");
                    foreach (var error in createResult.Errors)
                        Console.WriteLine($" - {error.Description}");
                    return;
                }
            }

            _context.Add(new Contract
            {
                Id = Guid.NewGuid().ToString(),
                UserId = user.Id,
                WorkingHour = 8,
                IsActive = true,
                HourlyRate = 10,
                Created = DateOnly.FromDateTime(DateTime.Now)
            });

            var project = new Project
            {
                Id = Guid.NewGuid().ToString(),
                Name = projectNames[random.Next(projectNames.Length)],
                TypeOfProject = (byte)random.Next(0, 3),
                Description = descriptions[random.Next(descriptions.Length)]
            };
            _context.Add(project);

            var workDay = new WorkDay
            {
                Id = Guid.NewGuid().ToString(),
                Date = DateExtension.GetDateOnly(DateTime.Now)
            };
            _context.Add(workDay);

            var timeSpans = new (int startOffset, int endOffset, int type)[] {
                (-60, -30, 1),
                (-60, -30, 2),
                (-60, -30, 1),
            };

            foreach (var (startOffset, endOffset, type) in timeSpans)
            {
                _context.Add(new TimeSlice
                {
                    Id = Guid.NewGuid().ToString(),
                    WorkDayId = workDay.Id,
                    ProjectId = null,
                    Start = DateTime.Now.AddMinutes(startOffset),
                    End = DateTime.Now.AddMinutes(endOffset),
                    TypeOfSlice = (byte)type,
                    UserId = user.Id
                });
            }

            _context.Add(new UserOnProject
            {
                Id = Guid.NewGuid().ToString(),
                UserId = user.Id,
                ProjectId = project.Id,
                ProjectRole = "tester",
                RoleStartDate = DateTime.Now,
                RoleEndDate = DateTime.Now.AddMinutes(60)
            });

            _context.Add(new SickLeave
            {
                Id = Guid.NewGuid().ToString(),
                UserId = user.Id,
                StartDate = DateOnly.FromDateTime(DateTime.Now),
                EndDate = DateOnly.FromDateTime(DateTime.Now.AddDays(5)),
                Year = 2025
            });

            var vacation = new AnnualVacation
            {
                Id = Guid.NewGuid().ToString(),
                UsedVacation = 5,
                Year = 2025,
                PlannedVacation = 3,
                AvailableVacation = 8,
                UserId = user.Id
            };
            _context.Add(vacation);

            _context.Add(new Vacation
            {
                Id = Guid.NewGuid().ToString(),
                AnnualVacationId = vacation.Id,
                StartDate = DateOnly.FromDateTime(DateTime.Now),
                EndDate = DateOnly.FromDateTime(DateTime.Now.AddDays(5))
            });

            if (!await _userManager.IsInRoleAsync(user, "User"))
            {
                await _userManager.AddToRoleAsync(user, "User");
            }
        }
    }
}
