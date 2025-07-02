using AMI.EduWork.Components.Feature.Project.Components;
using AMI.EduWork.Domain.Models.Project;
using AMI.EduWork.Domain.Models.TimeSlice;
using AMI.EduWork.Domain.Models.User;
using AMI.EduWork.Domain.Models.WorkDay;
using Bunit;
using Microsoft.AspNetCore.Components;
using MudBlazor.Services;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using Xunit;

namespace AMI.EduWork.Tests {
    public class ProjectTimeEntryDialogTests : TestContext {
        public ProjectTimeEntryDialogTests() {
            // Register MudBlazor services so MudDialog etc. work in the test renderer
            Services.AddMudServices();
        }

        // Helper to set internal-set properties (Id) via reflection
        private void SetInternalId<T>(T obj, string propName, string value) {
            var prop = typeof(T)
                .GetProperty(propName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)!;
            prop.SetValue(obj, value);
        }

        private GetUserModel CreateTestUser() {
            var user = new GetUserModel {
                UserName = "test.user",
                Email = "test@example.com",
                Role = 1
            };
            SetInternalId(user, nameof(GetUserModel.Id), Guid.NewGuid().ToString());
            return user;
        }

        private GetProjectModel CreateSampleProject() =>
            new GetProjectModel {
                Id = Guid.NewGuid().ToString(),
                Name = "Test Project",
                Description = "Project for unit tests",
                TypeOfProject = 1
            };

        private GetTimeSliceModel CreateSampleTimeSlice(GetProjectModel project) {
            // prepare user
            var user = CreateTestUser();

            // prepare workday
            var workDay = new GetWorkDayModel {
                Date = new DateTime(2025, 1, 1)
            };
            SetInternalId(workDay, nameof(GetWorkDayModel.Id), Guid.NewGuid().ToString());

            // prepare slice
            var slice = new GetTimeSliceModel {
                Start = new DateTime(2025, 1, 1, 9, 0, 0),
                End = new DateTime(2025, 1, 1, 10, 30, 0),
                TypeOfSlice = 0,
                UserId = user.Id,
                User = user,
                WorkDayId = workDay.Id,
                WorkDay = workDay,
                Project = new GetProjectModelNoRefrences {
                    Id = project.Id,
                    Name = project.Name,
                    Description = project.Description,
                    TypeOfProject = project.TypeOfProject
                }
            };
            SetInternalId(slice, nameof(GetTimeSliceModel.Id), Guid.NewGuid().ToString());
            return slice;
        }

        [Fact]
        public void ShowsTimeSliceWithFormattedDuration() {
            // Arrange
            var project = CreateSampleProject();
            var slice = CreateSampleTimeSlice(project);
            var slices = new List<GetTimeSliceModel> { slice };

            // Act
            var cut = RenderComponent<ProjectTimeEntryDialog>(parameters => parameters
                .Add(p => p.Project, project)
                .Add(p => p.AvailableTimeSlices, slices)
                .Add(p => p.OnTimeSliceAssigned,
                     EventCallback.Factory.Create<GetTimeSliceModel>(this, (_) => Task.CompletedTask))
            );

            // Assert
            cut.Markup.Contains($"Assign Time Entry to <b>{project.Name}</b>");
            cut.Markup.Contains("01.01 09:00 - 10:30");
            cut.Markup.Contains("1 hour 30 minutes");
        }

        [Fact]
        public void ClickingAssignButtonInvokesCallbackAndSetsProjectId() {
            // Arrange
            var project = CreateSampleProject();
            var slice = CreateSampleTimeSlice(project);
            var slices = new List<GetTimeSliceModel> { slice };
            GetTimeSliceModel? assigned = null;

            // Act
            var cut = RenderComponent<ProjectTimeEntryDialog>(parameters => parameters
                .Add(p => p.Project, project)
                .Add(p => p.AvailableTimeSlices, slices)
                .Add(p => p.OnTimeSliceAssigned,
                     EventCallback.Factory.Create<GetTimeSliceModel>(this, s => {
                         assigned = s;
                         return Task.CompletedTask;
                     }))
            );

            cut.Find("button").Click(); 

            // Assert
            Assert.NotNull(assigned);
            Assert.Equal(project.Id, assigned!.ProjectId);
        }

        [Fact]
        public void DisplaysFallbackTextWhenNoTimeEntries() {
            // Arrange
            var project = CreateSampleProject();

            // Act
            var cut = RenderComponent<ProjectTimeEntryDialog>(parameters => parameters
                .Add(p => p.Project, project)
                .Add(p => p.AvailableTimeSlices, new List<GetTimeSliceModel>())
                .Add(p => p.OnTimeSliceAssigned,
                     EventCallback.Factory.Create<GetTimeSliceModel>(this, (_) => Task.CompletedTask))
            );

            // Assert
            cut.Markup.Contains("No available time entries.");
        }
    }
}
