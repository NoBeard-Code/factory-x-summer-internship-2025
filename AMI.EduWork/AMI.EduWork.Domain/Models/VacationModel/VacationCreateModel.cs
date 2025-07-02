namespace AMI.EduWork.Domain.Models.UserOnVacationModel
{
    public class VacationCreateModel
    {
        public string AnnualVacationId { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
    }
}
