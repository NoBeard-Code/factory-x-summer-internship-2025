using AMI.EduWork.Domain.Models.Project;
using AMI.EduWork.Domain.Models.User;
using AMI.EduWork.Domain.Models.WorkDay;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMI.EduWork.Domain.Models.TimeSlice;

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
    public required GetProjectModelNoRefrences? Project { get; set; }
    public required GetUserModel User { get; set; }

}
