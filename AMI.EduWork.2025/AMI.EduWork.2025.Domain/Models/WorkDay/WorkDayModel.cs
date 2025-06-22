using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMI.EduWork._2025.Domain.Models.WorkDay;

public class WorkDayModel
{
    public DateTime Date { get; set; }
}

public class GetWorkDayModel : WorkDayModel
{
    public string Id { get; internal set; }
}
