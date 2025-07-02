using AMI.EduWork.Domain.Models.AnnualVacationModel;

namespace AMI.EduWork.Domain.Models.UserOnVacationModel;

public class VacationGetModel
{
    public string Id { get; set; }
    public AnnualVacationGetVacationModel _AnnualVacationGetModel { get; set; }
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
}
