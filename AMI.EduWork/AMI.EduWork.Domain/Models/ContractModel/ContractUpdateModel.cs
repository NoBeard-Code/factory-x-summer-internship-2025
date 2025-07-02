namespace AMI.EduWork.Domain.Models.ContractModel
{
    public class ContractUpdateModel
    {
        public string Id { get; set; }
        public int WorkingHour { get; set; }
        public DateOnly Created { get; set; }
        public bool IsActive { get; set; }
        public int HourlyRate { get; set; }
        public string UserId { get; set; }
    }
}
