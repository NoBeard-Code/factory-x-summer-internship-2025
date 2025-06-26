using AMI.EduWork._2025.Domain.Models.User;
using AMI.EduWork._2025.Domain.Models.WorkDay;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMI.EduWork._2025.Domain.Models.TimeSlice;

public class TimeSliceModel
{
    public DateTime? Start { get; set; }
    public DateTime? End { get; set; }
    public byte TypeOfSlice { get; set; }
    public string? ProjectId { get; set; }
    public required string UserId { get; set; }
    public string? Description { get; set; }

}

public class GetTimeSliceModel : TimeSliceModel
{
    public string Id { get; internal set; }
    public required string WorkDayId { get; set; }
    public required GetWorkDayModel WorkDay { get; set; }
    //public required GetProjectModel? Project { get; set; }
    public required GetUserModel User { get; set; }

}
