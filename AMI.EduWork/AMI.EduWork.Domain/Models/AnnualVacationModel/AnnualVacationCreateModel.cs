namespace AMI.EduWork.Domain.Models.VacationModel
{
    public class AnnualVacationCreateModel
    {
        public string UserId { get; set; }
        public int UsedVacation { get; set; }
        public int PlannedVacation { get; set; }
        public int AvailableVacation { get; set; }
        public int Year { get; set; }
    }
}
