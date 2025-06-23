using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMI.EduWork._2025.Domain.Models.VacationModel
{
    public class VacationGetModel
    {
        public VacationGetModel() { }
        public string Id { get; set; }
        public int AvailableVacation { get; set; }
        public int PlannedVacation { get; set; }
        public int UsedVacation { get; set; }
        public int Year { get; set; }
    }
}
