using AMI.EduWork._2025.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMI.EduWork._2025.Data.Repository;

public class TimeSliceRepository : Repository<TimeSlice>
{
    public TimeSliceRepository(ApplicationDbContext context) : base(context) { }
            
}
