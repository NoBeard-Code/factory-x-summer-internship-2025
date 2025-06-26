using AMI.EduWork._2025.Domain.Models.TimeSlice;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMI.EduWork._2025.Domain.Interfaces.Service;

public interface ITimeSliceService
{
    Task<GetTimeSliceModel> GetById(string id);
    Task<IEnumerable<GetTimeSliceModel>> GetAllUserTimeSlices(string userId);
    Task<IEnumerable<GetTimeSliceModel>> GetAllUserTimeSlicesByDate(string userId, DateTime date);
    Task<bool> Create(TimeSliceModel entity);
    Task<bool> Update(GetTimeSliceModel entity);
    Task<bool> DeleteById(string id);
}
