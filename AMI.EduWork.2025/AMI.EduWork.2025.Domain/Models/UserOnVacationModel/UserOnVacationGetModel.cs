using AMI.EduWork._2025.Domain;
using AMI.EduWork._2025.Domain.Entities;
using AMI.EduWork._2025.Domain.Models.VacationModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMI.EduWork._2025.Domain.Models.UserOnVacationModel
{
    public class UserOnVacationGetModel
    {
        //public string UserGetModel { get; set; }
        public VacationGetModel _VacationGetModel { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
