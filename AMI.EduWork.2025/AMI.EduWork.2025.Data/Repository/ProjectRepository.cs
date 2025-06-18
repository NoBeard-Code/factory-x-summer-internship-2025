using AMI.EduWork._2025.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMI.EduWork._2025.Data.Repository;

public class ProjectRepository : Repository<Project>
{
    public ProjectRepository(ApplicationDbContext context) :base(context) { }

}
