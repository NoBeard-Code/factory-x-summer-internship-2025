namespace AMI.EduWork._2025.Domain.Models.UserOnVacationModel
{
    public class UserOnVacationUpdateModel
    {
        public string Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string UserId { get; set; }
        public string AnnualVacationId { get; set; }
    }
}
