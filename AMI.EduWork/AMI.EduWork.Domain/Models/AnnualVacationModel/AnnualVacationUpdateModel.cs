namespace AMI.EduWork.Domain.Models.VacationModel
{
    public class AnnualVacationUpdateModel
    {
        public string Id { get; set; }
        public int AvailableVacation { get; set; }
        public int PlannedVacation { get; set; }
        public int UsedVacation { get; set; }
        public int Year { get; set; }
        public string UserId { get; set; }

    }
}
