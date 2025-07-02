namespace AMI.EduWork.Domain.Models.AnnualVacationModel
{
    public class AnnualVacationGetVacationModel
    {
        public string Id { get; set; }
        public int AvailableVacation { get; set; }
        public int PlannedVacation { get; set; }
        public int UsedVacation { get; set; }
        public int Year { get; set; }
        public string UserId { get; set; }
    }
}
