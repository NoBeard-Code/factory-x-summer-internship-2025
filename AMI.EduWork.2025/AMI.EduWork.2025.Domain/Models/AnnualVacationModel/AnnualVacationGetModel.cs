using AMI.EduWork._2025.Domain.Models.User;
using AMI.EduWork._2025.Domain.Models.UserOnVacationModel;

namespace AMI.EduWork._2025.Domain.Models.VacationModel
{
    public class AnnualVacationGetModel
    {
        public string Id { get; set; }
        public int AvailableVacation { get; set; }
        public int PlannedVacation { get; set; }
        public int UsedVacation { get; set; }
        public int Year { get; set; }
        public GetUserModel _GetUserModel {  get; set; }
        public List<VacationGetModels> VacationGetModels {  get; set; }
    }
}
