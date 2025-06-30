using AMI.EduWork._2025.Domain;
using AMI.EduWork._2025.Domain.Entities;
using AMI.EduWork._2025.Domain.Helpers;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace AMI.EduWork._2025.Data.Migrations
{
    public class DataSeeder
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public DataSeeder(ApplicationDbContext context, UserManager<ApplicationUser> userManager) {
            _context = context;
            _userManager = userManager;

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
            var userEmail = "test1@gmail.com";
            var userName = "test1";
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

                var result = await _userManager.CreateAsync(user, password);
                if (!result.Succeeded)
                {
                    // Handle errors (e.g. log them)
                    return;
                }
            }

                var result = await _userManager.CreateAsync(user, "Ja123456!"); 
                if (!result.Succeeded) {
                    Console.WriteLine("User creation failed:");
                    foreach (var error in result.Errors)
                        Console.WriteLine($" - {error.Description}");
                    return;
                }
            } else {
                user = existingUser;
            }

            _context.Add(new Contract()
            {
                Id = Guid.NewGuid().ToString(),
                UserId = user.Id,
                WorkingHour = 8,
                IsActive = true,
                HourlyRate = 10,
            });

            var project = new Project {
                Id = Guid.NewGuid().ToString(),
                Name = projectNames[random.Next(projectNames.Length)],
                TypeOfProject = (byte)random.Next(0, 3), // 0 = Private, 1 = Business, 2 = Educational
                Description = descriptions[random.Next(descriptions.Length)]
            };
            _context.Add(project);

            var workDay = new WorkDay()
            {
                Id = Guid.NewGuid().ToString(),
                Date = DateExtension.GetDateOnly(DateTime.Now),
            };
            _context.Add(workDay);

           
            _context.Add(new TimeSlice() {
                Id = Guid.NewGuid().ToString(),
                WorkDayId = workDay.Id,
                ProjectId = null,
                Start = DateTime.Now.AddMinutes(-60),
                End = DateTime.Now.AddMinutes(-30),
                TypeOfSlice = 1,
                UserId = user.Id,
            });
            _context.Add(new TimeSlice() {
                Id = Guid.NewGuid().ToString(),
                WorkDayId = workDay.Id,
                ProjectId = null,
                Start = DateTime.Now.AddMinutes(-60),
                End = DateTime.Now.AddMinutes(-30),
                TypeOfSlice = 2,
                UserId = user.Id,
            });
            _context.Add(new TimeSlice() {
                Id = Guid.NewGuid().ToString(),
                WorkDayId = workDay.Id,
                ProjectId = null,
                Start = DateTime.Now.AddMinutes(-60),
                End = DateTime.Now.AddMinutes(-30),
                TypeOfSlice = 1,
                UserId = user.Id,
            });
            _context.Add(new TimeSlice() {
                Id = Guid.NewGuid().ToString(),
                WorkDayId = workDay.Id,
                ProjectId = null,
                Start = DateTime.Now.AddMinutes(-160),
                End = DateTime.Now.AddMinutes(-60),
                TypeOfSlice = 1,
                UserId = user.Id,
            });
            _context.Add(new TimeSlice() {
                Id = Guid.NewGuid().ToString(),
                WorkDayId = workDay.Id,
                ProjectId = null,
                Start = DateTime.Now.AddMinutes(-240),
                End = DateTime.Now.AddMinutes(-160),
                TypeOfSlice = 1,
                UserId = user.Id,
            });

            _context.Add(new UserOnProject()
            {
                Id = Guid.NewGuid().ToString(),
                UserId = user.Id,
                ProjectId = project.Id,
                ProjectRole = "tester",
                RoleStartDate = DateTime.Now,
                RoleEndDate = DateTime.Now.AddMinutes(60),

            });

            _context.Add(new SickLeave()
            {
                Id = Guid.NewGuid().ToString(),
                UserId = user.Id,
                StartDate = DateOnly.FromDateTime(DateTime.Now),
                EndDate = DateOnly.FromDateTime(DateTime.Now.AddDays(5)),
                Year = 2025
            });

            var vacation = new AnnualVacation()
            {
                Id = Guid.NewGuid().ToString(),
                UsedVacation = 5,
                Year = 2025,
                PlannedVacation = 3,
                AvailableVacation = 8,
                UserId = user.Id
            };

            _context.Add(vacation);

            _context.Add(new Vacation() {
                Id = Guid.NewGuid().ToString(),
                AnnualVacationId = vacation.Id,
                StartDate = DateOnly.FromDateTime(DateTime.Now),
                EndDate = DateOnly.FromDateTime(DateTime.Now.AddDays(5))
            });

            _context.SaveChanges();
        }
    }
}
