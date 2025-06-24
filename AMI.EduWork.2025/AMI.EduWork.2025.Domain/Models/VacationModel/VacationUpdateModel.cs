using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMI.EduWork._2025.Domain.Models.VacationModel
{
    public class VacationUpdateModel
    {
        public int AvailableVacation { get; internal set; }
        public int PlannedVacation { get; internal set; }
        public int UsedVacation { get; internal set; }
        public int Year { get; internal set; }
        public string Id { get; internal set; }
    }
}
