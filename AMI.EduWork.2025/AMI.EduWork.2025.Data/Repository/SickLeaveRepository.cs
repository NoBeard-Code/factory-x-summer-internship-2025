using AMI.EduWork._2025.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMI.EduWork._2025.Data.Repository;

public class SickLeaveRepository : Repository<SickLeave>
{
    public SickLeaveRepository(ApplicationDbContext context) : base(context) { }
}
