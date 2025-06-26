using AMI.EduWork._2025.Domain.Entities;
using AMI.EduWork._2025.Domain.IRepository.Repository;

namespace AMI.EduWork._2025.Domain.Interfaces.Repository;

public interface ITimeSliceRepository : IRepository<TimeSlice>
{
    Task<IEnumerable<TimeSlice>> GetAllUserTimeSlices(string userId);
    Task<IEnumerable<TimeSlice>> GetAllUserTimeSlicesByDate(string userId, DateTime date);
}
