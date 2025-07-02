namespace AMI.EduWork.Domain.Models.UserOnVacationModel
{
    public class VacationUpdateModel
    {
        public string Id { get; set; }
        public string AnnualVacationId { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
    }
}
