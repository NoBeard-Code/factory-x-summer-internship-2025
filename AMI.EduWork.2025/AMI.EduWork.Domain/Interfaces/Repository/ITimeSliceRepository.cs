using AMI.EduWork.Domain.Entities;
using AMI.EduWork.Domain.IRepository.Repository;

namespace AMI.EduWork.Domain.Interfaces.Repository;

public interface ITimeSliceRepository : IRepository<TimeSlice>
{
    Task<IEnumerable<TimeSlice>> GetAllUserTimeSlices(string userId);
    Task<IEnumerable<TimeSlice>> GetAllUserTimeSlicesByDate(string userId, DateTime date);
}
