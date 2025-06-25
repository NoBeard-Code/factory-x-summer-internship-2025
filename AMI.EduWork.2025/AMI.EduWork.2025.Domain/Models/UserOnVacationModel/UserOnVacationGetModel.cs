using AMI.EduWork._2025.Domain.Models.User;
using AMI.EduWork._2025.Domain.Models.VacationModel;

namespace AMI.EduWork._2025.Domain.Models.UserOnVacationModel;

public class UserOnVacationGetModel
{
    public string Id { get; set; }
    public GetUserModel _GetUserModel { get; set; }
    public VacationGetModel _VacationGetModel { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}
