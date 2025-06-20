using AMI.EduWork._2025.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMI.EduWork._2025.Data.Repository;

public class UserRepository : Repository<ApplicationUser>
{
    public UserRepository(ApplicationDbContext context) : base(context) { }

}
